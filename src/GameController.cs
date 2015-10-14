
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SwinGameSDK;
using static UtilityFunctions;
using static GameResources;
using static DeploymentController;
using static DiscoveryController;
using static EndingGameController;
using static MenuController;
using static HighScoreController;
/// <summary>
/// The GameController is responsible for controlling the game,
/// managing user input, and displaying the current state of the
/// game.
/// </summary>
static class GameController
{
	private static BattleShipsGame _theGame;
	private static Player _human;

	private static AIPlayer _ai;
    private static Stack<GameState> _state = new Stack<GameState>();

	private static AIOption _aiSetting;
	/// <summary>
	/// Returns the current state of the game, indicating which screen is
	/// currently being used
	/// </summary>
	/// <value>The current state</value>
	/// <returns>The current state</returns>
	public static GameState CurrentState {
		get { return _state.Peek(); }
	}

	/// <summary>
	/// Returns the human player.
	/// </summary>
	/// <value>the human player</value>
	/// <returns>the human player</returns>
	public static Player HumanPlayer {
		get { return _human; }
	}

	/// <summary>
	/// Returns the computer player.
	/// </summary>
	/// <value>the computer player</value>
	/// <returns>the conputer player</returns>
	public static Player ComputerPlayer {
		get { return _ai; }
	}

	static GameController()
	{
		//bottom state will be quitting. If player exits main menu then the game is over
		_state.Push(GameState.Quitting);

		//at the start the player is viewing the main menu
		_state.Push(GameState.ViewingMainMenu);
	}

	/// <summary>
	/// Starts a new game.
	/// </summary>
	/// <remarks>
	/// Creates an AI player based upon the _aiSetting.
	/// </remarks>
	public static void StartGame()
	{
		if (_theGame != null)
			EndGame();

		//Create the game
		_theGame = new BattleShipsGame();

		//create the players
		switch (_aiSetting) {
			case AIOption.Medium:
				_ai = new AIMediumPlayer(_theGame);
                break;
			case AIOption.Hard:
				_ai = new AIHardPlayer(_theGame);
                break;
			default:
				_ai = new AIHardPlayer(_theGame);
                break;
		}

        _human = new Player(_theGame);

        //AddHandler _human.PlayerGrid.Changed, AddressOf GridChanged
        _ai.PlayerGrid.Changed += GridChanged;
        _theGame.AttackCompleted += AttackCompleted;
		AddNewState(GameState.Deploying);
	}

	/// <summary>
	/// Stops listening to the old game once a new game is started
	/// </summary>

	private static void EndGame()
	{
		//RemoveHandler _human.PlayerGrid.Changed, AddressOf GridChanged
		_ai.PlayerGrid.Changed -= GridChanged;
		_theGame.AttackCompleted -= AttackCompleted;
	}

	/// <summary>
	/// Listens to the game grids for any changes and redraws the screen
	/// when the grids change
	/// </summary>
	/// <param name="sender">the grid that changed</param>
	/// <param name="args">not used</param>
	private static void GridChanged(object sender, EventArgs args)
	{
		DrawScreen();
		SwinGame.RefreshScreen();
	}

	private static void PlayHitSequence(int row, int column, bool showAnimation)
	{
		if (showAnimation) {
			AddExplosion(row, column);
		}

		Audio.PlaySoundEffect(GameSound("Hit"));

		DrawAnimationSequence();
	}

	private static void PlayMissSequence(int row, int column, bool showAnimation)
	{
		if (showAnimation) {
			AddSplash(row, column);
		}

		Audio.PlaySoundEffect(GameSound("Miss"));

		DrawAnimationSequence();
	}

