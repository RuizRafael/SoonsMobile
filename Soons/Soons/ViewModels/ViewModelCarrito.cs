using Soons.Base;
using Soons.Models;
using Soons.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Soons.ViewModels
{
    public class ViewModelCarrito: ViewModelBase
    {
        ServiceSoons ServiceSoons;

        private ObservableCollection<Prod> _Productos;
        private Order _Pedido;
        private ObservableCollection<ProdOrder> _ProductosPedidos;

        public ObservableCollection<Prod> Productos
        {
            get { return this._Productos; }
            set
            {
                this._Productos = value;
                OnPropertyChanged("Productos");
            }
        }

        public Order Pedido
        {
            get { return this._Pedido; }
            set
            {
                this._Peido = value;
                OnPropertyChanged("Pedido");
            }
        }

        public ObservableCollection<ProdOrder> ProductosPedidos
        {
            get { return this._ProductosPedidos; }
            set
            {
                this._ProductosPedidos = value;
                OnPropertyChanged("ProductosPedidos");
            }
        }

        public ViewModelCarrito(ServiceSoons serviceSoons)
        {
            ServiceSoons = serviceSoons;
            Task.Run(async () =>
            {
                await
            });
        }


    }
}
