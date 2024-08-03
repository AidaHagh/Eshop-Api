using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class IsExistDataException : InvalidDomainDataException
    {
        public IsExistDataException()
        {

        }
        public IsExistDataException(string message) : base(message)
        {

        }
    }
}
