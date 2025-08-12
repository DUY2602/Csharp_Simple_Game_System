using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player player, string[] text)
        {

            if (AreYou(text[0]) == false)
            {
                return "Wrong command. Should be move, go, head, or leave.";
            }

            string direction;

            if (text.Length == 1)
            {
                return "Select the destination";
            }

            else if (text.Length == 2)
            {
                direction = text[1].ToLower();
            }

            else if (text.Length == 3)
            {
                direction = text[2].ToLower();
            }

            else
            {
                return "Invalid command";
            }

            GameObject path = player.Location.Locate(direction);

            if (path == null)
            {
                return "Error in finding direction";
            }

            else
            {
                if (path.GetType() == typeof(Path))
                {
                    player.Move((Path) path);

                    return $"You have moved to {player.Location.Name}.\n{player.Location.FullDescription}";
                }
                else
                {
                    return "You can't go that way.";
                }
            }
        }
    }           
}
