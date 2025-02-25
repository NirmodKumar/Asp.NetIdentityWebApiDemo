﻿using FluentEmail.Core;

namespace IdentityDemoApi.EmailHelper
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IFluentEmailFactory _fluentEmailFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="fluentEmailFactory">The fluent email factory.</param>
        public EmailService(ILogger<EmailService> logger, IFluentEmailFactory fluentEmailFactory)
        {
            _logger = logger;
            _fluentEmailFactory = fluentEmailFactory;
        }

        /// <summary>
        /// Sends the specified email message model.
        /// </summary>
        /// <param name="emailMessageModel">The email message model.</param>
        public async Task Send(EmailMessageModel emailMessageModel)
        {
            _logger.LogInformation("Sending email");
            await _fluentEmailFactory.Create().To(emailMessageModel.ToAddress)
                .Subject(emailMessageModel.Subject)
                .Body(emailMessageModel.Body, true) // true means this is an HTML format message
                .SendAsync();
        }
    }

    public interface IEmailService
    {
        /// <summary>
        /// Send an email.
        /// </summary>
        /// <param name="emailMessage">Message object to be sent</param>
        Task Send(EmailMessageModel emailMessage);
    }

    public class EmailMessageModel
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string? Body { get; set; }
        public string? AttachmentPath { get; set; }
        public EmailMessageModel(string toAddress, string subject, string? body = "")
        {
            ToAddress = toAddress;
            Subject = subject;
            Body = body;
        }
    }
}