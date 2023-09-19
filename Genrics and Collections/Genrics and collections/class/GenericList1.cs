namespace Genrics_and_collections.@class
{
    public class GenericList<T>
    {
        private List<T> list = new List<T>();

        public void Add(T item)
        {
            list.Add(item);
        }

        public T GetItem(int index)
        {
            return list[index];
        }
    }
}