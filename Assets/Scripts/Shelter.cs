using Arcade3DShooter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arcade3DShooter
{
    public class Shelter : MonoBehaviour
    {
        [SerializeField] List<EnemyController> enemies;

        public bool IsEnemiesClean => !enemies.Any(enemy => enemy.IsAlive);

        private void Start()
        {

        }

        private void Update()
        {

        }

        public void RestartAllEnemies()
        {
            foreach (EnemyController enemy in enemies) {
                enemy.RestartEnemy();
            }
        }
    }
}
