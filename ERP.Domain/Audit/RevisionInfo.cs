#region Using

using System;

#endregion

namespace ERP.Domain.Audit
{
    public class RevisionInfo
    {
        public virtual long Id { get; set; }

        public virtual DateTime Timestamp { get; set; }

        public virtual String User { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as RevisionInfo;
            if (t == null)
                return false;
            return t.Id == Id && t.Timestamp.Equals(Timestamp);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Timestamp.GetHashCode();
        }
    }
}