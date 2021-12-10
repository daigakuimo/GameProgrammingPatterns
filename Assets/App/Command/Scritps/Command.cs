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

        }
    }

}
