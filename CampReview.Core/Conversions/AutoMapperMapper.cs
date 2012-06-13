using AutoMapper;

namespace CampReview.Core.Conversions
{
    /// <summary>
    /// Mapper implementation using AutoMapper's default mapping
    /// </summary>
    /// <typeparam name="Tin">Convert from</typeparam>
    /// <typeparam name="Tout">Convert to</typeparam>
    public class AutoMapperMapper<Tin, Tout>:IMapper<Tin, Tout>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <remarks>
        /// This is where the map is created
        /// </remarks>
        public AutoMapperMapper()
        {
            Mapper.CreateMap<Tin, Tout>();
        }

        /// <summary>
        /// Maps from one type to another
        /// </summary>
        /// <param name="from">Item to map from</param>
        /// <returns></returns>
        public Tout Map( Tin from )
        {
            var result = Mapper.Map<Tout>(from);

            return result;
        }
    }
}