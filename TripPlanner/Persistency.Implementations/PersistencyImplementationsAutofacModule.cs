using Autofac;
using Persistency.Mappings;
using static System.Reflection.IntrospectionExtensions;

namespace Persistency.Implementations
{
    /// <summary>
    /// The Autofac module class for the PersistencyImplementations project.
    /// It is inherited from Module.
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class PersistencyImplementationsAutofacModule : Module
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
            builder.RegisterAssemblyTypes(typeof(PersinstencyMappings).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Mapping")).AsImplementedInterfaces();
        }
    }
}
