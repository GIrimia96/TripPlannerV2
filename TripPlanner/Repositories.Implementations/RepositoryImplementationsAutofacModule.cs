using System.Reflection;
using Autofac;
using Repositories.Implementations;
using Module = Autofac.Module;

namespace Repositories.Implementations
{
    /// <summary>
    /// The repositories registration module.
    /// </summary>
    /// <seealso cref="System.Reflection.Module" />
    public class RepositoryImplementationsAutofacModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(RepositoriesImplementation).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            //builder.RegisterGeneric(typeof(LogicalDeleteRepository<>))
            //    .AsImplementedInterfaces();
            //builder.RegisterGeneric(typeof(BaseRepository<>))
            //    .AsImplementedInterfaces();
            //builder.RegisterGeneric(typeof(BasePhysicalDeletableEntitiesRepository<>))
            //    .AsImplementedInterfaces();
        }
    }
}
