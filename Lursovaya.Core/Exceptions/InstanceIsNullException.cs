using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Exceptions
{
    public class InstanceIsNullException : Exception
    {
        public InstanceIsNullException() { }

        public InstanceIsNullException(string type)
            : base(String.Format("Instance is null TYPE: {0}", type))
        {
        }
    }
}
