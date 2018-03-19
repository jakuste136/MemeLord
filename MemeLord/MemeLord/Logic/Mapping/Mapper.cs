using AutoMapper;

namespace MemeLord.Logic.Mapping
{
    public interface IMapper<in TSource, out TDest>
    {
        TDest Map(TSource source);
    }

    public class Mapper<TSource, TDest> : IMapper<TSource, TDest>
    {
        private readonly IMapper _mapper;

        public Mapper()
        {
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>()).CreateMapper();
        }

        public TDest Map(TSource source)
        {
            return _mapper.Map<TDest>(source);
        }
    }
}