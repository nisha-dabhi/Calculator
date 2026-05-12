using Business;
using Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.Controllers
{
    public class Cal : Controller
    {       
        private readonly AddService _add;
        private readonly SubService _sub;
        private readonly MulService _mul;
        private readonly DivService _div;
        private readonly SumService _sum;

        public Cal(AddService add, SubService sub, MulService mul, DivService div , SumService sum)
        {
            _add = add;
            _sub = sub;
            _mul = mul;
            _div = div;
            _sum = sum;
        }

        public IActionResult Index()
        {
            return View();
        }

        private int index = 0;

       
        [HttpPost]        
        public IActionResult Index(string display, string button)
        {
            display ??= "";

            if (button == "AC")
            {
                display = "";
            }
            else if (button == "C")
            {
                if (display.Length > 0)
                    display = display.Substring(0, display.Length - 1);
            }
            else if (button == "=")
            {
                try
                {
                    display = Calculate(display).ToString();
                }
                catch
                {
                    display = "Error";
                }
            }
            else
            {
                display += button;
            }

            ViewBag.Display = display;

            return View();
        }

        //public double Calculate(string eq)
        //{
        //    index = 0;
        //    return Maths(eq);
        //}
        private double Maths(string eq)
        {
            double result = 0;
            string n = "";
            char op = '+';

            for (int i = 0; i < eq.Length; i++)
            {
                char ch = eq[i];
                if (i == 0 && ch == '-')
                {
                    n += ch;
                    continue;
                }

                bool isOp = (ch == '+' || ch == '-' || ch == '*' || ch == '/' );
                bool isLast = (i == eq.Length - 1);

                if (!isOp)
                {
                    n += ch;
                }

                if (isOp || isLast)
                {
                    double num = Convert.ToDouble(n);
                    double[] nums = { result, num };

                    if (op == '+') result = _sum.Sum(nums);
                    else if (op == '-') result = _sub.Calculate(nums);
                    else if (op == '*') result = _mul.Calculate(nums);
                    else if (op == '/') result = _div.Calculate(nums);

                    op = ch;
                    n = "";
                }
            }
            return result;
        }
    }
}




//if (display.Contains("+")) op = '+';
//else if (display.Contains("-")) op = '-';
//else if (display.Contains("*")) op = '*';
//else if (display.Contains("/")) op = '/';

//string[] arr = display.Split(op);

//double[] nums = new double[arr.Length];

//for (int i = 0; i < arr.Length; i++)
//{
//    nums[i] = Convert.ToDouble(arr[i]);
//}



//public IActionResult Index(double a, double b, double? c, double? d, string op)
//{
//    string result = "";

//    if (op == "add")
//    {
//        if (c.HasValue && d.HasValue) { result = _add.Cal(a, b, c.Value, d.Value); }

//        else if (c.HasValue) { result = _add.Cal(a, b, c.Value); }

//        else { result = _add.Cal(a, b); }
//    }
//    else if (op == "sub")
//    {
//        if (c.HasValue && d.HasValue) { result = _sub.Cal(a, b, c.Value, d.Value); }

//        else if (c.HasValue) { result = _sub.Cal(a, b, c.Value); }

//        else { result = _sub.Cal(a, b); }
//    }
//    else if (op == "mul")
//    {
//        if (c.HasValue && d.HasValue) { result = _mul.Cal(a, b, c.Value, d.Value); }

//        else if (c.HasValue) { result = _mul.Cal(a, b, c.Value); }

//        else { result = _mul.Cal(a, b); }
//    }
//    else if (op == "div")
//    {
//        if (c.HasValue && d.HasValue) { result = _div.Cal(a, b, c.Value, d.Value); }

//        else if (c.HasValue) { result = _div.Cal(a, b, c.Value); }

//        else { result = _div.Cal(a, b); }
//    }

//    ViewBag.Result = result;
//    return View("Index");
//}




//private readonly ICalService _calculator;

//[HttpPost]

//public IActionResult Index(string display, string button)
//{
//    display ??= "";

//    if (button == "AC")
//    {
//        display = "";
//    }
//    else if (button == "C")
//    {
//        if (display.Length > 0) display = display.Substring(0, display.Length - 1);
//    }
//    else if (button == "=")
//    {
//        try
//        {
//           display = _calculator.Calculate(display).ToString();                   
//        }
//        catch
//        {
//            display = "Error";
//        }
//    }
//    else
//    {
//        display += button;
//    }

//    ViewBag.Display = display;
//    return View();
//}

