namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CUSTOMERS
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string CUSTOMERNAME { get; set; }

        [StringLength(5)]
        public string GENDER { get; set; }

        public int? AGE { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }
        [StringLength(20)]
        public string PASSWORD { get; set; }
    }
}
