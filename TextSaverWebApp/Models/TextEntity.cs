using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextSaverWebApp.Models
{
    public class TextEntity
    {
        public int Id { get; set; }
        public ICollection<PartedText> PartedTexts { get; private set; }

        public string GetFullText()
        {
            return string.Join("",PartedTexts.OrderBy(t => t.PartNumber).SelectMany(s => s.Text));
        }

        public void SplitText(string str)
        {
            StringBuilder sb = new StringBuilder(str);

            PartedTexts = sb.Replace(". ", ". |").Replace("! ", "! |").Replace("? ", "? |").Replace($"{Environment.NewLine}", $"{Environment.NewLine}|").ToString().Split("|").Select((s, i) => new PartedText() { Text = s, PartNumber = i }).ToList();
        }
    }
}
