using System;
using System.Collections.Generic;
using System.Text;
using Art_Gallary.Models;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallary.Tests
{
    public class Art_GallaryTestBase:IDisposable
    {
        protected readonly ShopContext _context;
        public Art_GallaryTestBase()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ShopContext(options);
            _context.Database.EnsureCreated();

            Art_Gallary_Initializer.Initialize(_context);
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
