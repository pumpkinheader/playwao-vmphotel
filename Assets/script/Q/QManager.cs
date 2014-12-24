using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QManager : MonoBehaviour {


		SpriteRenderer qrenderer;
		int now=0;
		public Sprite[] qs = new Sprite[12];

		private GameObject[] qbacks = new GameObject[2];
		private SpriteRenderer[] qbacksrender = new SpriteRenderer[2];
		private float qbackheight;
		private Vector3 originalPos;

		//private Vector3[] elevensPos = new Vector3[5];
		public GameObject[] elevens = new GameObject[5];
		private SpriteRenderer[] erenderer = new SpriteRenderer[5];
		private List<BoxCollider2D> collis = new List<BoxCollider2D>();

		private GameObject qcam;
		private bool moved = false;
	// Use this for initialization
	void Start () {
				qcam = GameObject.Find ("QCamera");
				qcam.camera.enabled=false;
				GameSceneManager.gmscript.q = this.gameObject;
				qrenderer = this.gameObject.GetComponent<SpriteRenderer>();
				qrenderer.sprite = qs [0];

				qbacks [0] = GameObject.Find ("qtop");
				qbacksrender [0] = qbacks [0].GetComponent<SpriteRenderer> ();
				qbacks [1] = GameObject.Find ("qbottom");
				qbacksrender [1] = qbacks [1].GetComponent<SpriteRenderer> ();
				qbackheight = qbacks [0].GetComponent<SpriteRenderer> ().sprite.rect.size.y;

				int j = 1;
				elevens [j-1] = GameObject.Find ("1103_"+j);j++;
				elevens [j-1] = GameObject.Find ("1103_"+j);j++;
				elevens [j-1] = GameObject.Find ("1103_"+j);j++;
				elevens [j-1] = GameObject.Find ("1103_"+j);j++;
				elevens [j-1] = GameObject.Find ("1103_"+j);j++;

				originalPos = gameObject.transform.localPosition;

				int i = 0;
				foreach (GameObject go in elevens) {
						erenderer[i] = go.gameObject.GetComponent<SpriteRenderer> ();
						//erenderer [i].renderer.enabled = false
						collis.AddRange (go.GetComponentsInChildren<BoxCollider2D>());
						go.renderer.enabled = false;
						i++;
						iTween.ColorTo (go, iTween.Hash ("a", 0.0f, "easetype", "easeincirc", "time", 0.01f));
				}
				foreach(BoxCollider2D pc in collis){
						pc.enabled = false;
				}
				qbacksrender [0].enabled = false;
				iTween.ColorTo (qbacks[0], iTween.Hash ("a", 0.0f, "time", 0.01f));
				qbacksrender [1].enabled = false;
				iTween.ColorTo (qbacks[1], iTween.Hash ("a", 0.0f, "time", 0.01f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		void onCamera(){
				qcam.camera.enabled = true;
		}
		void endmode(){
				Debug.Log ("tectheigt"+qcam.camera.rect.width);
				qcam.camera.rect = new Rect (qcam.camera.rect.x,qcam.camera.rect.y,0.85f,qcam.camera.rect.height);
		}
		void visible(int type){
				qcam.camera.enabled=true;
				if (now != GameSceneManager.floorNum) {
						now = GameSceneManager.floorNum;
						qrenderer.sprite = qs[now-1];
				}
				qbacksrender [0].enabled = true;
				qbacksrender [1].enabled = true;
				foreach (GameObject tg in qbacks) {
						iTween.ColorTo (tg, iTween.Hash ("a", 1.0f, "easetype", "easeincirc", "time", 0.8f));
				}
				qrenderer.enabled = true;
				if (type == 1) {
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 1.0f, "easetype", "easeincirc", "time", 0.8f, "oncompletetarget", this.gameObject, "oncomplete", "deq"));
				} else {
						deq ();
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 1.0f, "easetype", "easeincirc", "time", 0.8f));
				}
				if (GameSceneManager.floorNum == 11) {
						//int i = 0;
						foreach (GameObject go in elevens) {
								//erenderer [i++].enabled = true;
								go.renderer.enabled = true;
								iTween.ColorTo (go, iTween.Hash ("delay",1.2f,"a", 1.0f, "easetype", "easeincirc", "time", 0.8f));
						}
						foreach(BoxCollider2D pc in collis){
								pc.enabled = true;
						}
				}
		}
		void hide(int type){
				foreach (GameObject tg in qbacks) {
						iTween.ColorTo (tg, iTween.Hash ("a", 0.0f, "easetype", "easeincirc", "time", 0.8f));
				}
				if (type == 1)
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0.0f, "easetype", "easeincirc", "time", 0.8f, "oncompletetarget", this.gameObject, "oncomplete", "deqwithhide"));
				else {
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0.0f, "easetype", "easeincirc", "time", 0.8f));
						deq ();
				}
				if (GameSceneManager.floorNum == 11) {
						int i = 0;
						foreach (GameObject go in elevens) {
								i++;
								iTween.ColorTo (go, iTween.Hash ("a", 0.0f, "easetype", "easeincirc", "time", 0.8f,"oncomplettarget",go,"oncomplete","renderfalse"));
						}
						foreach(BoxCollider2D pc in collis){
								pc.enabled = false;
						}
				}
		}
		void qbackhide(int type){
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0.0f, "easetype", "easeincirc", "time", 0.8f, "oncompletetarget", this.gameObject, "oncomplete", "deqwithhide"));
		}


		void move(int type){
				if (!moved) {
						//moved = true;
						float goal = MenuManager.full - 15f - qrenderer.sprite.rect.size.y / 2.0f;
						//Debug.Log ("move to "+ goal + "(Q)");
						//this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x,goal,this.gameObject.transform.position.z);

						//5階縦長につき特別仕様
						if (GameSceneManager.floorNum == 5)
								goal = qrenderer.transform.localPosition.y + qbackheight / 2.0f;

						foreach (GameObject tg in qbacks) {
								iTween.ColorTo (tg, iTween.Hash ("a", 0.0f, "easetype", "easeincirc", "time", 0.8f));
						}
						if (type == 1)
								iTween.MoveTo (this.gameObject, iTween.Hash ("y", goal, "oncompletetarget", gameObject, "oncomplete", "deq"));
						else {
								iTween.MoveTo (this.gameObject, iTween.Hash ("y", goal));
								deq ();
						}
				}
						
		}
		void qreturn(){
				this.gameObject.transform.localPosition = originalPos;
				moved = false;
		}
		void elevenmove(int type){
				float goal = 1.0f;
				goal = 198f;

				foreach (GameObject tg in qbacks) {
						iTween.ColorTo (tg, iTween.Hash ("a", 0.0f, "easetype", "easeincirc", "time", 0.8f,"oncompletetarget",this.gameObject	,"oncomplete","qbackselevenmove"));
				}
				if (type == 1)
						iTween.MoveTo (this.gameObject, iTween.Hash ("y", goal, "oncompletetarget", gameObject, "oncomplete", "deq"));
				else {
						iTween.MoveTo (this.gameObject, iTween.Hash ("y", goal));
						deq ();
				}
		}

		void next(){
				if (GameSceneManager.floorNum == 13)
						return;
				if (now != GameSceneManager.floorNum) {
						now = GameSceneManager.floorNum;
						qrenderer.sprite = qs [now - 1];
						qreturn ();
						goalcal();
						qbacksmove ();
				} else
						Debug.Log ("ERROR:Q CHANGE MISS");
		}

		private void goalcal(){
				var  s = qrenderer.sprite.rect.size.y+qbackheight;
				GameSceneManager.movetogoal.y = s/2.0f;
		}
		private void qbacksmove(){
				float i = 1.0f;
				foreach(GameObject tg in qbacks){
						var vec = tg.transform.position;
						/*var s = tg.renderer.bounds.size/2.0f;
						var goal = s.y + GameSceneManager.movetogoal.y;
						tg.transform.position = new Vector3 (vec.x,goal,vec.z);*/
						if(GameSceneManager.floorNum == 5)
								tg.transform.position = new Vector3 (vec.x, i * (MenuManager.full-qbackheight*0.75f), vec.z);
						else
								tg.transform.position = new Vector3 (vec.x, i * (GameSceneManager.movetogoal.y-10f), vec.z);
						i = -1.0f;
				}
		}
		private void qbackselevenmove(){
				float i = 1.0f;
				foreach(GameObject tg in qbacks){
						var vec = tg.transform.position;
						/*						var s = tg.renderer.bounds.size/2.0f;
						var goal = s.y + GameSceneManager.movetogoal.y;
						tg.transform.position = new Vector3 (vec.x,goal,vec.z);*/
						tg.transform.position = new Vector3 (vec.x, i * (MenuManager.full-qbackheight*0.75f), vec.z);
						iTween.ColorTo (tg, iTween.Hash ("a", 1.0f, "easetype", "easeincirc", "time", 0.8f));

						i = -1.0f;
				}
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
		void deqwithhide(){
				qrenderer.enabled = false;
				GameSceneManager.gm.SendMessage ("deq");
		}
		void renderfalse(){
				/*foreach(SpriteRenderer s in erenderer){
						s.renderer.enabled = false;
				}*/
				foreach(BoxCollider2D pc in collis){
						pc.enabled = false;
				}
		}
}
