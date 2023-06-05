using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SQS;
using Amazon.SQS.Model;
using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Models.ResponseModels;
using Newtonsoft.Json;

namespace DOTNET_IBE_1.Services.ClientService.cs
{
    public class SQSClientService
    {
        private readonly IAmazonSQS _amazonSQS;
        private readonly IConfiguration _configuration;
        private readonly string _sqsQueueUrl;

        
        /// <summary>
        /// Makes the amazon sqs client using the aws credentials profile
        /// </summary>
        /// <param name="configuration"></param>
        /// <exception cref="CredentialsException"></exception>
        public SQSClientService(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqsQueueUrl = _configuration["AWS:SQSQueueUrl"];
            var sharedFile = new SharedCredentialsFile();
            if (sharedFile.TryGetProfile(_configuration["AWS:Profile"], out var profile))
            {
                var awsCredentials = AWSCredentialsFactory.GetAWSCredentials(profile, sharedFile);
                var awsConfig = new AmazonSQSConfig 
                { RegionEndpoint = RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]) };
                _amazonSQS = new AmazonSQSClient(awsCredentials, awsConfig);
            }
            else
            {
                var awsConfig = new AmazonSQSConfig
                { RegionEndpoint = RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]) };
                _amazonSQS = new AmazonSQSClient(awsConfig);
                //throw new CredentialsException(ExceptionMessages.NULL_CREDENTIALS);
            }
        }
        /// <summary>
        /// Sends the booking message to sqs queue
        /// </summary>
        /// <param name="queueBookingRequest"></param>
        /// <returns>booking id if push booking is successful</returns>
        /// <exception cref="SQSException"></exception>
        public async Task<QueueBookingResponseModel> SendMessageToSQS(QueueBookingRequestModel queueBookingRequest)
        {
            string messageBody = JsonConvert.SerializeObject(queueBookingRequest);
            Random random = new Random();
            string randomString = random.Next(100000, 999999).ToString();
            var request = new SendMessageRequest
            {
                QueueUrl = _sqsQueueUrl,
                MessageBody = messageBody,
                MessageGroupId = randomString
            };
            var response = await _amazonSQS.SendMessageAsync(request);
            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new SQSException(ExceptionMessages.SQS_MESSAGE_SENT_FAILED);
            }
            else
            {
                QueueBookingResponseModel queueBookingResponse = new QueueBookingResponseModel();
                queueBookingResponse.BookingId = queueBookingRequest.BookingId;
                return queueBookingResponse;
            }
        }

        public IAmazonSQS GetAmazonSQSClient()
        {
            return _amazonSQS;
        }
        public string GetQueueUrl()
        {
            return _sqsQueueUrl;
        }
    }
}
