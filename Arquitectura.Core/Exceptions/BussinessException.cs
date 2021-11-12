using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Arquitectura.Core.Exceptions
{
    [Serializable]
    public class BussinessException : Exception
    {
        private readonly string resourceName;
        private readonly List<string> validationErrors;

        public BussinessException(string resourceName, List<string> validationErrors)
        {
            this.resourceName = resourceName;
            this.validationErrors = validationErrors;
        }

        public string ResourceName
        {
            get { return this.resourceName; }
        }

        public List<string> ValidationErrors
        {
            get { return this.validationErrors; }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected BussinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.resourceName = info.GetString("MyException.ResourceName");
            this.validationErrors = (List<string>)(List<string>)info.GetValue("MyException.ValidationErrors", typeof(List<string>));
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("MyException.ResourceName", this.ResourceName);

            // Note: if "List<T>" isn't serializable you may need to work out another
            //       method of adding your list, this is just for show...
            info.AddValue("MyException.ValidationErrors", this.ValidationErrors, typeof(IList<string>));
        }
    }
}
