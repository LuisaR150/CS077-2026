using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloInvestigation
{
    public class Greeting
    {
        public string Name { get; set; } = "runner";
        public string BuildMessage()
        {
            return $"Hello, {Name}!";
        }
    }
}