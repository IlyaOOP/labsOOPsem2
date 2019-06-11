using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab15.commands;

namespace lab15
{  

    public interface IPlayerState
    {
        int[] changeState(ICommand cmd, int[] c);
    }
    class UpState : IPlayerState
    {
        public int[] changeState(ICommand cmd, int[] c)
        {
            return cmd.Execute(c);
        }
    }
    class DownState : IPlayerState
    {
        public int[] changeState(ICommand cmd, int[] c)
        {
            return cmd.Execute(c);
        }
    }
    class LeftState : IPlayerState
    {
        public int[] changeState(ICommand cmd, int[] c)
        {
            return cmd.Execute(c);
        }
    }
    class RightState : IPlayerState
    {
        public int[] changeState(ICommand cmd, int[] c)
        {
            return cmd.Execute(c);
        }
    }

}
