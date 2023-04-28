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
            
        }

        private void Initialize()
        {
            AppModel.Instance.Init(new LogicState(LogicStateEnum.RunState));
            
        }
    }
}
