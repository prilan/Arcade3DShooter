using System.Collections;
using UnityEngine;

namespace Arcade3DShooter
{
    public class InputController : MonoBehaviour
    {
        private Camera mainCamera;

        private Touch touch;
        private float timeTouchEnded;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 mousePosition = Input.mousePosition;

                RaycastHit hit;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit)) {
                    Transform objectHit = hit.transform;
                    EnemyController enemyController = objectHit.GetComponent<EnemyController>();
                    if (enemyController != null) {
                        enemyController.DamageByTapped();
                    }
                }
            }
        }
    }
}
