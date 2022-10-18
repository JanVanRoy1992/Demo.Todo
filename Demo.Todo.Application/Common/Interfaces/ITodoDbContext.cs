using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Todo.Application.Common.Interfaces
{
    public interface ITodoDbContext
    {
        DbSet<Domain.Todo> Todos { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
