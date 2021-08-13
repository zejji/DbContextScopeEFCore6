﻿using DbContextScope.Tests.Models;
using Microsoft.EntityFrameworkCore;
using Zejji.Entity;

namespace DbContextScope.Tests.Helpers
{
    internal class TestDbContextFactory : IDbContextFactory
    {
        private string _connectionString;

        public TestDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext
        {
            var contextType = typeof(TDbContext);
            TDbContext context;

            if (contextType == typeof(TestDbContext))
            {
                context = (TDbContext)(DbContext)new TestDbContext(_connectionString);
            }
            else
            {
                throw new InvalidOperationException("Unrecognized DbContext type.");
            }

            return context;
        }
    }
}
