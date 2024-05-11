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
        public string Megjegyzes { get; set; }

        ///<summary>
        /// The ModuleId of where the object was created and gets displayed
        ///</summary>
        public int ModuleId { get; set; }

        ///<summary>
        /// An integer for the user id of the user who created the object
        ///</summary>

        ///<summary>
        /// An integer for the user id of the user who last updated the object
        ///</summary>

        ///<summary>
        /// The date the object was created
        ///</summary>
        public DateTime CreatedOnDate { get; set; } = DateTime.UtcNow;

        ///<summary>
        /// The date the object was updated
        ///</summary>
    }
}