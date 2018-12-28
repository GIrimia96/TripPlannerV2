using System;
using Autofac;
using Cqrs.Service.CommandContracts;

namespace Cqrs.Service.CommandHandlers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Execute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = _componentContext.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            handler.Execute(command);
        }
    }
}