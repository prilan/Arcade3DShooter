using System.Collections;
using UnityEngine;

namespace Arcade3DShooter
{
    public class CameraController : MonoBehaviour
    {
        private void Start()
        {

        }

        private void Update()
        {
            if (AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.RunState) {
                transform.position += new Vector3(1, 0, 0) * GameModel.Instance.RunSpeed * Time.deltaTime;
            } else if (AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.MoveToShelterState) {
                MoveFromRunToShelter
            }
        }

        private void MoveFromRunToShelter()
        {

        }
    }
}