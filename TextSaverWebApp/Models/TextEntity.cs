using System;
using System.Collections.Generic;
using System.Linq;

namespace TextSaverWebApp.Models
{
    public class TextEntity
    {
        public int Id { get; set; }
        public ICollection<PartedText> PartedTexts { get; private set; }

        public string GetFullText()
        {
            return string.Join("", PartedTexts.OrderBy(t => t.PartNumber).SelectMany(s => s.Text));
        }

        public IEnumerable<string> GetParagraphs()
        {
            return GetFullText().Split($"{Environment.NewLine}");
        }

        public void SplitText(string str)
        {
            int countParts = str.Length > 500 ? str.Length / 500 : 1;
            PartedTexts = Enumerable.Range(0, countParts).Select(i => new PartedText()
            {
                PartNumber = i,
                Text = str.Substring(i * 500, Math.Min(500,
                str.Length - (countParts * i)))
            }).ToList();
        }
    }
}
