using System;
using System.Collections.Generic;
using System.Text;

namespace VectorMath
{
    public class DimensionException : System.Exception
    {
        public DimensionException() : base() { }
        public DimensionException(string message) : base(message) { }
        public DimensionException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected DimensionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}