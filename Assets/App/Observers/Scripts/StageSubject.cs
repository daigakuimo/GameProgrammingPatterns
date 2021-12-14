using App.Template;
using UnityEngine;

namespace App.Observers
{
    public class StageSubject : Subject
    {
        [SerializeField] PlayerActor player;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = player.transform;
        }

        private void Update()
        {
            if (IsStageOut())
            {
                Notify(player, Event.EventPlayerScreenOut);
            }
        }

        private bool IsStageOut()
        {
            bool isStageOut = false;

            var playerPosition = _playerTransform.position;
            if (playerPosition.x < -10f || playerPosition.x > 9f || playerPosition.y > 5f || playerPosition.y < -5f)
            {
                isStageOut = true;
            }

            return isStageOut;
        }
    }
}
