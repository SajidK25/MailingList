using System;
using Autofac;
using MailingList.Core.Contexts;
using MailingList.Core.Repositories;
using MailingList.Core.Services;
using MailingList.Core.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace MailingList.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public CoreModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<EventContext>().As<IEventContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<EventUnitOfWork>().As<IEventUnitOfWork>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<EventRepository>().As<IEventRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EventService>().As<IEventService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerEventRepository>().As<ICustomerEventRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventService>().As<ICustomerEventService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
