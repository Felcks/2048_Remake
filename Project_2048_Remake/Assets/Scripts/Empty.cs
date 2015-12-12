using UnityEngine;
using System.Collections;

public class Empty : Tile {
	public Empty(int x, int y){
		this.tileType = TILETYPE.EMPTY;
		this.x = x;
		this.y = y;
	}

	public override void UpdateXY(int x, int y){
		this.x = x;
		this.y = y;
	}
}
