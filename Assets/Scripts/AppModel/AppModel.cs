using System;
using UnityEngine;
using Utility;

namespace Arcade3DShooter
{
    public class AppModel : AbstractSingleton<AppModel>
    {
        public LogicState LogicState;

        public void Init(LogicState logicState)
        {
            LogicState = logicState;
        }

    }
}
