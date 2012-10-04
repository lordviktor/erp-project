#region Using

using System;
using ERP.Domain.Audit;
using NHibernate.Envers.Configuration.Attributes;

#endregion

namespace ERP.Dao.Nhibernate.Audit
{
    /// <summary>
    /// Classe proxy com a finalidade de decorar os parametros identidade de versionamento 
    /// de maneira a nao distribuir dependencias do nhibernate por toda a solucao.
    /// </summary>
    public class RevisionInfoProxy : RevisionInfo
    {
        [RevisionNumber]
        public override long Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        [RevisionTimestamp]
        public override DateTime Timestamp
        {
            get { return base.Timestamp; }
            set { base.Timestamp = value; }
        }
    }
}