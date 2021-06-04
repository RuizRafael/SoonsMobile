using Soons.Base;
using Soons.Models;
using Soons.Services;
using Soons.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Soons.ViewModels
{
    public class ViewModelBuscadorPedidos: ViewModelBase
    {
        ServiceSoons service;
        public ViewModelBuscadorPedidos(ServiceSoons service)
        {
            this.service = service;
            this.Order = new Order();
        }
        //private int _Numero;
        //public int Numero
        //{
        //    get { return this._Numero; }
        //    set
        //    {
        //        this._Numero = value;
        //        OnPropertyChanged("Numero");
        //    }
        //}
        private Order _Order;
        public Order Order
        {
            get { return this._Order; }
            set
            {
                this._Order = value;
                OnPropertyChanged("Order");
            }
        }

        public Command BuscarPedido
        {
            get
            {
                return new Command(async (id) =>
                {

                    ViewModelTracking ViewModel = App.ServiceLocator.ViewModelTracking;
                    Tracking view = new Tracking();

                    Order o = await this.service.GetOrderById(Order.OrderNumber);
                    ViewModel.Order = o;
                    view.BindingContext = ViewModel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }


    }
}
