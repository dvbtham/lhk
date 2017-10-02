using System;
using System.Runtime.Serialization;

namespace LeHuuKhoa.Core.Utilities.ExcelManager
{
    [Serializable]
    public class WorkSheetNotFoundException : Exception
    {
        public WorkSheetNotFoundException()
        {
        }

        public WorkSheetNotFoundException(string message) : base(message)
        {
        }

        public WorkSheetNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WorkSheetNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}