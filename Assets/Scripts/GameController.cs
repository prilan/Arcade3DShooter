using EventEmitter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcade3DShooter
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            bool isAllSheltersClean = CheckAllSheltersClean();
            if (isAllSheltersClean) {
                AppModel.Instance.LogicState.ChangeState(LogicStateEnum.WinState);
                GameEventEmitter.OnWin();
            }
        }

        private bool CheckAllSheltersClean()
        {
            foreach (Shelter shelter in ShelterManager.Instance.Shelters) {
                if (!shelter.IsEnemiesClean)
                    return false;
            }

            return true;
        }

        public void Initialize()
        {
            AppModel.Instance.Init(new LogicState(LogicStateEnum.RunState));
        }
    }
}
