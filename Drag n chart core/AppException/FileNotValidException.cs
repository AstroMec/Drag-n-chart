using System;
using System.Collections.Generic;
using System.Text;

namespace Drag_n_chart_core.AppException
{
    public class FileNotValidException : ApplicationException
    {
        public FileNotValidException()
            : base()
        {
        }

        public FileNotValidException(string message)
            : base(message)
        {
        }

        public FileNotValidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
