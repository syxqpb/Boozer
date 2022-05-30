using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts
{
    internal class GlobalEventManager
    {
        public static UnityEvent<int> onWaveEnded = new UnityEvent<int>();
        public static void SendWaveEnded(int waveCount)
        {
            onWaveEnded.Invoke(waveCount);
        }
    }
}
