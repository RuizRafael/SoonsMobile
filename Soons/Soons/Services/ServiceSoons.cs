using Newtonsoft.Json;
using Soons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Soons.Services
{
    public class ServiceSoons
    {
        private Uri uri;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceSoons()
        {
            this.uri = new Uri("https://apisoons.azurewebsites.net/");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<T> ApiGet<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = JsonConvert.DeserializeObject<T>
                        (await response.Content.ReadAsStringAsync());
                    return data;
                }
                return default(T);
            }
        }

        public async Task<List<Stock>> GetStockById(int id)
        {
            return await this.ApiGet<List<Stock>>("api/GetStockById/" + id);
        }
        public async Task<int> GetTotalSizes()
        {
            return await this.ApiGet<int>("api/TotalSizes");
        }

        public async Task<Prod> ProductoBySKU(string codigo)
        {
            List<Prod> productos = await this.ApiGet<List<Prod>>("/api/GetProducts");
            Prod producto = productos.First(x => x.SKU == codigo);
            return producto;
        }

        public async Task<Order> getPedido(string codigo)
        {
            Order pedido = await this.ApiGet<Order>("api/GetOrderByOrderNumber/" + codigo);
            return pedido;
        }

        public async Task<List<ProdsOrder>> getProductosPedido(int id)
        {
            List<ProdsOrder> ProductosPedido = await this.ApiGet<List<ProdsOrder>>("api/GetProductosPedido/" + id);
            return ProductosPedido;
        }

        public async Task<List<Prod>> getProductosSoloDelPedido(List<ProdsOrder> productosOrder)
        {
            List<Prod> productos = await this.ApiGet<List<Prod>>("api/GetProductos");
            return productos.Where(x => productosOrder.Select(y => y.idProd).Contains(x.Id)).ToList();
        }
    }
}
