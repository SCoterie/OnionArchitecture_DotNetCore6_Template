namespace OA.Persistance
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private Func<ApplicationContext> _instanceFunc;
        private ApplicationContext _dbContext;
        public ApplicationContext ApplicationContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());

        public DbFactory(Func<ApplicationContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                //_dbContext.Dispose();
            }
        }
    }
}
