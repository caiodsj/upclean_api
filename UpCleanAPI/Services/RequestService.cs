
using Microsoft.EntityFrameworkCore;
using UpCleanAPI.Data;

namespace UpCleanAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly DataContext _context;

        public RequestService(DataContext context)
        {
            _context = context;
        }

        public async Task<Request> CreateRequest(RequestCreateDTO request)
        {
            var requestModel = new Request
            {
                IdClient = request.IdClient,
                DeliveryDateTime = request.DeliveryDateTime,
                Services = new List<AmountService>(),
                TotalPrice = request.TotalPrice
            };

            foreach (var amountService in request.Services)
            {
                var service = await _context.Services.FindAsync(amountService.IdService);

                if (service != null)
                {
                    requestModel.Services.Add(amountService);

                    requestModel.TotalPrice += service.Price * amountService.Amount;
                }
            }

            await _context.Requests.AddAsync(requestModel);
            await _context.SaveChangesAsync();

            return requestModel;

        }

        public async Task DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if(request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Request> GetRequestById(int id)
        {
            return await _context.Requests.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Request> UpdateRequest(int id, RequestUpdateDTO request)
        {
            var requestModel = await _context.Requests
                .Include(r => r.Services)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (requestModel != null)
            {
                requestModel.DeliveryDateTime = request.DeliveryDateTime;

                if (request.Services != null && request.Services.Any())
                {
                    foreach (var amountService in request.Services)
                    {
                        var service = await _context.Services.FindAsync(amountService.IdService);

                        if (service != null)
                        {
                            var existingAmountService = requestModel.Services.FirstOrDefault(s => s.IdService == amountService.IdService);

                            if (existingAmountService != null)
                            {
                                existingAmountService.Amount = amountService.Amount;
                            }
                            else
                            {
                                requestModel.Services.Add(amountService);
                            }
                        }
                    }
                }
                requestModel.TotalPrice = CalculateTotalPrice(requestModel.Services);

                await _context.SaveChangesAsync();
            }

            return requestModel;
        }

        private decimal CalculateTotalPrice(List<AmountService> services)
        {
            decimal totalPrice = 0;

            foreach (var amountService in services)
            {
                var service = _context.Services.FirstOrDefault(s => s.Id == amountService.IdService);
                if (service != null)
                {
                    totalPrice += service.Price * amountService.Amount;
                }
            }

            return totalPrice;
        }

    }
}
