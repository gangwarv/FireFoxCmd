using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireFoxCmd
{
    class ClsListner
    {
        IKeyboardMouseEvents hook;
        public ClsListner()
        {
            hook = Gma.System.MouseKeyHook.Hook.GlobalEvents();
        }
        public void ListenMouseMove()
        {
            hook.MouseMoveExt += Hook_MouseMoveExt;
            //hook.MouseMove += OnMouseMove;
            Console.WriteLine("Attached");
        }

        private void Hook_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            Console.WriteLine("Moved");
        }

        private void OnMouseMove(object sender, MouseEventExtArgs e)
        {

        }
    }
}
