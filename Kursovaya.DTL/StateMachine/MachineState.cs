using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.DTL.StateMachine
{
    public enum MachineState : int
    {
        None = 0,
        SetKeyWords = 1,
        ChangeNotificationHour = 2
    }
}
