﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFMainConsoleExample {

    interface IExternalModule {

        string Title { get; }

        string message();
        void display();
    }
}
