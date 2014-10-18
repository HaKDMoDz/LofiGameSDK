using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Lofinil.GameSDK.Engine
{
    // 声音管理器类
    public class Sound
    {
        #region Variables

        Microsoft.Xna.Framework.Audio.SoundEffect soundEffect;
        SoundEffectInstance soundEffectInstance;

        #endregion Variables

        private ContentModule resMgr;

        public Sound()
        {
            resMgr = Game.QueryModule<ContentModule>();
        }

        #region Song Control

        /// <summary>
        /// 播放音乐
        /// </summary>
        public void PlaySong(Song song)
        {
            if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(song);
            }
        }

        public void PlaySong(String song)
        {
            Song s = (Song)resMgr.GetContent(ContentType.Sound, song);
            PlaySong(s);
        }

        /// <summary>
        /// 停止音乐
        /// </summary>
        public void StopSong()
        {
            if (MediaPlayer.State != MediaState.Stopped)
            {
                MediaPlayer.Stop();
            }
        }

        /// <summary>
        /// 音乐暂停和继续
        /// </summary>
        public void SongPauseAndResume()
        {
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Pause();
            }
            else if (MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Resume();
            }
        }

        /// <summary>
        /// 设置音乐音量
        /// </summary>
        /// <param name="scale">音量百分比</param>
        public void SetSongVolumn(float scale)
        {
            MediaPlayer.Volume = scale;

            // 相关 -- WP7模拟器声音设定Bug：http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.media.mediaplayer.volume.aspx
        }

        #endregion Song Control

        #region Sound Control

        public void PlaySound(String path, bool isLoop)
        {
            SetSound(path);
            SetSoundParam(1, 0, 0, isLoop);
            PlaySound();
        }

        /// <summary>
        /// 设置音效
        /// </summary>
        public void SetSound(String soundPath)
        {
            soundEffect = (Microsoft.Xna.Framework.Audio.SoundEffect)resMgr.GetContent(ContentType.Sound, soundPath);
            soundEffectInstance = soundEffect.CreateInstance();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        public void PlaySound()
        {
            if (soundEffectInstance.State == SoundState.Stopped)
            {
                soundEffectInstance.Play();
            }
            else if (soundEffectInstance.State == SoundState.Paused)
            {
                soundEffectInstance.Resume();
            }
        }

        /// <summary>
        /// 音效暂停和继续
        /// </summary>
        public void PauseSound()
        {
            if (soundEffectInstance.State == SoundState.Playing)
            {
                soundEffectInstance.Pause();
            }
            if (soundEffectInstance.State == SoundState.Paused)
            {
                soundEffectInstance.Resume();
            }
        }

        /// <summary>
        /// 停止播放音效
        /// </summary>
        public void StopSound()
        {
            if (soundEffectInstance.State != SoundState.Playing)
            {
                soundEffectInstance.Stop();
            }
        }

        /// <summary>
        /// 设置音效参数
        /// </summary>
        /// <param name="volumeScale">音量比例</param>
        /// <param name="pan">水平</param>
        /// <param name="pitch">俯仰</param>
        public void SetSoundParam(float volumeScale, float pan, float pitch, bool isLoop)
        {
            soundEffectInstance.Volume = volumeScale;   // 0.0 ~ 1.0
            soundEffectInstance.Pan = pan;              //  -1 ~   1   左 ~ 右
            soundEffectInstance.Pitch = pitch;      //  -1 ~   1   下 ~ 上
            soundEffectInstance.IsLooped = isLoop;
        }

        #endregion Sound Control

        public GameService Game
        {
            get { throw new NotImplementedException(); }
        }

        public bool Enabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}