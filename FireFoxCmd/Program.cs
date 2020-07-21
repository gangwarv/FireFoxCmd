using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace FireFoxCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClsListner list = new ClsListner();
            //Thread t = new Thread(list.ListenMouseMove);
            //t.Start();
            //Thread.Sleep(3000);
            //
            clsActivity act = new clsActivity();
            act.Start();
            //Console.WriteLine(Convert.ToInt32(1.2f));
            Console.ReadLine();
        }
    }

    class clsActivity
    {
        public Random random = new Random();
        public int INTERVAL_MILI_SEC = 600*1000;
 
        public int MSeconds()
        {
            var dt = DateTime.Now;
            var sec = dt.Second;
            sec += (dt.Minute * 60 ) ;

            return (sec * 1000) + dt.Millisecond;
        }
        public int Interval()
        {
            var mili_sec = MSeconds();
            return mili_sec % (INTERVAL_MILI_SEC);
        }
        public void Start()
        {
            InputSimulator simulator = new InputSimulator();
            var Keyboard = simulator.Keyboard;
            
            while (true)
            {
                var m_sec = Interval();
                int min = 1600, max = 2300;
                var delay = random.Next(min, max); 
                Console.WriteLine($"downloading... {m_sec/1000}kb. {delay}Mbps..");
            // If 10min
                if (m_sec < max)
                {
                    Console.WriteLine("0% completed.");
                    Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.TAB);
                }
                if (
                    (m_sec >100000) && (m_sec < 200000) ||
                    (m_sec >300000) && (m_sec < 400000)||
                    (m_sec >500000)
                    )
                    Keyboard.KeyPress(VirtualKeyCode.UP);
                else
                    Keyboard.KeyPress(VirtualKeyCode.DOWN);
                Keyboard.Sleep(delay)
                    .KeyPress(VirtualKeyCode.UP)
                    .Sleep(10)
                    .KeyPress(VirtualKeyCode.DOWN);
            }
        }
    }
}
