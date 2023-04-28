using System.Collections;
using UnityEngine;

namespace Arcade3DShooter
{
    public class EnemyController : MonoBehaviour
    {
        public bool isAlive = true;

        public bool IsAlive => isAlive;

        private void Start()
        {

        }

        private void Update()
        {

        }

        public void DamageByTapped()
        {
            Debug.Log("EnemyController.DamageByTapped: ");

            SetActive(false);
        }

        public void RestartEnemy()
        {
            SetActive(true);
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
            isAlive = isActive;
        }
    }
}
