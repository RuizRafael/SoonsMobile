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
                                codigo = "91883939";
                                Prod producto = await this.ServiceSoons.ProductoBySKU(codigo);
                                producto.Imagen1 = "dunkoffwhitemichigan1.jpg";
                                producto.Imagen2 = "dunkoffwhitemichigan2.jpg";
                                producto.Imagen3 = "dunkoffwhitemichigan3.jpg";
                                producto.Imagen4 = "dunkoffwhitemichigan4.jpg";
                                producto.Imagen5 = "dunkoffwhitemichigan5.jpg";
                                producto.Imagen6 = "dunkoffwhitemichigan6.jpg";
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
