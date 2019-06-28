using System;

namespace Francis.ToolBox.Common.Exceptions
{
    public class UnknownDbTypeException : Exception
    {
        private const string DEFAULT_MESSAGE = "Unknow database type";

        public UnknownDbTypeException() : base(DEFAULT_MESSAGE)
        {

        }
    }
}
