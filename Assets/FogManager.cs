using UnityEngine;
using System.Collections;

public class FogManager : MonoBehaviour {

		private GameObject[] fogs = new GameObject[3];
		private int endingLayerNum;
	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.fogback = this.gameObject;
				fogs [0] = GameObject.Find ("backfog_u");
				fogs [1] = GameObject.Find ("backfog_m");
				fogs [2] = GameObject.Find ("backfog_b");

				iTween.MoveTo (fogs[0],iTween.Hash("x",-2400f,"time",1200f,"easetype","easeOutQuad"));
				iTween.MoveTo (fogs[1],iTween.Hash("x",2400f,"time",800f,"easetype","easeOutQuad"));
				iTween.MoveTo (fogs[2],iTween.Hash("x",-2400f,"time",200f,"easetype","easeOutQuad"));

				endingLayerNum = GameObject.Find ("GameEnd").layer;

	}
	
	// Update is called once per frame
	void Update () {

	}
		void visible(int type){

		}
		void hide(int type){
				iTween.ColorTo (gameObject,iTween.Hash("a",0f,"time",0.2f));
				deq ();
		}
		void hideEnd(){
				iTween.ColorTo (gameObject,iTween.Hash("a",0f,"time",4.2f));
	
		}
		void visibleEnd(int type){
				Vector3 tmp = this.gameObject.transform.position;
				gameObject.transform.position = new Vector3 (tmp.x + 3600f,tmp.y,tmp.z);
				foreach (var fog in fogs) {
						fog.layer = endingLayerNum;
						fog.SendMessage ("changeLayer",endingLayerNum);
				}
				iTween.ColorTo (gameObject,iTween.Hash("a",1f,"time",4.8f,"delay",0.6f,"oncomletetarget",gameObject,"oncomplete","hideEnd"));
				deq ();

		}
		void move(int type){
				iTween.MoveTo (fogs[0],iTween.Hash("x",-2400f,"time",1200f,"islocal",true,"easetype","easeOutQuad"));
				iTween.MoveTo (fogs[1],iTween.Hash("x",2400f,"time",800f,"islocal",true,"easetype","easeOutQuad"));
				iTween.MoveTo (fogs[2],iTween.Hash("x",-2400f,"time",200f,"islocal",true,"easetype","easeOutQuad"));
				deq ();
		}
		void stop(int type){
				iTween.Stop (fogs[0]);
				iTween.Stop (fogs[1]);
				iTween.Stop (fogs[2]);
				deq ();
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
		void setDefault(int type){
				foreach (var fog in fogs) {
						//Vector3 now = fog.transform.position;
						fog.transform.position = new Vector3 (0f,0f,0f);
				}
				deq ();
		}

}
