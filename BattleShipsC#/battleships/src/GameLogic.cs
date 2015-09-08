
using SwinGameSDK;
static class GameLogic
{

	public static void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();

        SwinGame.PlayMusic(GameResources.GameMusic("Background"));
        //Lai Hoang Thanh Nguyen
        //05/09/2015
        //init construction of GameController
        GameController gameController = new GameController();
		//Game Loop
		do {
            GameController.HandleUserInput();
            GameController.DrawScreen();
        } while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
        GameResources.FreeResources();
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
