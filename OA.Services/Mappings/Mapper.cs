namespace OA.Services.Mappings
{
    public class Mapper<T> : IMap<T> where T : class
    {
        public T Map(T obj, string proprtyName, object objValue)
        {
            typeof(T).GetProperty(proprtyName)?.SetValue(obj, objValue);
            return obj;
        }
        public T Map(T obj, object objValue)
        {
            foreach (var item in typeof(T).GetProperties())
            {
                typeof(T).GetProperty(item.ToString()!)?.SetValue(obj, objValue);
            }
            return obj;
        }
    }
}
