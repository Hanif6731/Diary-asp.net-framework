
using LabExamMid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamMid.Repository
{
    interface IUserRepository:IRepository<User>
    {
        int GetUser(User u);
        int GetUser(string username);
    }
}
