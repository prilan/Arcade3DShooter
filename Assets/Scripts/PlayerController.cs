using System.Collections;
using UnityEngine;

namespace Arcade3DShooter
{
    public class PlayerController : MonoBehaviour
    {
        private const float MINIMAL_DISTANCE_TO_SHELTER = 0.05f;

        private void Start()
        {

        }

        private void Update()
        {
            if (AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.RunState) {
                if (!ProcessShelterNear()) {
                    transform.position += new Vector3(1, 0, 0) * GameModel.Instance.RunSpeed * Time.deltaTime;
                }
            } else if (AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.ShelterState
                || AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.MoveToShelterState) {
                CheckShelterClean();
            }
        }

        public void RestartGame()
        {
            transform.position = GameModel.Instance.PlayerStartPosition;
        }

        private bool ProcessShelterNear()
        {
            Shelter shelter = FindShelterNear();
            if (shelter != null) {
                if (!shelter.IsEnemiesClean) {
                    AppModel.Instance.LogicState.ChangeState(LogicStateEnum.MoveToShelterState);

                    MoveToShelterCenter(shelter);

                    return true;
                }
            }

            return false;
        }

        private void MoveToShelterCenter(Shelter shelter)
        {
            Vector3 position = transform.position;
            position.x = shelter.transform.position.x;
            transform.position = position;
        }

        private Shelter FindShelterNear()
        {
            foreach (Shelter shelter in ShelterManager.Instance.Shelters) {
                float distanceToShelter = GetDistanceToShelter(shelter);

                if (distanceToShelter < MINIMAL_DISTANCE_TO_SHELTER) {
                    Debug.Log("PlayerController.FindShelterNear:  Found");

                    return shelter;
                }
            }

            return null;
        }

        private float GetDistanceToShelter(Shelter shelter)
        {
            return Mathf.Abs(shelter.transform.position.x - transform.position.x);
        }

        private void CheckShelterClean()
        {
            Shelter shelter = FindShelterNear();
            if (shelter != null) {
                Debug.Log("PlayerController.CheckShelterClean: FindShelterNear ");

                if (shelter.IsEnemiesClean) {
                    Debug.Log("PlayerController.CheckShelterClean: ");

                    AppModel.Instance.LogicState.ChangeState(LogicStateEnum.MoveToRunState);
                }
            }
        }
    }
}
