using System;
using System.Collections.Generic;
using System.Text;

namespace Drag_n_chart_core.AppException
{
	public class ExtensionException : ApplicationException
	{
		public ExtensionException()
			: base()
        {
        }

		public ExtensionException(string message)
			: base(message)
        {
        }

		public ExtensionException(string message, Exception inner)
			: base(message, inner)
        {
        }
	}
}
