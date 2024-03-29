﻿using Microsoft.EntityFrameworkCore;
using System;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class HospitalContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Schedule> Scchedules { get; set; }

        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

  
    }
}
