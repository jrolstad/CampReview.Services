namespace CampReview.Core.Commands
{
    public interface ICommand<in Tin, out Tout>
    {
        Tout Execute( Tin request );
    }
}