using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

		private float limit = 8.0f;
		public GameObject gmmmmm;
	// Use this for initialization
	void Start () {
				gmmmmm = GameObject.Find ("GameManager");
				gmmmmm.GetComponent<GameManager>().intrtimer = gameObject;
				GameSceneManager.gmscript.timer = this.gameObject;
				//limit = GameSceneManager.gmscript.limit;
				Debug.Log ("limit is "+limit);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void start(){
				limit = 99.0f;
				GameSceneManager.gm.SendMessage ("setTouch",true);
				iTween.ValueTo (this.gameObject,iTween.Hash("from",0,"to",200,"time",limit,"oncompletetarget",this.gameObject,"oncomplete","end","onupdate","empFunc"));
				deq ();
		}

		void end(){
				GameSceneManager.gm.SendMessage ("timeupEv");
		}
		void waitasecond(int type){
				limit = 1f;
				iTween.ValueTo (this.gameObject,iTween.Hash("from",0,"to",200,"time",limit,"oncompletetarget",this.gameObject,"oncomplete","deq","onupdate","empFunc"));

		}

		void waittimer(int type){
				limit = 3.8f;
				iTween.ValueTo (this.gameObject,iTween.Hash("from",0,"to",200,"time",limit,"oncompletetarget",this.gameObject,"oncomplete","deq","onupdate","empFunc"));
		}
		void waittimerintro(int type){
				limit = 3.2f;
				iTween.ValueTo (this.gameObject,iTween.Hash("from",0,"to",200,"time",limit,"oncompletetarget",this.gameObject,"oncomplete","deq","onupdate","empFunc"));
		}
		void waittimerset(float time){
				limit = time;
		}

		void deq(){
				gmmmmm.SendMessage ("deq");
		}

		void empFunc(){}
}
