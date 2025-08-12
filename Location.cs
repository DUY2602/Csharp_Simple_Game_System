using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public GameObject Locate(string id)
        {
            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public string PathList
        {
            get
            {
                string pathlist = "";
                if (_paths.Count == 0)
                {
                    return "No paths available.";
                }
                
                pathlist += "Paths available:\n";

                foreach (var path in _paths)
                {
                    pathlist += $"\t{path.Name} ({path.FirstID})\n";
                }

                return pathlist;
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"Player is at {this.Name}, {base.FullDescription}\nYou can see:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
