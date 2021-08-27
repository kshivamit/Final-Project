using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuthenticate
    {
        Task<bool> CreateUser(AuthenticateModel model);
        Task<bool> IsAuthenticate(AuthenticateModel model);
    }
}
