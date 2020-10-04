using Autofac;
using Template.Infrastructure;

namespace Template.API.Initializers
{
    public class RepositoryModule : Autofac.Module 
    {
        public RepositoryModule() {}

        protected override void Load(ContainerBuilder builder)
        {  
            builder.RegisterType<TemplateEntityRepository>()
                .As<ITemplateEntityRepository>()
                .InstancePerLifetimeScope();
        }
    }
}