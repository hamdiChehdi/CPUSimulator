using System;

namespace Domain
{
    public class RegisterMemory
    {
        private static uint[] registers = new uint[43];

        public static uint Get(int index)
        {
            return registers[index];
        }

        public static void Set(int index, uint value)
        {
            registers[index] = value;
            RaiseChange(index, value);
        }

        public static void Reset()
        {
            Array.Clear(registers, 0, 43);
            RaiseReset();
        }

        public static Action<int, uint> OnRegisterChange { get; set; }
        public static Action OnRegisterReset { get; set; }

        private static void RaiseChange(int index, uint value)
        {
            //Check if OnChange Action is set before invoking it
            if (OnRegisterChange is not null)
            {
                //Invoke OnChange Action
                OnRegisterChange(index, value);
            }
        }

        private static void RaiseReset()
        {
            //Check if OnChange Action is set before invoking it
            if (OnRegisterReset is not null)
            {
                //Invoke OnChange Action
                OnRegisterReset();
            }
        }
    }
}
