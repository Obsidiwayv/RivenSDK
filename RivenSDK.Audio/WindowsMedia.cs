using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace RivenSDK.Audio
{
    public class RivenWindowsMedia : RivenAudio<Uri>, ICommonRivenAudio
    {
        private MediaPlayer media = new();

        public void LoadSound(string name, string path)
        {
            sounds[name] = new Uri(path, UriKind.Relative);
        }

        public void PlaySound(string source)
        {
            if (sounds.TryGetValue(source, out var path)) 
            {
                media.Play();
            }
        }

        public void Stop()
        {
            media.Stop();
        }

        public void UpdateSystem()
        {
            return;
        }
    }
}
