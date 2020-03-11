
using LabExamMid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExamMid.Repository
{
    public class MemoryRepository : Repository<Memory>, IMemoryRepository
    {
        public IEnumerable<Memory> GetAll(String u)
        {
            return context.Set<Memory>().Where(c=>c.Username.Equals(u)).OrderByDescending(c=>c.Priority).ToList();
        }
    }
}