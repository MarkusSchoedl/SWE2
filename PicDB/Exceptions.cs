using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PicDB
{
    class CouldntOpenDbException : Exception
    {
        public CouldntOpenDbException()
        {
        }

        public CouldntOpenDbException(string message) : base(message)
        {
        }

        public CouldntOpenDbException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CouldntOpenDbException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    class CouldntConnectToDBException : Exception
    {
        public CouldntConnectToDBException()
        {
        }

        public CouldntConnectToDBException(string message) : base(message)
        {
        }

        public CouldntConnectToDBException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CouldntConnectToDBException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
