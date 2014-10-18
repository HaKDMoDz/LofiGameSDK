using System;
namespace LofiPlayer
{
	static class Program
	{
		[STAThread]
		static void Main()
        {
            String gamesPath = "C:/Games";
            using (PlayerForm playerForm = new PlayerForm(gamesPath))
			{
				playerForm.ShowDialog();
				playerForm.LoadGame("BreakOutMario.GameEntrence");
			}
		}
	}
}