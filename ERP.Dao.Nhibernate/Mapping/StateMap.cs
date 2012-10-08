using ERP.Dao.Nhibernate.Util;
using ERP.Domain;
using ERP.Domain.BasicEntity;
using ERP.Domain.SubEntity;
using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Mapping
{
    public abstract class BaseEntityMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Custom<GuidCustomId>();
        }
    }

    public abstract class BaseLogicExclusionEntity<T> : BaseEntityMap<T> where T : BaseLogicExclusionEntity
    {
        public BaseLogicExclusionEntity()
        {
            Map(x => x.Excluded);
        }
    }

    public class EmailMap : BaseEntityMap<Email>
    {
        public EmailMap()
        {
            Map(x => x.EmailAddress);
        }
    }

    public class PhoneMap : BaseEntityMap<Phone>
    {
        public PhoneMap()
        {
            Map(x => x.AreaCode);
            Map(x => x.Number);
        }
    }


    public class StateMap : BaseEntityMap<State>
    {
        public StateMap()
        {
            Map(x => x.Name);

            HasMany<City>(x => x.Cities)
                .Inverse()
                .AsBag()
                .Fetch.Select()
                .Cascade.All();
        }
    }

    public class CityMap : BaseEntityMap<City>
    {
        public CityMap()
        {
            Map(x => x.Name);

            References<State>(x => x.State);

            HasMany<Neighborhood>(x => x.Neighborhoods)
                .Fetch.Select()
                .Cascade.All();
        }
    }

    public class NeighborhoodMap : BaseEntityMap<Neighborhood>
    {
        public NeighborhoodMap()
        {
            Map(x => x.Name);

            //References(x => x.City);
        }
    }

    public class AddressMap : BaseEntityMap<Address>
    {
        public AddressMap()
        {
            Map(x => x.Street);
            Map(X => X.Number).Nullable();
            Map(x => x.Complement);

            //References<Neighborhood>(X => X.Neighborhood);
        }
    }


    public class LegalPersonDetailMap : BaseEntityMap<LegalPersonDetail>
    {
        public LegalPersonDetailMap()
        {
            Map(x => x.CompanyName);
            Map(x => x.TradingName);
            Map(x => x.IE);

            Component(x => x.Cnpj,
                m =>
                {
                    m.Map(x => x.CheckNumber);
                    m.Map(x => x.Root);
                    m.Map(x => x.Suffix);
                });
        }
    }

    public class NaturalPersoDetailMap : BaseEntityMap<NaturalPersonDetail>
    {
        public NaturalPersoDetailMap()
        {
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Rg);
            Map(x => x.BirthDate);
        }
    }


}
