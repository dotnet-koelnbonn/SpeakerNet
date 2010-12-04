using System.Collections.Generic;
using AutoMapper;

namespace SpeakerNet.Extensions
{
    public static class MappingHelper
    {
        public static IEnumerable<TDestination>
            MapFrom<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }

        public static TDestination MapFrom<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public static void MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }
    }
}