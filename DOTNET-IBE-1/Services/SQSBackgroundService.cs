using Amazon.SQS.Model;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models;
using DOTNET_IBE_1.Services.ClientService.cs;
using System.Text.Json;
using System.Threading;

namespace DOTNET_IBE_1.Services
{
    /// <summary>
    /// A background service that will listen to the messages of sqs queue
    /// </summary>
    public class SQSBackgroundService : BackgroundService
    {
        private readonly SQSClientService _sqsServiceClient;
        private readonly IServiceProvider _serviceProvider;

        public SQSBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _sqsServiceClient = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<SQSClientService>();
        }

        /// <summary>
        /// Contains the main logic of the BackgroundService, receives the cancellation token that 
        /// is used to stop the exceution of the service
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            await StartListeningAsync(cancellationTokenSource.Token);
        }

        /// <summary>
        /// listens the message of queue and sends to a create booking function
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartListeningAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _serviceProvider.CreateScope();
            IBookingService _bookingService = scope.ServiceProvider.GetRequiredService<IBookingService>();
            while (true)
            {
                var receiveRequest = new ReceiveMessageRequest
                {
                    QueueUrl = _sqsServiceClient.GetQueueUrl(),
                };
                var response = await _sqsServiceClient.GetAmazonSQSClient()
                    .ReceiveMessageAsync(receiveRequest, cancellationToken);
                foreach (var message in response.Messages)
                {
                    bool bookingCreated = _bookingService.CreateBooking(message.Body);
                    //delete the message if booking is created successfully
                    if (bookingCreated)
                    {
                        await DeleteMessageAsync(message.ReceiptHandle);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the queue message
        /// </summary>
        /// <param name="receiptHandle"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task DeleteMessageAsync(string receiptHandle, CancellationToken cancellationToken = default)
        {
            var deleteRequest = new DeleteMessageRequest
            {
                QueueUrl = _sqsServiceClient.GetQueueUrl(),
                ReceiptHandle = receiptHandle
            };
            await _sqsServiceClient.GetAmazonSQSClient().DeleteMessageAsync(deleteRequest, cancellationToken);
        }
    }
}


