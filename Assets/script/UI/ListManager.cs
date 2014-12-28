using UnityEngine;
using System.Collections;


public class ListManager : MonoBehaviour {

		private string text = "\nA N S W E R L I S T \n000:<b>奇</b>跡ではなく<b>偶</b>然だった\n";
		public bool ongui=false;
		public GUISkin cinema;

		private float windowwidth;
		private float windowheight;
		private float fontsize;
		private float line=4.0f;

		public static float goal;
		private Color defc;
		private Color tempc;
	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.list = this.gameObject;

				//windowwidth = GameSceneManager.gm;
				windowwidth = Screen.width / 2.0f;
				windowheight = Screen.height / 3.0f;
				defc = cinema.window.normal.textColor;
				tempc = new Color (defc.r, defc.g, defc.b, 1f);
				iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));

	}
	
	// Update is called once per frame
	void Update () {

	}
		void visible (int type){
				ongui = true;
				iTween.ValueTo (this.gameObject,iTween.Hash("from",0.0f,"to",1.0f,"time",0.8f,"delay",0.4f,"onupdate","colorupdate","oncompletetarget",this.gameObject,"oncomplete","deq"));
		}
		void hide(int type){
				ongui = false;
				deq ();
				iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
				text = "A N S W E R L I S T \n000:<b>奇</b>跡ではなく<b>偶</b>然だった\n";
		}
		void colorupdate(float value){
				tempc.a = value;
				cinema.window.normal.textColor = tempc;
		}
		void goalcal(int type){
				//float f = Mathf.Log ((float)Screen.width/420f);
				//Debug.Log ("e is "+ f);
				line = (float)(GameSceneManager.floorNum) * 4.0f;// - f * 12.0f;
				//Debug.Log ("floor is " + GameSceneManager.floorNum);
				int i = GameSceneManager.floorNum-1;
				for(int j = 0;j<i;j++) text += answers[j];
				//Debug.Log ("text is " + text);
				goal = fontsize * line/2.0f;
				Debug.Log ("fontsize : " + fontsize);
				Debug.Log ("goal : "+ goal);
				windowheight = fontsize * line * 2.0f;
				GameSceneManager.movetogoallist.y = windowheight/2.0f;
				deq ();
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}

		void OnGUI(){
				fontsize = Screen.height / 48;
				cinema.window.fontSize = (int)fontsize;
				if (ongui) {
						windowheight = fontsize * line*4f;
						GUI.skin = cinema;
						var rect = new Rect ((Screen.width - windowwidth) / 2.0f, (Screen.height - windowheight+Screen.height / 13) / 2.0f+ Screen.height*105.0f/1136.0f, windowwidth, windowheight);
						GUI.Window (0, rect, fc, text);
				}

		}
		void fc(int windowID){}
		private string[] answers = new string[] 
		{
				"105 :いいたいほうだい\n",
				"     ￣\n",
				"203 :りべんじ\n","     ￣\n",
				"304 :ぐらいだー\n","     ￣\n",
				"403 :ちまなこ\n","     ￣\n",
				"501 :どぐう\n","     ￣\n",
				"603 :あほうどり\n","     ￣\n",
				"703 :ちょぞうこ\n","     ￣\n",
				"804 :かりぶかい\n","     ￣\n",
				"902 :のひつじ\n","     ￣\n",
				"1005:ひえらるきー\n","     ￣\n",
				"1103:つちだんご\n","     ￣\n",
				"1202:ぎしんあんき\n","     ￣\n"
		};
				
}
