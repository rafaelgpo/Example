using Example.Domain.Events.Interface;
using Example.Domain.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.Events.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T theEvent) where T : ValidationMessage
        {
            return Publish(theEvent);
        }

        private Task Publish<T>(T message) where T : ValidationMessage
        {
            return _mediator.Publish(message);
        }

    }
}
