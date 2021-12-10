using App.Template;

namespace App.Commands
{
    public class Command
    {
        public Command() { }

        public virtual void Execute(Actor actor) { }
    }

    public class MoveUpCommand : Command
    {
        public MoveUpCommand()
        {

        }

        public override void Execute(Actor actor)
        {
            actor.MoveUp();
        }
    }

    public class MoveDownCommand : Command
    {
        public MoveDownCommand()
        {

        }

        public override void Execute(Actor actor)
        {
            actor.MoveDown();
        }
    }

    public class MoveRightCommand : Command
    {
        public MoveRightCommand()
        {

        }

        public override void Execute(Actor actor)
        {
            actor.MoveRight();
        }
    }

    public class MoveLeftCommand : Command
    {
        public MoveLeftCommand()
        {

        }

        public override void Execute(Actor actor)
        {
            actor.MoveLeft();
        }
    }

}
