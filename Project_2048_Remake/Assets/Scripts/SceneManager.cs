using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {
	public bool gameOver = false;
	private GameObject txt_GameOver, txt_TryAgain, btn_TryAgain, bg_GameOver;

	private void Start(){
		this.txt_GameOver = GameObject.Find ("txt_GameOver");
		this.txt_TryAgain = GameObject.Find ("txt_TryAgain");
		this.btn_TryAgain = GameObject.Find ("btn_TryAgain");
		this.bg_GameOver = GameObject.Find ("bg_GameOver");
	}

	public void TryAgain(){
		Application.LoadLevel (Application.loadedLevel);
	}

	private void Update(){
		if (this.gameOver == true) {
			Image image = this.bg_GameOver.GetComponent<Image>();
			if(image.color.a < 0.5f)
			this.bg_GameOver.GetComponent<Image>().color = new Color(image.color.r,image.color.g,image.color.b,image.color.a + 0.01f);

			RectTransform gameOverPos = GameObject.Find("GameOverPos").GetComponent<RectTransform>();
			Image image2 = this.btn_TryAgain.GetComponent<Image>();
			if(image2.color.a < 1f){
				this.btn_TryAgain.GetComponent<Image>().color = new Color(image2.color.r,image2.color.g,image2.color.b,image2.color.a + 0.01f);
				}

			Text text = this.txt_GameOver.GetComponent<Text>();
			if(text.color.a < 1f){
				this.txt_GameOver.GetComponent<Text>().color = new Color(text.color.r,text.color.g,text.color.b,text.color.a + 0.01f);
				this.txt_GameOver.GetComponent<RectTransform>().position = Vector3.Lerp(this.txt_GameOver.GetComponent<RectTransform>().position,
				                                                                        gameOverPos.transform.position, Time.deltaTime * 2);

			}

			Text text2 = this.txt_TryAgain.GetComponent<Text>();
			if(text2.color.a < 1f){
				this.txt_TryAgain.GetComponent<Text>().color = new Color(text2.color.r, text2.color.g,text2.color.b,text2.color.a + 0.01f);
				}


		}
	}
}
