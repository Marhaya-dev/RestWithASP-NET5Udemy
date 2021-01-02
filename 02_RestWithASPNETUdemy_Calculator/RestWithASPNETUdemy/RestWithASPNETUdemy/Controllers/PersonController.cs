using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("math/{firstNumber}/{secondNumber}")]
        public IActionResult Calculator(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                var mul = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                var med = (ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber))/2;

                return Ok(
                          "Soma: " + sum.ToString() + "\n" +
                          "Subtração: " + sub.ToString() + "\n" +
                          "Multiplicação: " + mul.ToString() + "\n"  +
                          "Divisão: " + div.ToString() + "\n" +
                          "Média: " + med.ToString()
                          );
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("squareRoot/{firstNumber}")]

        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));

                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid Input");
        }
        private bool IsNumeric(string strtNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strtNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}