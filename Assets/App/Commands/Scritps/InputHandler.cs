using UnityEngine;
using App.Template;
using UniRx;
using UniRx.Triggers;

namespace App.Commands
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerActor playerActor;
        [SerializeField] private CommandType buttonWCommand;
        [SerializeField] private CommandType buttonSCommand;
        [SerializeField] private CommandType buttonDCommand;
        [SerializeField] private CommandType buttonACommand;

        private Command _buttonW;
        private Command _buttonS;
        private Command _buttonD;
        private Command _buttonA;

        private void Start()
        {
            SetCommand();

            RegisterEvent();
        }

        /// <summary>
        /// コマンドインスタンス生成    
        /// </summary>
        private void SetCommand()
        {
            _buttonW = GenerateCommand(buttonWCommand);
            _buttonS = GenerateCommand(buttonSCommand);
            _buttonD = GenerateCommand(buttonDCommand);
            _buttonA = GenerateCommand(buttonACommand);
        }

        /// <summary>
        /// コマンドタイプ別にインスタンス生成  
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Command GenerateCommand(CommandType type)
        {
            switch (type)
            {
                case CommandType.Up:
                    return new MoveUpCommand();
                case CommandType.Down:
                    return new MoveDownCommand();
                case CommandType.Right:
                    return new MoveRightCommand();
                case CommandType.Left:
                    return new MoveLeftCommand();
                default:
                    throw new System.Exception();
            }
        }

        /// <summary>
        /// キー入力イベントの登録
        /// </summary>
        private void RegisterEvent()
        {
            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.W))
                .Subscribe(_ =>
                {
                    _buttonW.Execute(playerActor);
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.S))
                .Subscribe(_ =>
                {
                    _buttonS.Execute(playerActor);
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.D))
                .Subscribe(_ =>
                {
                    _buttonD.Execute(playerActor);
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.A))
                .Subscribe(_ =>
                {
                    _buttonA.Execute(playerActor);
                });
        }
    }
}
