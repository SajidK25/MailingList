﻿using System;
using Microsoft.EntityFrameworkCore;

namespace MailingList.Data
{
    public class UnitOfWork<T>:IUnitOfWork<T> where T :DbContext
    {
        protected readonly T _dbContext;

        public UnitOfWork(string connectionString, string migrationAssemblyName)
            => _dbContext = (T)Activator.CreateInstance(typeof(T), connectionString, migrationAssemblyName);

        public void Dispose() => _dbContext?.Dispose();

        public void Save() => _dbContext?.SaveChanges();
    }
}
