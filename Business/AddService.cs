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

        public double Calculate(double[] nums)
        {
            Validate(nums);
            return Add(nums, 0);
        }

        private void Validate(double[] nums)
        {
            if (nums.Length < 2 || nums.Length > int.MaxValue)
                throw new Exception("enter minimum 2 numbers");
        }

        protected double Add(double[] nums, int i)
        {
            if (i == nums.Length)
                return 0;

            return nums[i] + Add(nums, i + 1);
        }
    }
}


//public string Cal(double a , double b) { return $"{a + b}"; }
//public string Cal(double a, double b , double c) { return $"{a + b + c}"; }
//public string Cal(double a, double b, double c , double d) { return $"{a + b + c + d}"; }

//double result = nums[0];

//for (int i = 1; i < nums.Length; i++)
//{
//    result += nums[i];
//}

//return result;
