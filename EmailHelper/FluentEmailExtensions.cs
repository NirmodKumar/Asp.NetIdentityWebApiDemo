using System.Net.Mail;
using FluentEmail.Core.Interfaces;
using FluentEmail.Smtp;

namespace IdentityDemoApi.EmailHelper
{
    public static class FluentEmailExtensions
    {
        /// <summary>
        /// Adds the fluent email.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddFluentEmail(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var emailSettings = configuration.GetSection("EmailSettings");
            var defaultFromEmail = emailSettings["DefaultFromEmail"];
            var host = emailSettings["Host"];
            var port = emailSettings.GetValue<int>("Port");
            services.AddFluentEmail(defaultFromEmail);
            services.AddSingleton<ISender>(x => new SmtpSender(new SmtpClient(host, port))); // I'm using dev mode using 'smtp4dev' hence i'm only using host and port
        }
    }
}