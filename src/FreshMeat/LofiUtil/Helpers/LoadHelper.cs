using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework.Storage;
using System.Threading;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace LofiUtil.Helpers
{
    public class LoadHelper
    {
        #region 初始化
        public static void Initialize(ContentManager content)
        {
            mContent = content;
        }
        #endregion

        #region Constants
        public static String TexturePath = "Content/Textures/";
        public static String FontPath = "Content/Fonts/";
        public static String ScenePath = "Content/Scenes/";
        public static String SongPath = "Content/Songs/";
        public static String DramaPath = "Content/Dramas/";
        #endregion 

        #region StorageDevice
        public static StorageDevice GetStorageDevice()
        {
            StorageDevice storageDevice = null;
            IAsyncResult result = StorageDevice.BeginShowSelector(PlayerIndex.One, null, null);
            storageDevice = StorageDevice.EndShowSelector(result);

            return storageDevice;
        }
        #endregion

        #region Variables
        private static ContentManager mContent;
        public static ContentManager Content
        {
            get { return mContent; }
        }
        #endregion

        static public Texture2D LoadTexture2D(string textureName)
        {
            if (StringHelper.IsNullOrEmpty(textureName))
            {
                Console.WriteLine("错误：贴图路径不允许为空");
                return null;
            }
            Texture2D texture = null;
            try
            {
                texture = Content.Load<Texture2D>(Path.Combine(TexturePath, textureName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误：找不到名称为{0}的贴图文件", textureName);
                Console.WriteLine("Info：" + ex.Message);
                return null;
            }
            return texture;
        }
        static public Song LoadSong(String songPath)
        {
            if (StringHelper.IsNullOrEmpty(songPath))
            {
                Console.WriteLine("错误：音乐路径不允许为空");
                return null;
            }
            Song s = null;
            try
            {
                s = Content.Load<Song>(Path.Combine(SongPath, songPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误：找不到名称为{0}的音乐文件", songPath);
                Console.WriteLine("Info：" + ex.Message);
                return null;
            }
            return s;
        }
        public static FileStream LoadFileStream(string filePath)
        {
            try
            {
                // TODO 编辑器模式下不适用TitleContainer
                // return TitleContainer.OpenStream(relativeFileName);
                return File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception ex)
            {
                Console.WriteLine("TitleContainter 载入文件时出现异常");
                Console.WriteLine("异常信息:"+ ex.Message);
                return null;
            }
        }

        #if WINDOWS
        // 编辑器写入场景文件时使用
        public static FileStream WriteFileStream(string absFilePath)
        {
            return File.Open(absFilePath,
                    FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            // 使用FileMode.Create完全覆盖已经存在的文件，避免新文件比旧文件小的问题
        }
        #endif

        static public SpriteFont LoadSpriteFont(string fontFileName)
        {
            return Content.Load<SpriteFont>(Path.Combine(FontPath, fontFileName));
        }
        internal static Microsoft.Xna.Framework.Audio.SoundEffect LoadSound(string soundPath)
        {
            throw new NotImplementedException();
        }

        #region Folder & File
        static public List<String> GetSceneNames()
        {
            List<string> nameList = new List<string>();
            foreach (String item in Directory.GetFiles(".\\Content\\Scenes"))
            {
                FileInfo fi = new FileInfo(item);
                if (fi.Extension == ".scn")
                {
                    nameList.Add(fi.Name.Split('.')[0]);
                }
            }
            return nameList;
        }
        static public List<String> GetPlayerNames()
        {
            List<string> nameList = new List<string>();


            StorageDevice sDevice = LoadHelper.GetStorageDevice();
            if ((sDevice != null) && sDevice.IsConnected)
            {
                // Wait for the WaitHandle to become signaled. ???
                IAsyncResult result =
                    sDevice.BeginOpenContainer("SDF", null, null);

                result.AsyncWaitHandle.WaitOne();


                using (StorageContainer sContainter = sDevice.EndOpenContainer(result))
                {
                    
                    foreach (String item in sContainter.GetFileNames())
                    {
                        FileInfo fi = new FileInfo(item);
                        if (fi.Extension == ".sav")
                        {
                            nameList.Add(fi.Name.Split('.')[0]);
                        }
                    }
                }
            }
            return nameList;
        }
        #endregion

    }
}
