using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    //--------------------------------------------
    //Репозиторий позволяет абстрагироваться от конкретных подключений к источникам данных, с которыми работает программа,
    // и является промежуточным звеном между классами, непосредственно взаимодействующими с данными, и остальной программой.
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public class BookRepository : IRepository<book>
    {
        private LibruaryContext db;

        public BookRepository(LibruaryContext context)
        {
            this.db = context;
        }

        public IEnumerable<book> GetAll()
        {
            return db.books;
        }

        public book Get(int id)
        {
            return db.books.Find(id);
        }

        public void Create(book book)
        {
            db.books.Add(book);
        }
       

        public void Delete(int id)
        {
            book book = db.books.Find(id);
            if (book != null)
                db.books.Remove(book);
        }

        public void Update(book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }
    }

    public class authorrepository : IRepository<authors>
    {
        private Model1 db;

        public authorrepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<authors> GetAll()
        {
            return db.authors.Include(o => o.books);
        }

        public authors Get(int id)
        {
            return db.authors.Find(id);
        }

        public void Create(authors author)
        {
            db.authors.Add(author);
        }

        public void Update(authors author)
        {
            db.Entry(author).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            authors author = db.authors.Find(id);
            if (author != null)
                db.authors.Remove(author);
        }
    }
    //-----------------------------------------------------
    //Паттерн Unit of Work позволяет упростить работу с различными репозиториями и дает уверенность,
    // что все репозитории будут использовать один и тот же контекст данных.
    public class UnitOfWork : IDisposable
    {
        private LibruaryContext db = new LibruaryContext();
        private Model1 mdb = new Model1();
        private BookRepository bookRepository;
        private authorrepository authorRepository;

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public authorrepository Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new authorrepository(mdb);
                return authorRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
