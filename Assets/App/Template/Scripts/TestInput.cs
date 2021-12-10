using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace App.Template
{
    public class TestInput : MonoBehaviour
    {
        [SerializeField] private PlayerActor playerActor;

        // Update is called once per frame
        void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.W))
                .Subscribe(_ =>
                {
                    playerActor.MoveUp();
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.S))
                .Subscribe(_ =>
                {
                    playerActor.MoveDown();
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.D))
                .Subscribe(_ =>
                {
                    playerActor.MoveRight();
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.A))
                .Subscribe(_ =>
                {
                    playerActor.MoveLeft();
                });
        }
    }
}
