using System;
using System.Collections.Generic;
using System.Text;

namespace Safrani.Model
{
    public enum LabelType { Is, Has, For, BelongsTo }

    public class Label : Thing
    {
        public Notion Notion { get; set; }
        public LabelType Type { get; set; }
    }
}
