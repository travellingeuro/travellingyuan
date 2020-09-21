using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using travellingyuan.Models;

namespace travellingyuan.Services.User
{
    public interface IUserService
    {
        Task<List<Users>> GetUserEmail(string email);
        Task<string> PostUser(Models.Users user);
    }
}
