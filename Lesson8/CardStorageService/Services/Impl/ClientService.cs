using CardStorageService.Data;
using ClientServiceProtos;
using Grpc.Core;
using static ClientServiceProtos.ClientService;

namespace CardStorageService.Services.Impl
{
    public class ClientService : ClientServiceBase
    {
		private readonly IClientRepositoryService _clientRepositoryService;
		private readonly ILogger<ClientService> _logger;

		public ClientService(ILogger<ClientService> logger,
			IClientRepositoryService clientRepositoryService)

		{
			_logger = logger;
			_clientRepositoryService = clientRepositoryService;
		}

		public override Task<CreateClientResponse> Create(CreateClientRequest request, ServerCallContext context)
		{
            try
            {
                var clientId = _clientRepositoryService.Create(new Client
                {
                    FirstName = request.FirstName,
                    Surname = request.Surname,
                    Patronymic = request.Patronymic
                });
                
                var responce = new CreateClientResponse
                {
                    ClientId = clientId,
                    ErrorCode = 0,
                    ErrorMessage = String.Empty
                };

                return Task.FromResult(responce);

            } catch (Exception e)
            {
                _logger.LogError(e, "Create client error.");

                var responce = new CreateClientResponse
                {
                    ClientId = -1,
                    ErrorCode = 912,
                    ErrorMessage = "Create client error."
                };

                return Task.FromResult(responce);
            }
		}
	}
}
