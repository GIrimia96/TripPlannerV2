using Autofac;
using AutoMapper;
using Common.AutoMapper;
using Cqrs.Service;
using Cqrs.Service.CommandContracts;
using Cqrs.Service.CommandHandlers;
using Cqrs.Service.QueryContracts;
using Cqrs.Service.QueryHandlers;
using Persistency.Implementations;
using Repositories.Contracts;
using Repositories.Implementations;
using System.Collections.Generic;
using static System.Reflection.IntrospectionExtensions;

namespace Common
{
    public class CqrsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistencyImplementationsAutofacModule>();
            builder.RegisterModule<RepositoryImplementationsAutofacModule>();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>();

            builder.RegisterType<QueryDispatcher>()
                .As<IQueryDispatcher>();

            builder.RegisterAssemblyTypes(typeof(BusinessLayer).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("QueryResult")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(BusinessLayer).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Command")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(BusinessLayer).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Query")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(BusinessLayer).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(BusinessLayer).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(BaseRepository<>))
               .As(typeof(IBaseRepository<>));

            builder.RegisterAssemblyTypes().AssignableTo(typeof(LocationMapper));

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            //builder.RegisterType<UserService>()
            //    .As<IUserService>();

        }
    }
}
