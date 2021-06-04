using Soons.Base;
using Soons.Models;
using Soons.Services;
using Soons.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Soons.ViewModels
{
    public class ViewModelCarrito : ViewModelBase
    {
        ServiceSoons ServiceSoons;
        ZXingScannerPage scanPage;

        private ObservableCollection<Prod> _Productos;
        private Order _Pedido;
        private ObservableCollection<ProdsOrder> _ProductosPedidos;
        private bool _FilledCart;
        private bool _NoFilledCart;

        public bool FilledCart
        {
            get
            {
                return this._FilledCart;
            }
            set
            {
                this._FilledCart = value;
                OnPropertyChanged("FilledCart");
            }
        }

        public bool NoFilledCart
        {
            get
            {
                return this._NoFilledCart;
            }
            set
            {
                this._NoFilledCart = value;
                OnPropertyChanged("NoFilledCart");
            }
        }


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
                this._Pedido = value;
                OnPropertyChanged("Pedido");
            }
        }

        public ObservableCollection<ProdsOrder> ProductosPedidos
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
                await this.GetOrder();
            });
        }

        public async Task GetOrder()
        {
            if (Pedido != null)
            {
                this.Pedido = await this.ServiceSoons.getPedidoByOrderNumber(Pedido.OrderNumber);
                this.ProductosPedidos = new ObservableCollection<ProdsOrder>(await this.ServiceSoons.getProductosPedido(this.Pedido.Id));
                this.Productos = new ObservableCollection<Prod>(await this.ServiceSoons.getProductosSoloDelPedido(new List<ProdsOrder>(this.ProductosPedidos)));
                this.FilledCart = ProductosPedidos.Count != 0;
                this.NoFilledCart = !this.FilledCart;
            }
            else
            {
                this.Pedido = new Order();
                this.ProductosPedidos = new ObservableCollection<ProdsOrder>();
                this.Productos = new ObservableCollection<Prod>();
                this.FilledCart = ProductosPedidos.Count != 0;
                this.NoFilledCart = !this.FilledCart;
            }
        }

        public Command CerrarPedido
        {
            get
            {
                return new Command(async () =>
                {
                    // hay que cambiar el estado del pedido
                    this.Pedido.State = 2;
                    await this.ServiceSoons.updatePedido(this.Pedido);
                    this.Pedido = new Order();
                    this.ProductosPedidos = new ObservableCollection<ProdsOrder>();
                    this.Productos = new ObservableCollection<Prod>();
                    this.FilledCart = false;
                    this.NoFilledCart = true;
                });
            }
        }

        public Command AddToCart
        {
            get
            {

                String codigo = "";

                return new Command(async () =>
                {

                    scanPage = new ZXingScannerPage();
                    bool scanFinished = false;

                    scanPage.OnScanResult += (result) =>
                    {
                        scanPage.IsScanning = false;

                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            if (!scanFinished)
                            {
                                scanFinished = true;
                                codigo = result.Text;
                                Prod producto = await this.ServiceSoons.ProductoBySKU(codigo);
                                if (this.Pedido.Id == 0)
                                {
                                    Order order = new Order();
                                    bool comprobar = true;
                                    Random rnd = new Random();
                                    String codigoAleatorio = "RMC" + rnd.Next(1000000, 9999999);
                                    List<Order> orders = await this.ServiceSoons.GetOrders();
                                    while (comprobar)
                                    {

                                        if (orders.Select(x => x.OrderNumber).Contains(codigoAleatorio))
                                        {
                                            comprobar = true;
                                            codigoAleatorio = "RMC" + rnd.Next(1000000, 9999999);
                                        } else
                                        {
                                            comprobar = false;
                                        }
                                    }
                                    
                                    await this.ServiceSoons.GetOrders();
                                    order.OrderNumber = codigoAleatorio;
                                    order.State = 0;
                                    await this.ServiceSoons.insertOrder(order);
                                    Order orderEncontrado = await this.ServiceSoons.getPedidoByOrderNumber(order.OrderNumber);
                                    this.Pedido = orderEncontrado;
                                }
                                ProdsOrder prodOrder = new ProdsOrder();
                                prodOrder.IdOrder = this.Pedido.Id;
                                prodOrder.IdProd = producto.Id;
                                await this.ServiceSoons.insertProdOrders(prodOrder);
                                await this.GetOrder();
                                await Application.Current.MainPage.Navigation.PopModalAsync();
                            }
                        });
                    };
                    await Application.Current.MainPage.Navigation.PushModalAsync(scanPage);

                });
            }
        }
    }
}
