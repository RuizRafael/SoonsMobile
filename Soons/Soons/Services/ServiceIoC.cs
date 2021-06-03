using Autofac;
using Soons.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soons.Services
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ServiceSoons>();
            builder.RegisterType<ViewModelCrearCuenta>();
            builder.RegisterType<ViewModelDetails>();
            builder.RegisterType<ViewModelPagado>();
            builder.RegisterType<ViewModelPaginaPago>();
            builder.RegisterType<ViewModelScanner>();
            builder.RegisterType<ViewModelTracking>();
            this.container = builder.Build();
        }

        public ServiceSoons ServiceSoons {
            get {
                return this.container.Resolve<ServiceSoons>();
            }
        }
        public ViewModelCrearCuenta ViewModelCrearCuenta {
            get {
                return this.container.Resolve<ViewModelCrearCuenta>();
            }
        }
        public ViewModelDetails ViewModelDetails {
            get {
                return this.container.Resolve<ViewModelDetails>();
            }
        }
        public ViewModelPagado ViewModelPagado {
            get {
                return this.container.Resolve<ViewModelPagado>();
            }
        }
        public ViewModelPaginaPago ViewModelPaginaPago {
            get {
                return this.container.Resolve<ViewModelPaginaPago>();
            }
        }
        public ViewModelScanner ViewModelScanner {
            get {
                return this.container.Resolve<ViewModelScanner>();
            }
        }
        public ViewModelTracking ViewModelTracking {
            get {
                return this.container.Resolve<ViewModelTracking>();
            }
        }
    }
}
