namespace YesGuruji.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFeedBack")]
    public partial class tblFeedBack
    {
        [Key]
        public int FeedBackId { get; set; }

        [StringLength(50)]
        public string VideoId { get; set; }

        public int? Rate { get; set; }

        public string Comment { get; set; }

        public bool? IsDisplay { get; set; }

        public DateTime? CreateDate { get; set; }

        public int isSort { get; set; }

        public string UserName { get; set; }
    }
}
