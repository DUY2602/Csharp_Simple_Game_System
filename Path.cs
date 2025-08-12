using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;
        public Path(string[] ids, string name, string desc) : base(ids, name, desc)
        {
        }

        public Location Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public void MovePlayer(Player player)
        {
            if (_destination != null)
            {
                player.Location = _destination; 
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"{Name} ({FirstID})\n{base.FullDescription}\nThis path leads to {(_destination != null ? _destination.Name : "nowhere")}.";
            }
        }
    }
}
