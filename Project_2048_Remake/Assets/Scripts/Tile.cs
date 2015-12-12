using UnityEngine;
using System.Collections;

public enum TILETYPE { EMPTY, NUMBER };
public class Tile {
	public TILETYPE tileType = TILETYPE.EMPTY;
	public int x,y;

	public virtual void UpdatePos(){
	}

	public virtual void UpdateXY(int x, int y){
	}

	public virtual int GetValue(){
		return 0;
	}

	public virtual void MergeValue(){}

	public virtual GameObject GetGameObject(){
		return null;
	}

	public virtual GameObject GetPrefabGameObject(){
		return null;
	}

	public virtual void SetGameObject(GameObject newGameObject){

	}
}
