using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Utility;

namespace Arcade3DShooter
{
    public class GameModel : MonoSingleton<GameModel>
    {
        public GameController GameController;

        [SerializeField] PlayerController playerController;
        [SerializeField] CameraController cameraController;

        private Vector3 playerStartPosition;

        public Vector3 PlayerStartPosition => playerStartPosition;

        public float RunSpeed = 3f;

        private void Start()
        {
            playerStartPosition = playerController.transform.position;
        }

        public void RestartGame()
        {
            ShelterManager.Instance.RestartAllShelters();

            playerController.RestartGame();
            cameraController.RestartGame();

            GameController.Initialize();
        }
    }
}
