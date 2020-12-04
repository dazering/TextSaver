using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextSaverWebApp.Models
{
    public class PartedText
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PartNumber { get; set; }
        public TextEntity TextEntity { get; set; }
    }
}
