using System;
using Bookfy.Domain.Abstractions;
using Bookify.Application.Abstractions.Messaging;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand { }

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse> { }
