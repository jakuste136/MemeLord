using AutoMapper;

namespace MemeLord.Logic.Mapping
{
    public interface IMapper<in TSource, out TDest>
    {
        TDest Map(TSource source);
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
    }
}