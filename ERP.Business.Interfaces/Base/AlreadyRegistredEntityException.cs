#region Using

using System;
using System.Runtime.Serialization;

#endregion

namespace ERP.Business.Interfaces.Base
{
    [Serializable]
    public class AlreadyRegistredEntityException : Exception, ISerializable
    {
        public AlreadyRegistredEntityException()
        {
        }
        
        public AlreadyRegistredEntityException(string message)
            :base(message)
        {
        }

        public AlreadyRegistredEntityException(string message, Exception innerException)
            :base(message, innerException)
        {
        }

        public object ItemAtDatabase { get; set; }

        protected AlreadyRegistredEntityException(SerializationInfo info, StreamingContext context)
            :base(info, context)
        {
            ItemAtDatabase = info.GetValue("baseValue", typeof(object));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ItemAtDatabase", ItemAtDatabase);
            base.GetObjectData(info, context);
        }
    }
}