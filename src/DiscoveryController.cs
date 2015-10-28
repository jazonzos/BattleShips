
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SwinGameSDK;
using static GameController;
using static UtilityFunctions;
using static GameResources;
/// <summary>
/// The battle phase is handled by the DiscoveryController.
/// </summary>
static class DiscoveryController
{

    /// <summary>
    /// Handles input during the discovery phase of the game.
    /// </summary>
    /// <remarks>
    /// Escape opens the game menu. Clicking the mouse will
    /// attack a location.
    /// </remarks>
    /// 

    private const int TOP_BUTTONS_TOP = 85;
    private const int TEXT_OFFSET = 5;
    private const int TEXT_OFFSET_HEIGHT = 20;
    private const int PLAY_BUTTON_LEFT = 693;

    public static void HandleDiscoveryInput()
	{
		if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) {
			AddNewState(GameState.ViewingGameMenu);
		}


		if (SwinGame.MouseClicked(MouseButton.LeftButton)) 
        {
            //@Issue 9 Lai Hoang Thanh Nguyen 05/10/2015
            //catch clicking action
            if (IsMouseInRectangle(PLAY_BUTTON_LEFT + TEXT_OFFSET, TOP_BUTTONS_TOP, 40, TEXT_OFFSET_HEIGHT))
            {
                //Todo: reset game
                EndDeployment(isReset: true);
               
                DrawDiscovery();
            }

            //@Issue 5
            if (IsMouseInRectangle(600, 73, 150, 30))
            {
                EndCurrentState();
            }

            else
            {
                DoAttack();
            }
		}
	}

	/// <summary>
	/// Attack the location that the mouse if over.
	/// </summary>
	private static void DoAttack()
	{
		Point2D mouse = default(Point2D);

		mouse = SwinGame.MousePosition();

		//Calculate the row/col clicked
		int row = 0;
		int col = 0;
		row = Convert.ToInt32(Math.Floor((mouse.Y - FIELD_TOP) / (CELL_HEIGHT + CELL_GAP)));
		col = Convert.ToInt32(Math.Floor((mouse.X - FIELD_LEFT) / (CELL_WIDTH + CELL_GAP)));

		if (row >= 0 & row < HumanPlayer.EnemyGrid.Height) {
			if (col >= 0 & col < HumanPlayer.EnemyGrid.Width) {
				Attack(row, col);
			}
		}
	}

    /// <summary>
    /// Draws the game during the attack phase.
    /// </summary>s
    /// 
    public static void DrawDiscovery()
	{
		const int SCORES_LEFT = 172;
		const int SHOTS_TOP = 157;
		const int HITS_TOP = 206;
		const int SPLASH_TOP = 256;

		if ((SwinGame.KeyDown(KeyCode.vk_LSHIFT) | SwinGame.KeyDown(KeyCode.vk_RSHIFT)) & SwinGame.KeyDown(KeyCode.vk_c)) {
			DrawField(HumanPlayer.EnemyGrid, ComputerPlayer, true);
		} else {
			DrawField(HumanPlayer.EnemyGrid, ComputerPlayer, false);
		}

		DrawSmallField(HumanPlayer.PlayerGrid, HumanPlayer);
		DrawMessage();

		SwinGame.DrawText(HumanPlayer.Shots.ToString(), Color.White, GameFont("Menu"), SCORES_LEFT, SHOTS_TOP);
		SwinGame.DrawText(HumanPlayer.Hits.ToString(), Color.White, GameFont("Menu"), SCORES_LEFT, HITS_TOP);
		SwinGame.DrawText(HumanPlayer.Missed.ToString(), Color.White, GameFont("Menu"), SCORES_LEFT, SPLASH_TOP);

        //@Issue 9 Lai Hoang Thanh Nguyen 05/09/2015
        SwinGame.DrawText("RESET", Color.Yellow, GameFont("Courier"), PLAY_BUTTON_LEFT + TEXT_OFFSET, TOP_BUTTONS_TOP);

        //$Iuuse 5
        SwinGame.DrawBitmap(GameImage("ResetButton"), 600, 73);
    }

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
