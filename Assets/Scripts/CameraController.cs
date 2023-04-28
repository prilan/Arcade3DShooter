using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Arcade3DShooter
{
    public class CameraController : MonoBehaviour
    {
        [Header("Run State")]
        [SerializeField] Vector3 runPosition;
        [SerializeField] Vector3 runRotation;

        [Header("Shelter State")]
        [SerializeField] Vector3 shelterPosition;
        [SerializeField] Vector3 shelterRotation;

        [Header("Animation")]
        [SerializeField] float transitionTimeSec = 0.8f;

        private bool isMovingAnimation = false;

        private Sequence moveSequence;

        private void Start()
        {
            
        }

        public void RestartGame()
        {
            transform.position = runPosition;
            transform.Rotate(runRotation);
        }

        private void StartAnimationSequence()
        {
            moveSequence = DOTween.Sequence();
            moveSequence.OnKill(() => moveSequence = null);
        }

        private void Update()
        {
            if (AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.RunState) {
                transform.position += new Vector3(1, 0, 0) * GameModel.Instance.RunSpeed * Time.deltaTime;
            }
            if (AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.MoveToShelterState) {
                MoveFromRunToShelter();
            }
            if (AppModel.Instance.LogicState.CurrentLogicState == LogicStateEnum.MoveToRunState) {
                MoveFromShelterToRun();
            }
        }

        private void MoveFromRunToShelter()
        {
            if (isMovingAnimation)
                return;

            Debug.Log("CameraController.MoveFromRunToShelter: " + " isMovingAnimation = " + isMovingAnimation);

            isMovingAnimation = true;

            StopAnimation();

            StartAnimationSequence();

            moveSequence.Append(transform.DOMoveY(shelterPosition.y, transitionTimeSec)).SetEase(Ease.InOutSine);
            moveSequence.Join(transform.DOMoveZ(shelterPosition.z, transitionTimeSec)).SetEase(Ease.InOutSine);
            moveSequence.Join(transform.DORotate(shelterRotation, transitionTimeSec)).SetEase(Ease.InOutSine);

            moveSequence.AppendCallback(() =>
            {
                Debug.Log("CameraController.MoveFromRunToShelter: AppendCallback");

                isMovingAnimation = false;
                AppModel.Instance.LogicState.ChangeState(LogicStateEnum.ShelterState);
            });
        }

        private void MoveFromShelterToRun()
        {
            if (isMovingAnimation)
                return;

            Debug.Log("CameraController.MoveFromShelterToRun: " + " isMovingAnimation = " + isMovingAnimation);

            isMovingAnimation = true;

            StopAnimation();

            StartAnimationSequence();

            moveSequence.Append(transform.DOMoveY(runPosition.y, transitionTimeSec)).SetEase(Ease.InOutSine);
            moveSequence.Join(transform.DOMoveZ(runPosition.z, transitionTimeSec)).SetEase(Ease.InOutSine);
            moveSequence.Join(transform.DORotate(runRotation, transitionTimeSec)).SetEase(Ease.InOutSine);

            moveSequence.AppendCallback(() =>
            {
                Debug.Log("CameraController.MoveFromShelterToRun: AppendCallback");

                isMovingAnimation = false;
                AppModel.Instance.LogicState.ChangeState(LogicStateEnum.RunState);
            });
        }

        private void StopAnimation()
        {
            moveSequence.Kill();
        }
    }
}
