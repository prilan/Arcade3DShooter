using System.Collections;
using UnityEngine;

namespace Arcade3DShooter
{
    public enum LogicStateEnum
    {
        RunState,
        MoveToShelterState, // Переход от бега к укрытию
        ShelterState,
        MoveToRunState      // Переход от укрытия к бегу
    }

    public class LogicState
    {
        private LogicStateEnum currentLogicState;

        public LogicStateEnum CurrentLogicState
        {
            get { return currentLogicState; }
        }

        public LogicState(LogicStateEnum logicStateValue)
        {
            ChangeState(logicStateValue);
        }

        public void ChangeState(LogicStateEnum logicStateValue)
        {
            currentLogicState = logicStateValue;
        }
    }
}