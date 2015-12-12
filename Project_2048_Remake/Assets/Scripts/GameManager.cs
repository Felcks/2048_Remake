using UnityEngine;
using System.Collections;

public enum DIRECTION { UP, RIGHT, DOWN, LEFT };
public class GameManager : MonoBehaviour {
	public Tile[][] allTiles;
	public int matrixSize = 4;

	private void Start(){
		this.allTiles = new Tile[this.matrixSize][];
		//Starting allTiles as Empty
		for (int i=0; i<this.allTiles.Length; i++) {
			this.allTiles [i] = new Tile[this.matrixSize];
			for (int j=0; j<this.allTiles.Length; j++) {
				this.allTiles [i] [j] = new Empty (i,j);
			}
		}
		//Creating the firsts two tiles
		this.CreateTile ();
		this.CreateTile ();
	}

	private void Update(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			this.Move(DIRECTION.UP);
			this.CreateTile ();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.Move(DIRECTION.RIGHT);
			this.CreateTile ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			this.Move(DIRECTION.DOWN);
			this.CreateTile ();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.Move(DIRECTION.LEFT);
			this.CreateTile ();
		}
	}

	private void Move(DIRECTION direction){
		if(direction == DIRECTION.LEFT || direction == DIRECTION.UP)
		for (int i=0; i<this.allTiles.Length; i++) {
			for (int j=0; j<this.allTiles.Length; j++) {
				if(this.allTiles[i][j].tileType == TILETYPE.NUMBER){
					this.CheckNext(i,j,direction);
				}
			}
		}
		else
		for (int i=3; i>=0; i--) {
			for (int j=3; j>=0; j--) {
				if(this.allTiles[i][j].tileType == TILETYPE.NUMBER){
					this.CheckNext(i,j,direction);
				}
			}
		}
	}

	private void CheckNext(int x, int y, DIRECTION direction){
		//Check where is my next tile depending of the direction
		int nextX = 0;
		int nextY = 0;
		switch (direction) {
		case DIRECTION.UP:
			nextY = -1;
			break;
		case DIRECTION.RIGHT:
			nextX = 1;
			break;
		case DIRECTION.DOWN:
			nextY = 1;
			break;
		case DIRECTION.LEFT:
			nextX = -1;
			break;
		}
		//Check if is possible
		if (x + nextX < 0 || x + nextX > 3)
			return;
		if (y + nextY < 0 || y + nextY > 3)
			return;

		//Get next tile
		Tile nextTile = this.allTiles [x + nextX] [y + nextY];
		//Trade tiles if next equals a empty
		if (nextTile.tileType == TILETYPE.EMPTY) {
			Tile temp = this.allTiles [x] [y];
			this.allTiles [x] [y] = nextTile;
			this.allTiles[x][y].UpdateXY(x , y);
			this.allTiles [x + nextX] [y + nextY] = temp; 
			this.allTiles [x + nextX] [y + nextY].UpdateXY (x + nextX, y + nextY);
			CheckNext(x + nextX, y + nextY, direction);
		}
		//Merge if numbers are equal
		if (nextTile.tileType == TILETYPE.NUMBER) {
			if(nextTile.GetValue() == allTiles[x][y].GetValue()){
				nextTile.MergeValue();
				//Destroy current numberGameObj and creates another
				Destroy(nextTile.GetGameObject());
				GameObject newNumber = (GameObject)Instantiate(nextTile.GetPrefabGameObject(),new Vector3(0,0,0),Quaternion.identity);
				nextTile.SetGameObject(newNumber);
				nextTile.UpdatePos();
				//Destroy other numberGameObj and creates a empty tile
				Destroy(this.allTiles[x][y].GetGameObject());
				this.allTiles[x][y] = new Empty(x,y);
			}
		}
	}

	private void CreateTile(){
		//Get a Empty Tile
		Tile tile = null;
		do {
			tile = this.RaffleTile ();
		} while (tile.tileType != TILETYPE.EMPTY);
		//Change Empty Tile for a Number
		Number number = new Number (tile.x, tile.y, 2);
		number.numberGameObj = (GameObject)Instantiate (number.prefabNumber, GetTilePos(tile.x, tile.y),
		                                                    Quaternion.identity);
		number.UpdatePos ();
		this.allTiles [tile.x] [tile.y] = number;
	}

	private Tile RaffleTile(){
		int x = Random.Range (0, this.matrixSize);
		int y = Random.Range (0, this.matrixSize);
		return allTiles [x] [y];
	}

	private Vector3 GetTilePos(int x, int y){
		float posX = -350 +180 * x;
		float posY = 350 + -180 * y;
		Vector3 tilePos = new Vector3 (posX, posY, 0); 
		return tilePos;
	}
}
