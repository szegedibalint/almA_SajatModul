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

namespace Christoc.Modules.DNNModule2.Components
{
    internal interface IRendelesManager
    {
        void CreateRendeles(Rendeles r);
        void DeleteRendeles(int rendelesId, int moduleId);
        void DeleteRendeles(Rendeles r);
        IEnumerable<Rendeles> GetRendelesek(int moduleId);
        Rendeles GetRendeles(int rendelesId, int moduleId);
        void UpdateRendeles(Rendeles r);
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
        public int GetLastRendelesId()
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Rendeles>();
                var lastRendeles = rep.Get().OrderByDescending(r => r.RendelesId).FirstOrDefault();
                return lastRendeles != null ? lastRendeles.RendelesId : 0;
            }
        }

        public void DeleteRendeles(int rendelesId, int moduleId)
        {
            var r = GetRendeles(rendelesId, moduleId);
            DeleteRendeles(r);
        }

        public void DeleteRendeles(Rendeles r)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Rendeles>();
                rep.Delete(r);
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

        public void UpdateRendeles(Rendeles r)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Rendeles>();
                rep.Update(r);
            }
        }

        protected override System.Func<IRendelesManager> GetFactory()
        {
            return () => new RendelesManager();
        }
    }
}