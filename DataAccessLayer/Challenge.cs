namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Challenge
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChallengeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        [StringLength(50)]
        public string MiscDescription { get; set; }
    }
}
