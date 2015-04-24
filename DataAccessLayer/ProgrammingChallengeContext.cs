namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProgrammingChallengeContext : DbContext, IProgrammingChallengeContext
    {
        public ProgrammingChallengeContext(string connStrName)
            : base("name=" + connStrName)
        {
        }

        public virtual IDbSet<BasePoint> BasePoints { get; set; }
        public virtual IDbSet<Challenge> Challenges { get; set; }
        public virtual IDbSet<Entry> Entries { get; set; }
        public virtual IDbSet<Language> Languages { get; set; }
        public virtual IDbSet<Modifier> Modifiers { get; set; }
        public virtual IDbSet<ModifierType> ModifierTypes { get; set; }
        public virtual IDbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
