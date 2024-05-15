using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Caching;

namespace Christoc.Modules.habibibabu.Models
{
    [TableName("RendelesUgyfel")]
    [PrimaryKey("Ugyfel_Id", AutoIncrement = true)]
    [Cacheable("RendelesekUgyfel", CacheItemPriority.Default, 20)]
    //[Scope("ModuleId")]
    public class RendelesUgyfel
    {
        public int Ugyfel_Id { get; set; } = -1;
        public int RendelesId { get; set; } = -1;
        public string Ceg { get; set; }
        public string Nev { get; set; }
        public string Emailcim { get; set; }
        public string Telefonszam { get; set; }

    }
}
