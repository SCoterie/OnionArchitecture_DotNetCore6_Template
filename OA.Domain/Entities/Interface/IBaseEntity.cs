namespace OA.Domain.Entities.Interface
{
    public interface IBaseEntity<TKey>
    {
        TKey? Id { get; set; }
    }
}
