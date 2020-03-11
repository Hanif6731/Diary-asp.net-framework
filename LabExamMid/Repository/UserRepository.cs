
using LabExamMid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExamMid.Repository
{
    public class UserRepository : Repository<User>,IUserRepository
    {
       public int GetUser(User u)
        {
            
            return context.Set<User>().Where(w=> (w.Username==u.Username) && (w.Password==u.Password)).ToList().Count();
        }
        public int GetUser(string username)
        {

            return context.Set<User>().Where(w => (w.Username == username)).ToList().Count();
        }
    }
}