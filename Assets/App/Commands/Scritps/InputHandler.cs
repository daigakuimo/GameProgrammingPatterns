using UnityEngine;
using App.Template;
using UniRx;
using UniRx.Triggers;

namespace App.Commands
{
    public class InputHandler : MonoBehaviour
    {
        private const int MaxCommandsLength = 5;
        [SerializeField] private PlayerActor playerActor;
        [SerializeField] private CommandType buttonWCommand;
        [SerializeField] private CommandType buttonSCommand;
        [SerializeField] private CommandType buttonDCommand;
        [SerializeField] private CommandType buttonACommand;

        private readonly Command[] commands = new Command[MaxCommandsLength];
        private int commandsCurrentIndex = -1;

        // private Command _buttonW;
        // private Command _buttonS;
        // private Command _buttonD;
        // private Command _buttonA;

        private void Start()
        {
            // SetCommand();

            RegisterEvent();
        }

        /// <summary>
        /// コマンドインスタンス生成    
        /// </summary>
        // private void SetCommand()
        // {
        //     _buttonW = GenerateCommand(buttonWCommand, playerActor);
        //     _buttonS = GenerateCommand(buttonSCommand, playerActor);
        //     _buttonD = GenerateCommand(buttonDCommand, playerActor);
        //     _buttonA = GenerateCommand(buttonACommand, playerActor);
        // }

        /// <summary>
        /// コマンドタイプ別にインスタンス生成  
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Command GenerateCommand(CommandType type, Actor actor)
        {
            switch (type)
            {
                case CommandType.Up:
                    return new MoveUpCommand(actor);
                case CommandType.Down:
                    return new MoveDownCommand(actor);
                case CommandType.Right:
                    return new MoveRightCommand(actor);
                case CommandType.Left:
                    return new MoveLeftCommand(actor);
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
                    var command = GenerateCommand(buttonWCommand, playerActor);
                    command.Execute();
                    AddCommandArray(command);
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.S))
                .Subscribe(_ =>
                {
                    var command = GenerateCommand(buttonSCommand, playerActor);
                    command.Execute();
                    AddCommandArray(command);
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.D))
                .Subscribe(_ =>
                {
                    var command = GenerateCommand(buttonDCommand, playerActor);
                    command.Execute();
                    AddCommandArray(command);
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.A))
                .Subscribe(_ =>
                {
                    var command = GenerateCommand(buttonACommand, playerActor);
                    command.Execute();
                    AddCommandArray(command);
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.Z))
                .Subscribe(_ =>
                {
                    Undo();
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.X))
                .Subscribe(_ =>
                {
                    Redo();
                });
        }

        private void AddCommandArray(Command command)
        {

            if (MaxCommandsLength >= commandsCurrentIndex + 2)
            {
                commandsCurrentIndex++;

                commands[commandsCurrentIndex] = command;

                DeleteCammandArray(commandsCurrentIndex + 1);

                return;
            }

            // 配列の中身が満員で1番後ろに入れる場合    
            PushOutOldCommand();
            commands[commandsCurrentIndex] = command;
        }

        private void DeleteCammandArray(int deleteStartIndex)
        {
            for (var i = deleteStartIndex; i < MaxCommandsLength; i++)
            {
                commands[i] = null;
            }
        }

        private void PushOutOldCommand()
        {
            for (var i = 1; i < MaxCommandsLength; i++)
            {
                commands[i - 1] = commands[i];
            }
        }

        private void Undo()
        {
            if (commandsCurrentIndex <= -1) return;

            commands[commandsCurrentIndex--].Undo();
        }

        private void Redo()
        {
            if (commandsCurrentIndex + 1 >= MaxCommandsLength) return;
            if (commands[commandsCurrentIndex + 1] == null) return;

            commands[++commandsCurrentIndex].Execute();
        }
    }
}
