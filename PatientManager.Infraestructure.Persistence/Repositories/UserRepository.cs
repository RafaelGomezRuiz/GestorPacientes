using Microsoft.EntityFrameworkCore;
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infraestructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Infraestructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        protected readonly ApplicationContext _dbContext;
        public UserRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public override Task<User> AddAsync(User entity)
        {
            entity.Password=PasswordEncryption.ComputeSha256Hash(entity.Password);
            return base.AddAsync(entity);
        }

        public async Task<User> LoginAsync(LoginViewModel loginViewModel)
        {
            string passwordEncrypted = PasswordEncryption.ComputeSha256Hash(loginViewModel.Password);
            User? user=await _dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.UserName == loginViewModel.UserName
                && user.Password == passwordEncrypted);
            return user;
        }
    }
}
