using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    class SoundEffects
    {
        private static Plugin.SimpleAudioPlayer.ISimpleAudioPlayer tapEffect = null;
        public static void PlayTapEffect()
        {
            // Just in time initialisation
            if (tapEffect == null)
            {
                tapEffect = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                tapEffect.Load("tap.wav");
            }
            // Play the sound
            tapEffect.Play();
        }
    }
}
