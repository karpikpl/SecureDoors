using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureDoors
{
    class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new Solver();
            solver.Solve(System.Console.OpenStandardInput(), System.Console.OpenStandardOutput());
        }
    }
}
