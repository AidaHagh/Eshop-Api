using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg
{
    public class ProductSpecification : BaseEntity
    {
        public ProductSpecification( string key, string value)
        {
            NullOrEmptyDomainDataException.CheckString(value, nameof(value));   
            NullOrEmptyDomainDataException.CheckString(key, nameof(key));
            Key = key;
            Value = value;
        }

        public long ProductId { get;internal set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

    }
}
