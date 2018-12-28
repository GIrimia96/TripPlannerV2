using System;

namespace Cqrs.Service.Exceptions
{
    public class GeneralBusinessException : Exception
    {
        public GeneralBusinessException(string message)
            : base(message)
        {
        }
    }
}
