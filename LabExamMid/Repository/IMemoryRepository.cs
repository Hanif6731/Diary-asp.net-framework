
using LabExamMid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamMid.Repository
{
    interface IMemoryRepository:IRepository<Memory>
    {
        IEnumerable<Memory> GetAll(string u);
    }
}
