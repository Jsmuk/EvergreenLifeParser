using System;
using System.Collections.Generic;

namespace EvergreenLifeParser
{
    public class Result
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Units { get; set; }
        public string ValueMin { get; set; }
        public string ValueMax { get; set; }
        public List<Result> InnerResults { get; set; }
        public string Comment { get; set; }
    }
}
