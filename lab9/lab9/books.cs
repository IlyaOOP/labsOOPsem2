namespace lab9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class books
    {
        public int id { get; set; }

        [StringLength(30)]
        public string bookname { get; set; }

        public int? size { get; set; }

        [StringLength(3)]
        public string authornamecode { get; set; }

        public virtual authors authors { get; set; }
    }
}
