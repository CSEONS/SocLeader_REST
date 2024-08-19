namespace SocLeader_REST.Domain.Repositories.Abstract
{
    public interface IImageHandlerRepository
    {
        string Upload(IFormFile[] formFiles);
        void Delete(string url);
    }
}
