using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Exceptions
{
    public class UserIsNullException : Exception
    {
        public UserIsNullException() { }

        public UserIsNullException(long id)
            : base(String.Format("User is null TID : {0}", id))
        {

        }
    }
}
