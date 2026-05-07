using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AddService : ICalService
    {
        public string Cal(double a , double b) { return $"{a + b}"; }
        public string Cal(double a, double b , double c) { return $"{a + b + c}"; }
        public string Cal(double a, double b, double c , double d) { return $"{a + b + c + d}"; }
    }
}
