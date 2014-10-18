using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using ContentManager = Microsoft.Xna.Framework.Content.ContentManager;
using System.IO;

namespace Lofinil.GameSDK.Engine
{

    public enum ContentType
    {
        None,
        Texture,
        Font,
        Song,
        Sound,
    }

    public class XNAContent
    {
        public static Object LoadContent(Microsoft.Xna.Framework.Content.ContentManager cm, ContentType type, String file)
        {
            String contentDir = GameService.Instance.GameConfig.ContentPath;
            switch(type)
            {
                case ContentType.Texture:
                    return cm.Load<Texture2D>(Path.Combine(contentDir, file));
                case ContentType.Font:
                    return cm.Load<SpriteFont>(Path.Combine(contentDir, file));
                case ContentType.Sound:
                    return cm.Load<SoundEffect>(Path.Combine(contentDir, file));
                case ContentType.Song:
                    return cm.Load<Song>(Path.Combine(contentDir, file));
            }
            return null;
        }
    }
}
