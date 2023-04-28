using Assets.Scripts;
using System.Collections;
using UnityEngine;

namespace Arcade3DShooter
{
    public class PlayerController : MonoBehaviour
    {
        private const float MINIMAL_DISTANCE_TO_SHELTER = 0.1f;

        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            if (AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.RunState) {
                ProcessShelterNear();

                transform.position += new Vector3(1, 0, 0) * GameModel.Instance.RunSpeed * Time.deltaTime;
            }
        }

        private void ProcessShelterNear()
        {
            foreach (var shelter in ShelterManager.Instance.Shelters) {
                float distanceToShelter = Vector3.Distance(shelter.transform.position, transform.position);
                if (distanceToShelter < MINIMAL_DISTANCE_TO_SHELTER) {
                    AppModel.Instance.LogicState.ChangeState(LogicStateEnum.MoveToShelterState);
                }
            }
        }
    }
}
