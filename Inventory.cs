using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory 
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item itm = Fetch(id);
            if (itm != null)
            {
                _items.Remove(itm); 
            }
            return itm;
        }

        public Item Fetch(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList   // I fixed this property a little bit 
        {
            get
            {
                string itmlist = "";
                foreach (var item in _items)
                {
                    itmlist += "\t" + item.ShortDescription + "\n";
                }
                return itmlist;
            }
        }
    }
}
