using System;
using System.Collections.Generic;
using System.Text;

namespace RivenSDK.Audio
{
    public class RivenFmodSystem : RivenAudio<FMOD.Sound>, ICommonRivenAudio
    {
        private readonly FMOD.System _core;

        private FMOD.ChannelGroup group;

        public RivenFmodSystem() 
        {
            FMOD.Factory.System_Create(out _core);
            _core.init(512, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);

            _core.createChannelGroup("UI", out group);
        }

        public void LoadSound(string name, string path)
        {
            _core.createSound(path, FMOD.MODE.DEFAULT, out FMOD.Sound sound);
            sounds[name] = sound;
        }

        public void PlaySound(string name)
        {
            if (sounds.TryGetValue(name, out var sound))
            {
                _core.playSound(sound, group, false, out _);
            }
        }

        public void Stop()
        {
            group.stop();
        }

        public void UpdateSystem() => _core.update();

        ~RivenFmodSystem()
        {
            foreach (var sound in sounds.Values)
            {
                sound.release();
            }

            _core.close();
            _core.release();
        }
    }
}
