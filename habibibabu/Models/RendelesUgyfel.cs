using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Caching;

namespace Christoc.Modules.habibibabu.Models
{
    [TableName("RendelesUgyfel")]
    [PrimaryKey("RendelesUgyfelId", AutoIncrement = true)]
    [Cacheable("RendelesekUgyfel", CacheItemPriority.Default, 20)]
    //[Scope("ModuleId")]
    public class RendelesUgyfel
    {
        public int UgyfelId { get; set; } = -1;
        public int RendelesId { get; set; }
        public string Nev { get; set; }
        public string Emailcim { get; set; }
        public string Telefonszam { get; set; }

    }
}
