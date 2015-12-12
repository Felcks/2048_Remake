using UnityEngine;
using System.Collections;

public class Number : Tile {
	private int value;
	public GameObject prefabNumber, numberGameObj;

	public Number(int x, int y, int value){
		this.tileType = TILETYPE.NUMBER;
		this.x = x;
		this.y = y;
		this.value = value;
		this.prefabNumber = (GameObject)Resources.Load ("Prefabs/Number_" + this.value.ToString ());
	}

	public override void UpdatePos(){
		if (this.numberGameObj != null) {
			this.numberGameObj.transform.SetParent (GameObject.Find ("Canvas").transform); 
			this.numberGameObj.transform.localScale = new Vector3 (1, 1, 1);
			this.numberGameObj.GetComponent<RectTransform>().localPosition = new Vector3(-350 +180 * x, 350 + -180 * y, 0);
		}
	}

	public override void UpdateXY(int x, int y){
		this.x = x;
		this.y = y;
		this.UpdatePos ();
	}

	public override int GetValue(){
		return this.value;
	}

	public override void MergeValue(){
		this.value = this.value * 2;

	}

	public override GameObject GetGameObject(){
		return this.numberGameObj;
	}

	public override GameObject GetPrefabGameObject(){
		this.prefabNumber = (GameObject)Resources.Load ("Prefabs/Number_" + this.value.ToString ());
		return prefabNumber;
	}

	public override void SetGameObject (GameObject newGameObject){
		this.numberGameObj = newGameObject;
	}
}
