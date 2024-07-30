using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class DatabaseFixture : IDisposable
    {
        public PruductsDbContext Context { get; private set; }

        public DatabaseFixture()
        {
            // Set up the test database connection and initialize the context
            var options = new DbContextOptionsBuilder<PruductsDbContext>()
                .UseSqlServer("Server=srv2\\pupils;Database=Tests;Trusted_Connection=True;")
                .Options;
            Context = new PruductsDbContext(options);
            Context.Database.EnsureCreated();// create the data base
        }

        public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
