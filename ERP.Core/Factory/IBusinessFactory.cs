using ERP.Business.Interfaces.Base;

namespace ERP.Core.Factory
{
    public interface IBusinessFactory
    {
        T GetReference<T>() where T : ILogic;
    }
}