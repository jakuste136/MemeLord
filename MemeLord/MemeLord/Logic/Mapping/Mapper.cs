using AutoMapper;
using System.Collections.Generic;
using System;

namespace MemeLord.Logic.Mapping
{
    public interface IMapper<in TSource, out TDest>
    {
        TDest Map(TSource source);
        IEnumerable<TDest> MapList(IEnumerable<TSource> sourceItemsList);
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

        public virtual IMappingExpression<TSource, TDest> CreateMap(IMapperConfigurationExpression cfg)
        {
            return cfg.CreateMap<TSource, TDest>();
        }

        public IEnumerable<TDest> MapList(IEnumerable<TSource> sourceItemsList)
        {
            var destinationItemsList = new List<TDest>();
            foreach(var sourceItem in sourceItemsList)
            {
                destinationItemsList.Add(Map(sourceItem));
            }
            return destinationItemsList;
        }
    }
}