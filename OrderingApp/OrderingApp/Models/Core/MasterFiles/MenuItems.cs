using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.Models.Core.MasterFiles
{
    public class MenuItems
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public Type TargetType { get; set; }
    }
}
