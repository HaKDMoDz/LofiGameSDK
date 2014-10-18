using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine
{
    public class SoundModule : BaseModule
    {
        protected Sound Sound;

        [Interact("声音", "播放音乐")]
        public void PlayMusic(String path) { Sound.PlaySong(path); }

        [Interact("声音", "停播音乐")]
        public void StopMusic() { Sound.StopSong(); }

        [Interact("声音", "播放音效")]
        public void PlaySound(String path, bool isLoop) { Sound.PlaySound(path, isLoop); }

        [Interact("声音", "停播音效")]
        public void StopSound() { Sound.StopSound(); }
    }
}
