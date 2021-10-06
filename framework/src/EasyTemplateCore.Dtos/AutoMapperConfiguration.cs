using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace EasyTemplateCore.Dtos
{
    /// <summary>
    /// AutoMapper configuration
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper { get; private set; }

        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration { get; private set; }

        /// <summary>
        /// Initialize mapper
        /// </summary>
        /// <param name="config">Mapper configuration</param>
        public static void Init(MapperConfiguration config)
        {
            MapperConfiguration = config;
            Mapper = config.CreateMapper();
        }

        public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source)
        {
            return source.ProjectTo<TDestination>(MapperConfiguration);
        }

    }
}
