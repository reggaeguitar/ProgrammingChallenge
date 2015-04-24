namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ModifierType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModifierTypeId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
    }
}
