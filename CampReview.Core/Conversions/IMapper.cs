namespace CampReview.Core.Conversions
{
    public interface IMapper<in Tin, out Tout>
    {
        Tout Map( Tin from );
    }
}