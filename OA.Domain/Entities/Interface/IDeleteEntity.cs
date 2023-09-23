namespace OA.Domain.Entities.Interface
{
    public interface IDeleteEntity
    {
        bool? IsDeleted { get; set; }
    }
    public interface IDeleteEntity<TKey> : IDeleteEntity, IBaseEntity<TKey> { }
}
