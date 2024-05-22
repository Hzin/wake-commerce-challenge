using WakeChallenge.INFRASTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;

namespace WakeChallenge.TEST.Fixtures
{
    public class DbFixture : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public DbFixture()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase("InMemoryDbForTesting");

            _context = new ApplicationDbContext(builder.Options);
            _context.Database.EnsureCreated();
        }

        public ApplicationDbContext Context => _context;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Database.EnsureDeleted();
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
