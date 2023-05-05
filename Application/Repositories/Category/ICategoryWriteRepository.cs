using Domain.Entities;
using ETicaretAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICategoryWriteRepository : IWriteRepository<Category>
    {
    }
}
