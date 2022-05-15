using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modifiedState = new ModifiedState();
            modifiedState.DoAciton(context);
            DeletedState deletedState = new DeletedState();
            deletedState.DoAciton(context);

            Console.WriteLine(context.GetState().ToString());

            Console.ReadLine();
        }
    }
    

    public interface IState
    {
        void DoAciton(Context context);
    }

    public class ModifiedState : IState
    {
        public void DoAciton(Context context)
        {
            Console.WriteLine("State: Modified");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Modified";
        }
    }
    public class DeletedState : IState
    {
        public void DoAciton(Context context)
        {
            Console.WriteLine("State: Deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    public class AddState : IState
    {
        public void DoAciton(Context context)
        {
            Console.WriteLine("State: Added");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }

    public class Context
    {
        IState _state;

        public void SetState(IState state)
        {
            _state = state; 
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
