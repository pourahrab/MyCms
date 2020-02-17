﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class MyCmsContex:DbContext
    {
        public DbSet<PageGroup> PageGroups { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<PageComment> pageComments { get; set; }

        public DbSet<AdminLogIn> adminLogin { get; set; }

    }
}
