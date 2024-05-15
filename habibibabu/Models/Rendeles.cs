using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Christoc.Modules.habibibabu.Models
{
    [TableName("Rendeles")]
    [PrimaryKey("RendelesId", AutoIncrement = true)]
    [Cacheable("Rendelesek", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class Rendeles
    {
        public int RendelesId { get; set; } = -1;
        public Nullable<int> NyomtTech { get; set; }
        public Nullable<int> AtfutIdo { get; set; }
        public Nullable<int> Darabszam { get; set; }
        public string Szin {  get; set; }
        public string Megjegyzes { get; set; }
        public string FilePath { get; set; }
        public int ModuleId { get; set; }
        public DateTime CreatedOnDate { get; set; }
    }
}