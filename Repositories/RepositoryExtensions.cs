namespace WiredBrainCoffee.StorageApp.Repositories
{
    public static class RepositoryExtensions
    {
        //extension method for interfaces of repository (IWriteRepository)
        //1. class need to be static\
        //2. method need to be static
        //3. before the first parameter that we extend we have to add "this" keyword
        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}
