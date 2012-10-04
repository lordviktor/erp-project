namespace ERP.Domain.BasicEntity
{
    public class BaseMultiTenancyEntity : BaseLogicExclusionEntity
    {
        public Company TenancyCompany { get; set; }
    }
}