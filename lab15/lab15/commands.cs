using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    public class commands
    {
        public interface ICommand { int[] Execute(int[] coord); };

        public class UpCommand : ICommand
        {
            public int[] Execute(int[] coord)
            {
                return methods.Up(coord);
            }
        };

        public class DownCommand : ICommand
        {
            public int[] Execute(int[] coord)
            {
                return methods.Down(coord);
            }
        };

        public class RunUpCommand : ICommand
        {
            public int[] Execute(int[] coord)
            {
                return methods.RunUp(coord);
            }
        };

        public class RunDownCommand : ICommand
        {
            public int[] Execute(int[] coord)
            {
                return methods.RunDown(coord);
            }
        };

        public class LeftCommand : ICommand
        {
            public int[] Execute(int[] coord)
            {
                return methods.Left(coord);
            }
        };

        public class RightCommand : ICommand
        {
            public int[] Execute(int[] coord)
            {
                return methods.Right(coord);
            }
        };
    }

    static class methods
    {
        static public int[] Up(int[] c)
        {
            int[] coord = c;
            if(coord[1]>1)
                coord[1] -= 1;
            return coord;
        }
        static public int[] Down(int[] c)
        {
            int[] coord = c;
            if (coord[1] < 500)
                coord[1] += 1;
            return coord;
        }
        static public int[] RunUp(int[] c)
        {
            int[] coord = c;
            if (coord[1] > 1)
                coord[1] -= 2;
            return coord;
        }
        static public int[] RunDown(int[] c)
        {
            int[] coord = c;
            if (coord[1] < 500)
                coord[1] += 2;
            return coord;
        }
        static public int[] Left(int[] c)
        {
            int[] coord = c;
            if (coord[0] > 1)
                coord[0] -= 1;
            return coord;
        }
        static public int[] Right(int[] c)
        {
            int[] coord = c;
            if (coord[0] < 500)
                coord[0] += 1;
            return coord;
        }
    }
}
