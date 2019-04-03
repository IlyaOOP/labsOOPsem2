using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab4_5
{
    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
    class mycommands:Command
    {
        MainWindow mw;
        public mycommands(MainWindow r)
        {
            mw = r;            
        }
        public override void Execute()
        {
            mw.past();
            mw.ispaste = true;
        }

        public override void Undo()
        {

        }
    }
}
