using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
