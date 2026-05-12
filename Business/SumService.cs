using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SumService : AddService 
    {
        public double Sum(double[] nums)
        {
            return Add(nums, 0);
        }
    }
}
