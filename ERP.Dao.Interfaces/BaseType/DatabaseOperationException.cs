using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Interfaces.BaseType
{
    public class DatabaseOperationException : Exception
    {
        public DatabaseOperationException(String message)
            : base(message)
        {

        }

        public DatabaseOperationException(String message, DatabaseOperationException ex)
            : base(message, ex)
        {

        }
    }
}
