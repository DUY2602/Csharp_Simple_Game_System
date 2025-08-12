using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(ids: new string[] { "look" })
        {

        }
        public override string Execute(Player p, string[] text)
        {
            if ((text.Length != 3) && (text.Length != 5) && (text.Length != 1))
            {
                return "I don't know how to look like that";
            }

            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }

            if (text.Length == 1)
            {
                return LookAtIn("location", p as IHaveInventory);
            }

            if (text[1].ToLower() != "at")
            {
                return "What do you want to look at?";
            }

            if ((text.Length == 5) && (text[3].ToLower() != "in"))
            {
                return "What do you want to look in?";
            }

            string itemId = text[2].ToLower();

            if (text.Length == 3)
            {
                return LookAtIn(itemId, p as IHaveInventory);
            }

            string placeHolder = text[4].ToLower();
            IHaveInventory container = FetchContainer(p, placeHolder);


            if (container == null)
            {
                return $"I can't find the {placeHolder}";
            }

            return LookAtIn(itemId, container);
        }

        public IHaveInventory FetchContainer(Player p, string placeHolder)
        {
            return p.Locate(placeHolder) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject item = container.Locate(thingId);
            if (item == null)
            {
                return "I can't find the " + thingId;
            }
            else
            {
                return item.FullDescription;
            }
        }

    }
}
