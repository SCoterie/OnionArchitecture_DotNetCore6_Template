using OA.Domain.Entities.Interface;

namespace OA.Domain.Entities.Implementation
{
    public class DeleteEntity<TKey> : BaseEntity<TKey>, IDeleteEntity<TKey>
    {
        public bool? IsDeleted { get; set; }
    }
}
