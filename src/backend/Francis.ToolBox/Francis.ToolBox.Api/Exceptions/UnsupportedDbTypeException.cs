using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Francis.ToolBox.Api.Exceptions
{
    public class UnsupportedDbTypeException : Exception
    {
        private const string DEFAULT_MESSAGE = "Unsupported database type";

        public UnsupportedDbTypeException() : base(DEFAULT_MESSAGE)
        {

        }
    }
}
