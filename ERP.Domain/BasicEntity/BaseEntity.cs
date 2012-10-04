#region Using

using System;
using System.Reflection;

#endregion

namespace ERP.Domain.BasicEntity
{
    public abstract class BaseEntity
    {
        protected static readonly String ClassName;

        public Guid Id { get; set; }

        static BaseEntity()
        {
            ClassName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as BaseEntity;
            if (t == null)
                return false;
            return t.Id == Id;
        }

        public override string ToString()
        {
            return String.Format("{0} Id:{1}", GetType().Name, Id);
        }

        public override int GetHashCode()
        {
            return (ClassName + "|" + Id).GetHashCode();
        }
    }
}