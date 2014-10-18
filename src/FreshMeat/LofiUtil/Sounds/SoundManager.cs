using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using LofiUtil.Helpers;

namespace LofiUtil.Sounds
{
    /// <summary>
    /// 声音管理器类
    /// </summary>
    public class SoundMgr
    {
        #region Variables
        SoundEffect soundEffect;
        SoundEffectInstance soundEffectInstance;
        Song song;
        #endregion

        #region Instance
        private static SoundMgr instance;
        /// <summary>
        /// 实例
        /// </summary>
        public static SoundMgr Instance
        {
            get
            {
                if (instance == null)
                    instance = new SoundMgr();
                return instance;
            }
        }
        private SoundMgr()
        { 
        }
        #endregion

        #region Song Control
        /// <summary>
        /// 设置音乐
        /// </summary>
        /// <param name="songPath"></param>
        public void SetSong(String songPath)
        {
            song = LoadHelper.LoadSong(songPath);
        }
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
        #endregion

        #region Sound Control
        /// <summary>
        /// 设置音效
        /// </summary>
        public void SetSound(String soundPath)
        {
            soundEffect = LoadHelper.LoadSound(soundPath);
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
        public void SetSoundParam(float volumeScale, float pan, float pitch)
        {
            soundEffectInstance.Volume = volumeScale;   // 0.0 ~ 1.0
            soundEffectInstance.Pan = pan;              //  -1 ~   1   左 ~ 右
                soundEffectInstance.Pitch = pitch;      //  -1 ~   1   下 ~ 上
        }
        #endregion
    }
}
