using System.AddIn;
using System.AddIn.Hosting;
using System.Collections.Generic;

namespace LofiPlayer
{
    public class GameLoader
    {
        public List<AddInToken> AddIns;

        public GameLoader()
        {
            AddIns = new List<AddInToken>();
        }

        public void SearchGames(string gamePath)
        {
        }
    }
}