using Example.Domain.Events.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Events.Bus
{
    public sealed class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(typeof(IDomainNotificationHandler<T>));

            ((IHandler<T>)obj).Handle(message);

        }

        private object GetService(Type serviceType)
        {
            return Container.GetService(serviceType);
        }

        private T GetService<T>()
        {
            return (T)Container.GetService(typeof(T));
        }
    }
}
