using System;
using Microsoft.EntityFrameworkCore;

namespace MailingList.Data
{
    public interface IUnitOfWork<T> : IDisposable where T : DbContext
    {
        void Save();
    }
}
