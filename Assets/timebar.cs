using UnityEngine;
using System.Collections;

public class timebar : MonoBehaviour {

		SpriteRenderer sr;
		GameObject[] tmbs = new GameObject[4];
		SpriteRenderer[] tmbsrs = new SpriteRenderer[4];

		public Sprite[] numbers = new Sprite[10];


	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.timebar = this.gameObject;

				tmbs[0] = GameObject.Find ("timebar_2");
				tmbs [1] = GameObject.Find ("timebarbat");
				tmbs [2] = GameObject.Find ("battimernum_1");
				tmbs [3] = GameObject.Find ("battimernum_10");
				int i = 0;

				foreach(GameObject go in tmbs){
						iTween.ColorTo (go,iTween.Hash("a",0f,"time",0.01f));
						tmbsrs[i] = go.GetComponent<SpriteRenderer> ();
						tmbsrs [i].renderer.enabled = false;
						i++;
				}
				tmbsrs [2].sprite = numbers [9];
				tmbsrs [3].sprite = numbers [9];

	}
	
	// Update is called once per frame
	void Update () {
		
	}

		void visible(int type){
				foreach (var tmbsr in tmbsrs)
						tmbsr.enabled = true;
				foreach(var go in tmbs)
						iTween.ColorTo (go,iTween.Hash("a",1f,"time",0.6f));

				deq ();
		}
		void hide(int type){
				foreach (var tmbsr in tmbsrs) {
						tmbsr.enabled =false;
				}
				foreach (var go in tmbs) {
						iTween.ColorTo (go,iTween.Hash("a",0.9f,"time",1f));
				}
				deq ();
		}
		int limit = 99;
		void timerstart(int type){
				float goal = -635f;
				iTween.MoveTo (tmbs[0],iTween.Hash("y",goal,"time",limit,"easetype",iTween.EaseType.easeInSine));
				iTween.MoveTo (tmbs[1],iTween.Hash("y",goal+265f,"time",limit,"easetype",iTween.EaseType.easeInSine));
				iTween.MoveTo (tmbs[2],iTween.Hash("y",goal + 270f,"time",limit,"easetype",iTween.EaseType.easeInSine));
				iTween.MoveTo (tmbs[3],iTween.Hash("y",goal + 270f,"time",limit,"easetype",iTween.EaseType.easeInSine));
				iTween.ValueTo (gameObject,iTween.Hash("from",0,"to",limit,"time",limit,
						/*"oncompletetarget",this.gameObject,"oncomplete","deq",*/"onupdate","changeNum"));
				deq ();
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
		int now = 0;
		void changeNum(int i){
				//Debug.Log ("spent "+i+ " seconds");
				if (now != i) {
						now = i;
						int value = limit - now;
						tmbsrs [2].sprite = numbers[value%10];
						tmbsrs [3].sprite = numbers [value / 10];
				}
		}
}
