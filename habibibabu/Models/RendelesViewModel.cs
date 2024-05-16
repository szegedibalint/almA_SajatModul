using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.habibibabu.Models
{
    //[Scope("ModuleId")]
    public class RendelesViewModel
    {
        public Rendeles Rendeles { get; set; }
        public RendelesUgyfel RendelesUgyfel { get; set; }
        public RendelesTulajdonsagok RendelesTulajdonsagok { get; set; }
        public HttpPostedFileBase file { get; set; }
        
    }
}