
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
// using System.Data;
using System.Diagnostics;
/// <summary>
/// The SeaGrid is the grid upon which the ships are deployed.
/// </summary>
/// <remarks>
/// The grid is viewable via the ISeaGrid interface as a read only
/// grid. This can be used in conjuncture with the SeaGridAdapter to
/// mask the position of the ships.
/// </remarks>
[Serializable]
public class SeaGrid : ISeaGrid
{

	private const int _WIDTH = 10;

	private const int _HEIGHT = 10;
	private Tile[,] _GameTiles;
	private Dictionary<ShipName, Ship> _Ships;

	private int _ShipsKilled = 0;

    public Tile[,] GetGameTitles {
        get { return _GameTiles; }
    }
    

	/// <summary>
	/// The sea grid has changed and should be redrawn.
	/// </summary>
	public event EventHandler Changed;

	/// <summary>
	/// The width of the sea grid.
	/// </summary>
	/// <value>The width of the sea grid.</value>
	/// <returns>The width of the sea grid.</returns>
	public int Width {
		get { return _WIDTH; }
	}

	/// <summary>
	/// The height of the sea grid
	/// </summary>
	/// <value>The height of the sea grid</value>
	/// <returns>The height of the sea grid</returns>
	public int Height {
		get { return _HEIGHT; }
	}

	/// <summary>
	/// ShipsKilled returns the number of ships killed
	/// </summary>
	public int ShipsKilled {
		get { return _ShipsKilled; }
	}

	/// <summary>
	/// Show the tile view
	/// </summary>
	/// <param name="x">x coordinate of the tile</param>
	/// <param name="y">y coordiante of the tile</param>
	/// <returns></returns>
	public TileView this[int x, int y]
	{
		get { return _GameTiles[x, y].View; }
	}

	/// <summary>
	/// AllDeployed checks if all the ships are deployed
	/// </summary>
	public bool AllDeployed {
		get {
			foreach (Ship s in _Ships.Values) {
				if (!s.IsDeployed) {
					return false;
				}
			}

			return true;
		}
	}

	/// <summary>
	/// SeaGrid constructor, a seagrid has a number of tiles stored in an array
	/// </summary>
	public SeaGrid(Dictionary<ShipName, Ship> ships)
	{
		_GameTiles = new Tile[Width, Height];
		//fill array with empty Tiles
		int i = 0;
		for (i = 0; i <= Width - 1; i++) {
			for (int j = 0; j <= Height - 1; j++) {
				_GameTiles[i, j] = new Tile(i, j, null);
			}
		}

		_Ships = ships;
	}

	/// <summary>
	/// MoveShips allows for ships to be placed on the seagrid
	/// </summary>
	/// <param name="row">the row selected</param>
	/// <param name="col">the column selected</param>
	/// <param name="ship">the ship selected</param>
	/// <param name="direction">the direction the ship is going</param>
	public void MoveShip(int row, int col, ShipName ship, Direction direction)
	{
		Ship newShip = _Ships[ship];
        //@Issue2 @Lai Hoang Thanh Nguyen 16/09/2015 keep old position when ship location having error
        int oldRow = newShip.Row;
        int oldColumn = newShip.Column;
        Direction oldDirection = newShip.Direction;
        newShip.Remove();
		AddShip(row, col, direction, newShip, oldDirection, oldRow, oldColumn);
	}

    /// <summary>
    /// @Issue3
    /// @Lai Hoang Thanh Nguyen 
    /// 16/09/2015
    /// ChangeShipDirection allows for ships directing in current location.
    /// </summary>
    /// <param name="ship"></param>
    /// <param name="direction"></param>
    public void ChangeShipDirection(ShipName ship, Direction direction)
    {
        Ship newShip = _Ships[ship];
        int oldRow = newShip.Row;
        int oldColumn = newShip.Column;
        Direction oldDirection = newShip.Direction;
        newShip.Remove();
        AddShip(oldRow, oldColumn, direction, newShip, oldDirection, oldRow, oldColumn);
    }


    /// <summary>
    ///  AddShip add a ship to the SeaGrid
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="direction"></param>
    /// <param name="newShip"></param>
    /// <param name="oldRow"></param>
    /// <param name="oldCol"></param>
    /// <param name="oldDirection"></param>
    private void AddShip(int row, int col, Direction direction, Ship newShip, Direction? oldDirection = null, int oldRow = -99, int oldCol = -99)
	{
		try {
			int size = newShip.Size;
			int currentRow = row;
			int currentCol = col;
			int dRow = 0;
			int dCol = 0;

            if (direction == Direction.LeftRight)
            {
                dRow = 0;
                dCol = 1;
            }
            else if (direction == Direction.UpDown)
            {
                dRow = 1;
                dCol = 0;
            }

			//place ship's tiles in array and into ship object
			int i = 0;
			for (i = 0; i <= size - 1; i++) {
				if (currentRow < 0 | currentRow >= Width | currentCol < 0 | currentCol >= Height) {
					throw new InvalidOperationException("Ship can't fit on the board");
				}

				_GameTiles[currentRow, currentCol].Ship = newShip;

				currentCol += dCol;
				currentRow += dRow;
			}
            //@Lai Hoang Thanh Nguyen 16/09/2015 
            //fixed error wrong passing row and col variables
			newShip.Deployed(direction, row, col);
		} catch (Exception e) {
            //@Issue2 @LaiHoang Thanh Nguyen 16/09/2015 re-generate old position instead of deleting a new wrong position. 
            if (oldRow != -99 && oldDirection != null)
            {
                newShip.Remove();
                AddShip(oldRow, oldCol, oldDirection.Value, newShip); 
            }
            else
            {
                newShip.Remove();
            }
                //if fails remove the ship
            throw new ApplicationException(e.Message);

		} finally {
			if (Changed != null) {
				Changed(this, EventArgs.Empty);
			}
		}
	}

	/// <summary>
	/// HitTile hits a tile at a row/col, and whatever tile has been hit, a
	/// result will be displayed.
	/// </summary>
	/// <param name="row">the row at which is being shot</param>
	/// <param name="col">the cloumn at which is being shot</param>
	/// <returns>An attackresult (hit, miss, sunk, shotalready)</returns>
	public AttackResult HitTile(int row, int col)
	{
		try {
			//tile is already hit
			if (_GameTiles[row, col].Shot) {
				return new AttackResult(ResultOfAttack.ShotAlready, "have already attacked [" + col + "," + row + "]!", row, col);
			}

			_GameTiles[row, col].Shoot();

			//there is no ship on the tile
			if (_GameTiles[row, col].Ship == null) {
				return new AttackResult(ResultOfAttack.Miss, "missed", row, col);
			}

			//all ship's tiles have been destroyed
			if (_GameTiles[row, col].Ship.IsDestroyed) {
				_GameTiles[row, col].Shot = true;
				_ShipsKilled += 1;
				return new AttackResult(ResultOfAttack.Destroyed, _GameTiles[row, col].Ship, "destroyed the enemy's", row, col);
			}

			//else hit but not destroyed
			return new AttackResult(ResultOfAttack.Hit, "hit something!", row, col);
		} finally {
			if (Changed != null) {
				Changed(this, EventArgs.Empty);
			}
		}
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
