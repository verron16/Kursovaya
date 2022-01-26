using Kursovaya.BLL.Commands;
using Kursovaya.Core.TypeGetter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.BLL.Command
{
    public static class Command
    {
        private static List<GeneralCommand> commands = null;

        public static List<GeneralCommand> GetCommands()
        {
            if(commands == null)
            {
                commands = ClassGetter.GetEnumerableOfType<GeneralCommand>();
            }
            return commands;
        }
    }
}
