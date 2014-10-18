using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    public class Storage
    {
        public static StorageDevice GetStorageDevice()
        {
            StorageDevice storageDevice = null;
            IAsyncResult result = StorageDevice.BeginShowSelector(PlayerIndex.One, null, null);
            storageDevice = StorageDevice.EndShowSelector(result);
            return storageDevice;
        }
    }
}
