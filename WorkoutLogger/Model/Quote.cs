using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutLogger.Model
{
    public class Quote
    {
        public string QUOTE { get; private set;}
        public string AUTHOR { get; private set;}

        public Quote(string quote, string author)
        {
            QUOTE = quote;
            AUTHOR = author;
        }
    }
}