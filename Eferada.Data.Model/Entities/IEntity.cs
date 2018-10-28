namespace Eferada.Data.Model.Entities
{
    public interface IEntity
    {
        int Id { get; }
        bool IsPersisted();
    }

    public interface IAbbraviationEntity : IEntity
    {
        string Abbreviation { get; }
    }

    public interface INameEntity : IEntity
    {
        string Name { get; }
    }

    public interface IAbbreviationAndNameEntity : IAbbraviationEntity, INameEntity
    {

    }
}