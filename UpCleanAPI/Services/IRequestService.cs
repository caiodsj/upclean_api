namespace UpCleanAPI.Services
{
    public interface IRequestService
    {
        Task<Request> GetRequestById(int id);
        Task<Request> CreateRequest(RequestCreateDTO request);
        Task<Request> UpdateRequest(int id, RequestUpdateDTO request);
        Task DeleteRequest(int id);
    }
}
