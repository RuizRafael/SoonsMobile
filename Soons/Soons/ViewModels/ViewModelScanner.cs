using Soons.Base;
using Soons.Models;
using Soons.Services;
using Soons.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace Soons.ViewModels
{
    public class ViewModelScanner : ViewModelBase
    {
        ServiceSoons ServiceSoons;
        ZXingScannerPage scanPage;

        public ViewModelScanner(ServiceSoons serviceSoons)
        {
            this.ServiceSoons = serviceSoons;
        }

        public Command MostrarZapatilla
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
                                List<Stock> stock = await this.ServiceSoons.GetStockById(producto.Id);
                                ViewModelDetails viewModel = App.ServiceLocator.ViewModelDetails;
                                viewModel.Stock = new ObservableCollection<Stock>(stock);
                                viewModel.Producto = producto;
                                viewModel.Fotos = new ObservableCollection<String>();
                                viewModel.Fotos.Add(producto.Imagen1);
                                viewModel.Fotos.Add(producto.Imagen2);
                                viewModel.Fotos.Add(producto.Imagen3);
                                viewModel.Fotos.Add(producto.Imagen4);
                                viewModel.Fotos.Add(producto.Imagen5);
                                viewModel.Fotos.Add(producto.Imagen6);
                                if (producto.Name.Length > 20)
                                {
                                    producto.Name = producto.Name.Substring(20) + "...";
                                }
                                Details view = new Details();
                                view.BindingContext = viewModel;
                                await Application.Current.MainPage.Navigation.PushModalAsync(view);
                            }
                        });
                    };
                    await Application.Current.MainPage.Navigation.PushModalAsync(scanPage);

                });
            }
        }
    }
}
