using System;
using Bookify.Domain.Users;

namespace Bookify.Application.Abstractions.Mail;

public interface IEmailService
{
    Task SendAsync(Email recipient, string subject, string body);

}
