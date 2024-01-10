using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    class TestDoctorRepository : BaseRepository<Doctor>
    {
        public TestDoctorRepository(DbContext context): base(context)
        {
        }
    }
}
