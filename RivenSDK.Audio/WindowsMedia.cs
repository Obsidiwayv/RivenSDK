using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace RivenSDK.Audio
{
    public class RivenWindowsMedia : RivenAudio<Uri>, ICommonRivenAudio
    {
        private MediaPlayer media = new();

        public void LoadSound(string _, string path)
        {
            media.Open(new Uri(path, UriKind.Relative));
        }

        public void PlaySound(string source)
        {
            media.Play();
        }

        public void Quit()
        {
            return;
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
