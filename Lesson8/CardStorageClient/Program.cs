using Grpc.Net.Client;
using static ClientServiceProtos.ClientService;

namespace CardStorageClient
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Создать клиента ...");
			Console.ReadLine();

			using (GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001"))
			{
				ClientServiceClient client = new ClientServiceClient(channel);

				var responce = client.Create(new ClientServiceProtos.CreateClientRequest
				{
					FirstName = "Станислав",
					Surname = "Байраковский",
					Patronymic = "Антонович"
				});

				Console.WriteLine($"ClientId: {responce.ClientId}; ErrCode: {responce.ErrorCode}; ErrMessage: {responce.ErrorMessage}");
			}
		}
	}
}