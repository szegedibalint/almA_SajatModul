/*
' Copyright (c) 2024 Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using Christoc.Modules.habibibabu.Models;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.CommerceDTO.v1.Membership;
using Hotcakes.CommerceDTO.v1.Orders;

namespace Christoc.Modules.habibibabu.Components
{
    internal interface IRendelesManager
    {
        void CreateRendeles(Rendeles r);
        void CreateRendelesUgyfel(RendelesUgyfel u);
        void CreateRendelesTulajdonsagok(RendelesTulajdonsagok t);
        void RendelesLeadas(RendelesViewModel rv);
        IEnumerable<Rendeles> GetRendelesek(int moduleId);
        Rendeles GetRendeles(int rendelesId, int moduleId);
        int GetLastRendelesId();
    }

    internal class RendelesManager : ServiceLocator<IRendelesManager, RendelesManager>, IRendelesManager
    {
        public void CreateRendeles(Rendeles r)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Rendeles>();
                rep.Insert(r);
            }
        }
        public void CreateRendelesUgyfel(RendelesUgyfel u)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<RendelesUgyfel>();
                rep.Insert(u);
            }
        
        }
        public void CreateRendelesTulajdonsagok(RendelesTulajdonsagok t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<RendelesTulajdonsagok>();
                rep.Insert(t);
            }
        }

        public void RendelesLeadas(RendelesViewModel rv)
        {
            string url = "http://dnndev.me/";
            string key = "1-b8478310-0b81-4063-bf27-f271998508ca";

            Api proxy = new Api(url, key);

            // create a new order object
            var order = new OrderDTO();

            // add billing information
            order.BillingAddress = new AddressDTO
            {
                AddressType = AddressTypesDTO.Billing,
                City = "_",
                CountryBvin = "_",
                FirstName = rv.RendelesUgyfel.Nev,
                LastName = rv.RendelesUgyfel.Ceg,
                Line1 = rv.Rendeles.RendelesId.ToString(),
                Line2 = rv.RendelesUgyfel.Ugyfel_Id.ToString(),
                Phone = rv.RendelesUgyfel.Telefonszam,
                PostalCode = "_",
                RegionBvin = "_"
            };

            // add at least one line item
            order.Items = new List<LineItemDTO>();
            order.Items.Add(new LineItemDTO
            {
                ProductId = "b8478310-0b81-4063-bf27-f271998508ca", // Bármilyen Guid típusú string
                Quantity = 1
            });

            // add the shipping address
            order.ShippingAddress = new AddressDTO();
            order.ShippingAddress = order.BillingAddress;
            order.ShippingAddress.AddressType = AddressTypesDTO.Shipping;

            // specify who is creating the order
            order.UserEmail = "info@hotcakescommerce.com";
            order.UserID = "1";

            // call the API to create the order
            ApiResponse<OrderDTO> response = proxy.OrdersCreate(order);

        }
        public int GetLastRendelesId()
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Rendeles>();
                var lastRendeles = rep.Get().OrderByDescending(r => r.RendelesId).FirstOrDefault();
                return lastRendeles != null ? lastRendeles.RendelesId : 0;
            }
        }



        public IEnumerable<Rendeles> GetRendelesek(int moduleId)
        {
            IEnumerable<Rendeles> r;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Rendeles>();
                r = rep.Get(moduleId);
            }
            return r;
        }

        public Rendeles GetRendeles(int rendelesId, int moduleId)
        {
            Rendeles r;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Rendeles>();
                r = rep.GetById(rendelesId, moduleId);
            }
            return r;
        }


        protected override System.Func<IRendelesManager> GetFactory()
        {
            return () => new RendelesManager();
        }
    }
}