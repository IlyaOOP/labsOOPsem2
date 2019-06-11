namespace lab9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class authors
    {
        public override string ToString()
        {
            string res = "Код автора: " + authornamecode + ", Имя: " + authorname;
            return res;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public authors()
        {
            books = new HashSet<books>();
        }

        [Key]
        [StringLength(3)]
        public string authornamecode { get; set; }

        [StringLength(30)]
        public string authorname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<books> books { get; set; }
    }
}
