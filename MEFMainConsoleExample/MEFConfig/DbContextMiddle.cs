﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFConfig {
    public abstract class DbContextMiddle : DbContext {
        public int NameStriung { get; set; }
    }
}
