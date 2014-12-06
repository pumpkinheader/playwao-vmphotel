using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

		private GameObject[] menus = new GameObject[11]; 
		public GameObject menutop;
		public GameObject menubottom;
		public GameObject menuback;
		public GameObject menucamera;
		public GameObject next;
		public GameObject closeobj;
		public GameObject answer;
		public GameObject menu,roomnum;
		public GameObject keyG,keyS;
		private BoxCollider2D keygb,keysb;
		private BoxCollider2D closeb,answerb,nextb;
		private float left,center,right;
		private Vector3 np,ap,cp;

		private float topclose,bottomclose,backscale,backsize;
		public static float full = 345f;
		private float goalformenu;
		public float backwidth;

		public float delay = 0.4f;

	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.menu = this.gameObject;
				menutop = GameObject.Find ("menutopbar");menus [0] = menutop;
				menubottom = GameObject.Find ("menubottombar");menus [1] = menubottom;
				menuback = GameObject.Find ("menuback");menus [2] = menuback;
				menucamera = GameObject.Find ("MenuCamera");menus [3] = menucamera;
				next = GameObject.Find ("next");menus [4] = next;
				answer = GameObject.Find ("answer");menus [5] = answer;
				closeobj = GameObject.Find ("close");menus [6] = closeobj;
				menu = GameObject.Find ("menustring");menus [7] = menu;
				roomnum = GameObject.Find ("roomnum");menus [8] = roomnum;
				keyG = GameObject.Find ("keyG");menus [9] = keyG;
				keyS = GameObject.Find ("keyS");menus [10] = keyS;
				keygb = keyG.GetComponent<BoxCollider2D>();
				keysb = keyS.GetComponent<BoxCollider2D>();
				keyoff (1);

				left = -450f;
				center =0f;
				right = 450f;


				np = next.transform.localPosition;
				ap = answer.transform.localPosition;
				cp = closeobj.transform.localPosition;

				closeb = closeobj.GetComponent<BoxCollider2D> ();
				answerb = answer.GetComponent<BoxCollider2D> ();
				nextb = next.GetComponent<BoxCollider2D> ();

				//topclose = menutop.transform.localPosition.y;
				//bottomclose = menubottom.transform.localPosition.y;
				topclose = menutop.GetComponent<SpriteRenderer>().sprite.rect.size.y / 2.0f;
				bottomclose = -topclose;
				//backsize = menuback.GetComponent<SpriteRenderer>().sprite.rect.size.y;
				backsize = menuback.GetComponent<SpriteRenderer> ().renderer.bounds.size.y;
				backscale = topclose * 2 / backsize;

				backwidth = menuback.GetComponent<SpriteRenderer> ().sprite.rect.size.x;
				hide (1);
				foreach (GameObject go in menus)
						iTween.ColorTo (go,iTween.Hash("a", 0.0f, "easetype", "easeincirc", "time", 0.01f));
		}
	
	// Update is called once per frame
	void Update () {
	
	}




		void open(int type){
				visible (1);
				goalformenu = GameSceneManager.movetogoal.y + topclose;
				float goalscale = goalformenu*2f/backsize;

				
				//5階縦長につき特別仕様
				if (GameSceneManager.floorNum == 5) {
						goalformenu = full;
						goalscale = full * 2f / backsize;
				} else if (goalformenu > full) {
						Debug.Log ("Menusize > fullsize -> fullsize open");
						fullopen (type);
						return;
				}
				foreach (GameObject go in menus)
						iTween.ColorTo (go,iTween.Hash("a", 1.0f, "easetype", "easeincirc", "time", 0.8f));
				Debug.Log ("open to "+ goalformenu);
				if (type == 1) {
						iTween.MoveTo (menutop, iTween.Hash ("y", goalformenu, 
								"delay", delay, "time", 0.8f,
								"oncompletetarget", this.gameObject,
								"oncomplete", "deq"));
						iTween.MoveTo (menubottom, iTween.Hash ("y", -goalformenu, 
								"delay", delay, "time", 0.8f));
						iTween.ScaleTo (menuback,iTween.Hash("y",goalscale,"delay",delay,"time",0.8f));
				}
				else {
						deq ();
						iTween.MoveTo (menutop,iTween.Hash("y",goalformenu,"delay",delay,"time",0.8f));
						iTween.MoveTo (menubottom,iTween.Hash("y",-goalformenu,"delay",delay,"time",0.8f));
						iTween.ScaleTo (menuback,iTween.Hash("y",goalscale,"delay",delay,"time",0.8f));
				}
		}
		void fullopen(int type){
				visible (1);
				foreach (GameObject go in menus)
						iTween.ColorTo (go,iTween.Hash("a", 1.0f, "easetype", "easeincirc", "time", 0.8f));
				if (type == 1)
						iTween.MoveTo (menutop, iTween.Hash ("y", full, 
								"delay", delay, "time", 0.8f,
								"oncompletetarget", this.gameObject,
								"oncomplete", "deq"));
				else {
						deq ();
						iTween.MoveTo (menutop,iTween.Hash("y",380f,"delay",delay,"time",0.8f));
				}
				iTween.MoveTo (menubottom,iTween.Hash("y",-1f*full,"delay",delay,"time",0.8f));
				iTween.ScaleTo (menuback,iTween.Hash("y",full*2f/backsize,"delay",delay,"time",0.8f));
		}
		void optionopen(int type){
				visible (1);
				foreach (GameObject go in menus)
						iTween.ColorTo (go,iTween.Hash("a", 1.0f, "easetype", "easeincirc", "time", 0.8f));
				goalformenu = 108f + topclose;
				float goalscale = goalformenu*2f/backsize;

				iTween.MoveTo (menutop, iTween.Hash ("y", goalformenu, 
						"delay", delay, "time", 0.8f,
						"oncompletetarget", this.gameObject,
						"oncomplete", "deq"));
				iTween.MoveTo (menubottom, iTween.Hash ("y", -goalformenu, 
						"delay", delay, "time", 0.8f));
				iTween.ScaleTo (menuback,iTween.Hash("y",goalscale,"delay",delay,"time",0.8f));
		}
		void listopen(int type){
				goalformenu = GameSceneManager.movetogoallist.y + topclose;
				float goalscale = goalformenu*2f/backsize;

				if (goalformenu > full) {
						Debug.Log ("Menusize > fullsize -> fullsize open");
						fullopen (type);
						return;
				}


				foreach (GameObject go in menus)
						iTween.ColorTo (go,iTween.Hash("a", 1.0f, "easetype", "easeincirc", "time", 0.8f));


				iTween.MoveTo (menutop, iTween.Hash ("y", goalformenu, 
						"delay", delay, "time", 0.8f,
						"oncompletetarget", this.gameObject,
						"oncomplete", "deq"));
				iTween.MoveTo (menubottom, iTween.Hash ("y", -goalformenu, 
						"delay", delay, "time", 0.8f));
				iTween.ScaleTo (menuback,iTween.Hash("y",goalscale,"delay",delay,"time",0.8f));
		}



		void close(int type){
				foreach (GameObject go in menus)
						iTween.ColorTo (go,iTween.Hash("a", 0.0f, "easetype", "easeincirc", "time", 0.8f));
				if (type == 1) {
						iTween.MoveTo (menutop, iTween.Hash ("y", topclose, 
								"delay", delay, "time", 0.8f,
								"oncompletetarget", this.gameObject,
								"oncomplete", "deq"));
						iTween.MoveTo (menubottom, iTween.Hash ("y", bottomclose, 
								"delay", delay, "time", 0.8f));
						iTween.ScaleTo (menuback,iTween.Hash("y",backscale,"delay",delay,"time",0.8f));
				}
				else {
						iTween.MoveTo (menutop,iTween.Hash("y",topclose,"delay",delay,"time",0.8f));
						iTween.MoveTo (menubottom,iTween.Hash("y",bottomclose,"delay",delay,"time",0.8f));
						iTween.ScaleTo (menuback,iTween.Hash("y",backscale,"delay",delay,"time",0.8f));
						deq ();
				}
		}


		void replaceBar(){
				roomnum.SendMessage ("changenum",GameSceneManager.floorNum);
				roomnum.transform.localPosition = new Vector3 (0f,0f,0f);
				menu.transform.localPosition = new Vector3 (-450f,0f,0f);

				GameSceneManager.state temp = GameSceneManager.gstate;
				Debug.Log ("gstate is "+ temp);
				if (temp == GameSceneManager.state.Q || temp == GameSceneManager.state.RESULT) {
						next.transform.localPosition = new Vector3 (center, np.y, np.z);
						answer.transform.localPosition = new Vector3 (left, ap.y, ap.z);
						closeobj.transform.localPosition = new Vector3 (right, cp.y, cp.z);
				} else if (temp == GameSceneManager.state.ANSWER) {
						next.transform.localPosition = new Vector3 (left, np.y, np.z);
						answer.transform.localPosition = new Vector3 (center, ap.y, ap.z);
						closeobj.transform.localPosition = new Vector3 (right, cp.y, cp.z);
				} else if (temp == GameSceneManager.state.THIRTEEN) {
						next.transform.localPosition = new Vector3(left,np.y,np.z);
						answer.transform.localPosition = new Vector3(right,ap.y,ap.z);
						closeobj.transform.localPosition = new Vector3(center,cp.y,cp.z);
						closeobj.name = "closeth";
				} else
						Debug.Log ("RepalaceBar @ UNKNOWN STATE");
		}
		void replacetomenu(int type){
				roomnum.transform.localPosition = new Vector3 (-450f,0f,0f);
				menu.transform.localPosition = new Vector3 (0f,0f,0f);

				next.transform.localPosition = new Vector3(left,np.y,np.z);
				answer.transform.localPosition = new Vector3(right,ap.y,ap.z);
				closeobj.transform.localPosition = new Vector3(center,cp.y,cp.z);
				deq ();
		}
		void bottomoff(int type){
				next.renderer.enabled = false;
				answer.renderer.enabled = false;
				closeobj.renderer.enabled = false;
				nextb.enabled = false;
				answerb.enabled = false;
				closeb.enabled = false;

				deq ();
		}
		void bottomon(int type){
				next.renderer.enabled = true;
				answer.renderer.enabled = true;
				closeobj.renderer.enabled = true;
				nextb.enabled = true;
				answerb.enabled = true;
				closeb.enabled = true;

				deq ();
		}
		void keyon(int type){
				bool temp = true;
				keyG.renderer.enabled = temp;
				keyS.renderer.enabled = temp;
				keygb.enabled = temp;
				keysb.enabled = temp;
				deq ();
		}
		void keyoff(int type){
				bool temp = false;
				keyG.renderer.enabled = temp;
				keyS.renderer.enabled = temp;
				keygb.enabled = temp;
				keysb.enabled = temp;
				deq ();
		}


		void hide(int type){
				menucamera.camera.enabled = false;
				deq ();
		}
		void visible(int type){
				menucamera.camera.enabled = true;
				//deq ();
		}
		void elase(int type){
				closeb.enabled = false;
				answerb.enabled = false;
				nextb.enabled = false;
				deq ();
		}
		void move(int type){
				//menucamera.camera.transform.localPosition = new Vector3 (0f,270f,0f);
				deq ();
		}
		void remove(int type){
				menucamera.camera.transform.localPosition = new Vector3 (0f,90f,0f);
				deq ();
		}
		void overdoor(int type){
				//menucamera.camera.depth = 12;
				deq ();
		}
		void underdoor(int type){
				//menucamera.camera.depth = 3;
				deq ();
		}
		void slideIn(int type){
				if (type == 1){
						iTween.MoveTo (menucamera, iTween.Hash ("y", menucamera.transform.localPosition.y - Screen.height, "time", 1.6f, "oncompletetarget", gameObject, "oncomplete", "deq"));
				}else{
						iTween.MoveTo(menucamera,iTween.Hash("y",menucamera.transform.localPosition.y-Screen.height,"time",1.6f));
						deq ();
				}

		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}

		void switchObjct(GameObject A,GameObject B){
				var temp = A.transform.localPosition;
				A.transform.localPosition = B.transform.localPosition;
				B.transform.localPosition = temp;
		}

		void roomnumup(){
				roomnum.SendMessage ("changenum",GameSceneManager.floorNum);
		}
}
