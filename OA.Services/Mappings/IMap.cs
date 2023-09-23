namespace OA.Services.Mappings
{
    public interface IMap<T>
    {
        public T Map(T obj, string proprtyName, object objValue);
        public T Map(T obj, object objValue);
    }
}