	/// <summary>
	/// Listens for attacks to be completed.
	/// </summary>
	/// <param name="sender">the game</param>
	/// <param name="result">the result of the attack</param>
	/// <remarks>
	/// Displays a message, plays sound and redraws the screen
	/// </remarks>
	private static void AttackCompleted(object sender, AttackResult result)
	{
		bool isHuman = false;
		isHuman = object.ReferenceEquals(_theGame.Player, HumanPlayer);

		if (isHuman) {
			Message = "You " + result.ToString();
		} else {
			Message = "The AI " + result.ToString();
		}

		switch (result.Value) {
			case ResultOfAttack.Destroyed:
				PlayHitSequence(result.Row, result.Column, isHuman);
				Audio.PlaySoundEffect(GameSound("Sink"));

				break;
			case ResultOfAttack.GameOver:
				PlayHitSequence(result.Row, result.Column, isHuman);
				Audio.PlaySoundEffect(GameSound("Sink"));

				while (Audio.SoundEffectPlaying(GameSound("Sink"))) {
					SwinGame.Delay(10);
					SwinGame.RefreshScreen();
				}

				if (HumanPlayer.IsDestroyed) {
					Audio.PlaySoundEffect(GameSound("Lose"));
				} else {
					Audio.PlaySoundEffect(GameSound("Winner"));
				}

				break;
			case ResultOfAttack.Hit:
				PlayHitSequence(result.Row, result.Column, isHuman);
				break;
			case ResultOfAttack.Miss:
				PlayMissSequence(result.Row, result.Column, isHuman);
				break;
			case ResultOfAttack.ShotAlready:
				Audio.PlaySoundEffect(GameSound("Error"));
				break;
		}
	}

    /// <summary>
    /// Completes the deployment phase of the game and
    /// switches to the battle mode (Discovering state)
    /// </summary>
    /// <remarks>
    /// This adds the players to the game before switching
    /// state.
    /// </remarks>

    private static Player _backup_player;
    private static AIPlayer _backup_aiplayer;
    public static void EndDeployment(bool isReset = false, bool isFirst = false)
	{

        if (isReset)
        {

            _human = ObjectCopier.Clone(_backup_player);
            _ai = ObjectCopier.Clone(_backup_aiplayer);
            _theGame.ResetDeployedPlayer();

            //_human.Enemy = _backup_player.Enemy;
            //_human.EnemyGrid = _backup_player.EnemyGrid;
            //_human.Game = _backup_player.Game;
            //_human.Hits = _backup_player.Hits;
            //_human.Missed = _backup_player.Missed;
            //_human.PlayerGrid = _backup_player.PlayerGrid;
            //_human.Shots = _backup_player.Shots;

            //_ai.Enemy = _backup_aiplayer.Enemy;
            //_ai.EnemyGrid = _backup_aiplayer.EnemyGrid;
            //_ai.Game = _backup_aiplayer.Game;
            //_ai.Hits = _backup_aiplayer.Hits;
            //_ai.Missed = _backup_aiplayer.Missed;
            //_ai.PlayerGrid = _backup_aiplayer.PlayerGrid;
            //_ai.Shots = _backup_aiplayer.Shots;
            _theGame.AddDeployedPlayer(_human);
            _theGame.AddDeployedPlayer(_ai);
        }
        else
        {
            //deploy the players
            _theGame.AddDeployedPlayer(_human);
            _theGame.AddDeployedPlayer(_ai);

            if (isFirst)
            {
                _backup_player = ObjectCopier.Clone(_human);
                _backup_aiplayer = ObjectCopier.Clone(_ai);
            }
          
          
        }
        SwitchState(GameState.Discovering);
    }

	/// <summary>
	/// Gets the player to attack the indicated row and column.
	/// </summary>
	/// <param name="row">the row to attack</param>
	/// <param name="col">the column to attack</param>
	/// <remarks>
	/// Checks the attack result once the attack is complete
	/// </remarks>
	public static void Attack(int row, int col)
	{
		AttackResult result = default(AttackResult);
		result = _theGame.Shoot(row, col);
        CheckAttackResult(result);
	}

