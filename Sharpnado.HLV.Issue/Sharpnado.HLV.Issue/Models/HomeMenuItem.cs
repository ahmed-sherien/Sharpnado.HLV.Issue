using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpnado.HLV.Issue.Models
{
    public class HomeMenuItem
    {
        public PageType Id { get; set; }

        public string Title { get; set; }

        public Func<string> Badge { get; set; } = () => string.Empty;

        public Func<bool> IsEnabled { get; set; } = () => true;
    }
}
