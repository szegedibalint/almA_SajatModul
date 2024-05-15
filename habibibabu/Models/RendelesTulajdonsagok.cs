using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Christoc.Modules.habibibabu.Models
{
    [TableName("RendelesTulajdonsagok")]
    [PrimaryKey("TulajdonsagId", AutoIncrement = true)]
    [Cacheable("RendelesTulajdonsagokkk", CacheItemPriority.Default, 20)]
    //[Scope("ModuleId")]
    public class RendelesTulajdonsagok
    {
        public int TulajdonsagId { get; set; } = -1;
        public int RendelesId { get; set; } = -1;
        public bool Hoallo { get; set; }
        public bool KemiaiEll { get; set; }
        public bool MagasSzil { get; set; }
        public bool UvEll { get; set; }
    }
}