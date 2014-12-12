using UnityEngine;
using System.Collections;

public class allFogManager : MonoBehaviour {

		private GameObject[] fogs = new GameObject[3];
		//private SpriteRenderer[] renderers = new SpriteRenderer[3];
		private float[] def = new float[3];
		//private Color c;
		// Use this for initialization
		void Start () {
				GameSceneManager.gmscript.fogall = this.gameObject;
				fogs [0] = GameObject.Find ("allfog_u");
				fogs [1] = GameObject.Find ("allfog_m");
				fogs [2] = GameObject.Find ("allfog_b");
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "time", 0.001f));
				def [0] = fogs [0].transform.localPosition.x;
				def [1] = fogs [1].transform.localPosition.x;
				def [2] = fogs [2].transform.localPosition.x;
		}
	
	// Update is called once per frame
	void Update () {
	
	}

		float time = 8f;
		void hide(){
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "time", time/2f-1f));
		}
		void hideim(int type){
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "time", 0.001f));
				deq ();
		}
		void visible(int type){
				setDefault ();
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0.7f, "time",time/2f-1f,"delay",0.8f, "oncomplete","hide","oncompletetarget",gameObject));
				float i = 1f;
				foreach (GameObject go in fogs) {
						i *= -1f;
						iTween.MoveTo (go, iTween.Hash ("x", -600f*i, "islocal",true,"easetype", "easeoutsine", "time", time));
				}
				deq ();
		}
		void visiblefull(int type){
				setDefault ();
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 1.0f, "time",time/2f-1f,"delay",0.8f));
				float i = 1f;
				foreach (GameObject go in fogs) {
						i *= -1f;
						iTween.MoveTo (go, iTween.Hash ("x", -200f*i, "islocal",true,"easetype", iTween.EaseType.easeInOutSine, "time", 12.0f));
				}
				deq ();
		}
		void setDefault(){
				Vector3 tmp = fogs [0].transform.localPosition;
				fogs [0].transform.localPosition = new Vector3 (def[0],tmp.y,tmp.z);
				tmp = fogs [1].transform.localPosition;
				fogs [1].transform.localPosition = new Vector3 (def[1],tmp.y,tmp.z);
				tmp = fogs [2].transform.localPosition;
				fogs [2].transform.localPosition = new Vector3 (def[2],tmp.y,tmp.z);
		}
		void visibleEle(int type){
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 1f, "time", time/2f,"oncomplete","tored","oncompletetarget",gameObject));
				/*foreach (GameObject go in fogs) {
						i *= -1f;
						iTween.MoveTo (go, iTween.Hash ("x", -600f*i, "islocal",true,"easetype", "easeoutsine", "time", time));
				}*/
				deq ();
		}
		void tored(){
				iTween.ColorTo (this.gameObject, iTween.Hash ("r",0.5f,"b", 0f, "g", 0f, "time", time/2f));
		}
		void towhite(int type){
				iTween.ColorTo (this.gameObject, iTween.Hash ("r",1f,"g", 1f, "b",1f,"time", time/4f));
				deq ();
		}
		void colorupdate(float c){

		}
		void hideEnd(int type){
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "time", time/4f,"oncompletetarget",gameObject,"oncomplete","deq"));
				float i = 1f;
				foreach (GameObject go in fogs) {
						i *= -1f;
						iTween.MoveTo (go, iTween.Hash ("x", -600f*i, "islocal",true,"easetype", "easeoutsine", "time", time));
				}
				//deq ();
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}

}