	/// <summary>
	/// Gets the AI to attack.
	/// </summary>
	/// <remarks>
	/// Checks the attack result once the attack is complete.
	/// </remarks>
	private static void AIAttack()
	{
		AttackResult result = default(AttackResult);
        result = _theGame.Player.Attack();
        if (result.Value == ResultOfAttack.Miss)
        {
            _theGame.setPlayerIndex(0);
        }
        else
        {
            _theGame.setPlayerIndex(1);
        }
        CheckAttackResult(result);
	}

	/// <summary>
	/// Checks the results of the attack and switches to
	/// Ending the Game if the result was game over.
	/// </summary>
	/// <param name="result">the result of the last
	/// attack</param>
	/// <remarks>Gets the AI to attack if the result switched
	/// to the AI player.</remarks>
	private static void CheckAttackResult(AttackResult result)
	{
		switch (result.Value) {
			case ResultOfAttack.Miss:
                if (object.ReferenceEquals(_theGame.Player, ComputerPlayer) && _theGame.getPlayerIndex() == 1) // when human miss
                {
                    _theGame.setPlayerIndex(1);
                    AIAttack();
                }
                else
                    _theGame.setPlayerIndex(0);
                break;
			case ResultOfAttack.GameOver:
				SwitchState(GameState.EndingGame);
				break;
		}
	}

	/// <summary>
	/// Handles the user SwinGame.
	/// </summary>
	/// <remarks>
	/// Reads key and mouse input and converts these into
	/// actions for the game to perform. The actions
	/// performed depend upon the state of the game.
	/// </remarks>
	public static void HandleUserInput()
	{
		//Read incoming input events
		SwinGame.ProcessEvents();

		switch (CurrentState) {
			case GameState.ViewingMainMenu:
				HandleMainMenuInput();
				break;
			case GameState.ViewingGameMenu:
				HandleGameMenuInput();
				break;
			case GameState.AlteringSettings:
				HandleSetupMenuInput();
				break;
			case GameState.Deploying:
				HandleDeploymentInput();
				break;
			case GameState.Discovering:
				HandleDiscoveryInput();
				break;
			case GameState.EndingGame:
				HandleEndOfGameInput();
				break;
			case GameState.ViewingHighScores:
				HandleHighScoreInput();
				break;
		}

		UpdateAnimations();
	}

	/// <summary>
	/// Draws the current state of the game to the screen.
	/// </summary>
	/// <remarks>
	/// What is drawn depends upon the state of the game.
	/// </remarks>
	public static void DrawScreen()
	{
		DrawBackground();

		switch (CurrentState) {
			case GameState.ViewingMainMenu:
                DrawMainMenu();
				break;
			case GameState.ViewingGameMenu:
				DrawGameMenu();
				break;
			case GameState.AlteringSettings:
				DrawSettings();
				break;
			case GameState.Deploying:
				DrawDeployment();
                break;
			case GameState.Discovering:
				DrawDiscovery();
                DrawField(ComputerPlayer.PlayerGrid, ComputerPlayer, true);
               
                break;
			case GameState.EndingGame:
				DrawEndOfGame();
				break;
			case GameState.ViewingHighScores:
				DrawHighScores();
				break;
		}

		DrawAnimations();

		SwinGame.RefreshScreen();
	}

	/// <summary>
	/// Move the game to a new state. The current state is maintained
	/// so that it can be returned to.
	/// </summary>
	/// <param name="state">the new game state</param>
	public static void AddNewState(GameState state)
	{
		_state.Push(state);
		Message = "";
	}

	/// <summary>
	/// End the current state and add in the new state.
	/// </summary>
	/// <param name="newState">the new state of the game</param>
	public static void SwitchState(GameState newState)
	{
		EndCurrentState();
		AddNewState(newState);
	}

	/// <summary>
	/// Ends the current state, returning to the prior state
	/// </summary>
	public static void EndCurrentState()
	{
		_state.Pop();
	}

	/// <summary>
	/// Sets the difficulty for the next level of the game.
	/// </summary>
	/// <param name="setting">the new difficulty level</param>
	public static void SetDifficulty(AIOption setting)
	{
		_aiSetting = setting;
	}

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
