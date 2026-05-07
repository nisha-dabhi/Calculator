using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICalService
    {
      //  double Calculate(string expression);

        string Cal(double a , double b);
        string Cal(double a , double b , double c );
        string Cal(double a, double b, double c , double d);
    }
}
