using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor : Command
    {
        private Command[] _commands = new Command[2];
        public CommandProcessor() : base(new string[] { "commandprocessor" })
        {
            _commands[0] = new MoveCommand();
            _commands[1] = new LookCommand();
        }

        public override string Execute(Player player, string[] text)
        {
            foreach (Command command in _commands)
            {
                if (command.AreYou(text[0]))
                {
                    return command.Execute(player, text);
                }
            }
            return "Unknown command. Please try again.";
        }
    }
}
