namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IProgrammingChallengeContextFactory
    {
        IProgrammingChallengeContext Create();
    }

    public interface IProgrammingChallengeContext : IDisposable
    {
        IDbSet<BasePoint> BasePoints { get; set; }
        IDbSet<Challenge> Challenges { get; set; }
        IDbSet<Entry> Entries { get; set; }
        IDbSet<Language> Languages { get; set; }
        IDbSet<Modifier> Modifiers { get; set; }
        IDbSet<ModifierType> ModifierTypes { get; set; }
        IDbSet<Person> People { get; set; }
        int SaveChanges();
        void Dispose();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}