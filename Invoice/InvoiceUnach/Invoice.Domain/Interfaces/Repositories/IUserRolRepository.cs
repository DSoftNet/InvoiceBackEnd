using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface IUserRolRepository: IRepository<UserRol>
    {
        Task<List<UserRol>> Gets();
        Task<UserRol> Get(Guid id);
        UserRol Add(UserRol userRol);
        UserRol Update(UserRol userRol);
    }
}