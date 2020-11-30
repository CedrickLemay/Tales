using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    class Misc
    {

        private static Misc instance = null;
        private static readonly object padlock = new object();       
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
      

        private Misc()
        {

        }

        //Function to get a random number
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                 if (instance == null)
                    {
                        instance = new Misc();
                    }
                return random.Next(min, max + 1);
            }
        }

        public static Misc Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Misc();
                    }
                    return instance;
                }
            }
        }


    }
}
