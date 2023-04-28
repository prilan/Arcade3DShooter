using EventEmitter;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Arcade3DShooter
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] Button restartButton;

        private void Awake()
        {
            GameEventEmitter.Win += OnWin;

            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDestroy()
        {
            GameEventEmitter.Win -= OnWin;
        }

        private void OnWin()
        {
            restartButton.gameObject.SetActive(true);
        }

        private void OnRestartButtonClicked()
        {
            restartButton.gameObject.SetActive(false);

            GameModel.Instance.RestartGame();
        }
    }
}