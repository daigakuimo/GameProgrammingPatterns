using App.Template;

namespace App.Commands
{
    public enum CommandType
    {
        Up,
        Down,
        Right,
        Left
    }

    public class Command
    {
        public Command() { }

        public virtual void Execute() { }

        public virtual void Undo() { }
    }

    public class MoveUpCommand : Command
    {
        Actor actor;
        public MoveUpCommand(Actor actor)
        {
            this.actor = actor;
        }

        public override void Execute()
        {
            actor.MoveUp();
        }

        public override void Undo()
        {
            actor.MoveDown();
        }
    }

    public class MoveDownCommand : Command
    {
        Actor actor;
        public MoveDownCommand(Actor actor)
        {
            this.actor = actor;
        }

        public override void Execute()
        {
            actor.MoveDown();
        }

        public override void Undo()
        {
            actor.MoveUp();
        }
    }

    public class MoveRightCommand : Command
    {
        Actor actor;
        public MoveRightCommand(Actor actor)
        {
            this.actor = actor;
        }

        public override void Execute()
        {
            actor.MoveRight();
        }
        public override void Undo()
        {
            actor.MoveLeft();
        }
    }

    public class MoveLeftCommand : Command
    {
        Actor actor;
        public MoveLeftCommand(Actor actor)
        {
            this.actor = actor;
        }

        public override void Execute()
        {
            actor.MoveLeft();
        }

        public override void Undo()
        {
            actor.MoveRight();
        }
    }

}
