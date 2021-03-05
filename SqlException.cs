using System;
using System.Collections.Generic;
using System.Text;

namespace Database_gui_test
{
    class SqlException : Exception
    {
        public SqlException(string message) : base(message)
        {
           
        }
    }
}
