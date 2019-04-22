using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppVeyor.Tests.Common
{
    public class Engine
    {
        public void Run()
        {
            var bldr = new DbContextOptionsBuilder();
            var op = bldr.Options;
            Console.WriteLine(op is null);
        }
    }
}
