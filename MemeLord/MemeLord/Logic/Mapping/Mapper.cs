using AutoMapper;
using System.Collections.Generic;
using System;

namespace MemeLord.Logic.Mapping
{
    public interface IMapper<TSource, TDest>
    {
        TDest Map(TSource source);
        IList<TDest> Map(IList<TSource> sourceItemsList);
    }

    public class Mapper<TSource, TDest> : IMapper<TSource, TDest>
    {
        protected IMapper MapperInstance;

        public Mapper()
        {
            MapperInstance = new MapperConfiguration(cfg => CreateMap(cfg)).CreateMapper();
        }

        public TDest Map(TSource source)
        {
            return MapperInstance.Map<TDest>(source);
        }

        public IList<TDest> Map(IList<TSource> sourceItemsList)
        {
            return MapperInstance.Map<IList<TDest>>(sourceItemsList);
        }

        public virtual IMappingExpression<TSource, TDest> CreateMap(IMapperConfigurationExpression cfg)
        {
            return cfg.CreateMap<TSource, TDest>();
        }
    }
}