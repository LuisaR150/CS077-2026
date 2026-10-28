using System;
using System.Collections.Generic;
using System.Text;

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