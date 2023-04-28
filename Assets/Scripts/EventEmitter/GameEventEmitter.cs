using System;
using Utility;

namespace EventEmitter
{
    public class GameEventEmitter : AbstractSingleton<GameEventEmitter>
    {
        private event Action win = () => { };

        /*****************************************************************************************/

        public static void OnWin()
        {
            Instance.win();
        }

        /*****************************************************************************************/

        public static event Action Win
        {
            add { Instance.win += value; }
            remove { Instance.win -= value; }
        }
    }
}
