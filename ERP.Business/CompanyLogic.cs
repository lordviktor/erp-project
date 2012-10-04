#region Using

using ERP.Business.Interfaces;
using ERP.Core.Metadata;
using ERP.Domain;
using ERP.Business.Base;
using ERP.Dao.Interfaces;

#endregion

namespace ERP.Business
{
    [BusinessExport(typeof(ICompanyLogic), BusinessModule.Register)]
    public class CompanyLogic : BaseLogicExclusionCrud<Company>, ICompanyLogic
    {
        public CompanyLogic()
            : base(null)
        {
        }

        public CompanyLogic(ICompanyDao repository)
            : base(repository)
        {

        }
    }
}