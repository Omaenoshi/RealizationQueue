using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealizationQueue
{
    public class Item<TValue>
    {
        public TValue Value { get; set; }

        public Item<TValue> NextItem { get; set; }
    }
}
