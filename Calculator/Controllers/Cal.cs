using Business;
using Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Calculator.Controllers
{
    public class Cal : Controller
    {
       
        private readonly AddService _add;
        private readonly SubService _sub;
        private readonly MulService _mul;
        private readonly DivService _div;

        public Cal(AddService add, SubService sub, MulService mul, DivService div)
        {
            _add = add;
            _sub = sub;
            _mul = mul;
            _div = div;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(double a, double b, double? c , double? d , string op)
        {
            string result= "";

            if (op == "add")
            {
                if (c.HasValue && d.HasValue) { result = _add.Cal(a, b, c.Value, d.Value); }

                else if (c.HasValue) { result = _add.Cal(a, b, c.Value); }

                else { result = _add.Cal(a, b); }
            }
            else if (op == "sub")
            {
                if (c.HasValue && d.HasValue) { result = _sub.Cal(a, b, c.Value, d.Value); }

                else if (c.HasValue) { result = _sub.Cal(a, b, c.Value); }

                else { result = _sub.Cal(a, b); }
            } 
            else if (op == "mul")
            {
                if (c.HasValue && d.HasValue) { result = _mul.Cal(a, b, c.Value, d.Value); }

                else if (c.HasValue) { result = _mul.Cal(a, b, c.Value); }

                else { result = _mul.Cal(a, b); }
            }
            else if (op == "div")
            {
                if (c.HasValue && d.HasValue) { result = _div.Cal(a, b, c.Value, d.Value); }

                else if (c.HasValue) { result = _div.Cal(a, b, c.Value); }

                else { result = _div.Cal(a, b); }
            }

            ViewBag.Result = result;
            return View("Index");
        }

    }
}



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

