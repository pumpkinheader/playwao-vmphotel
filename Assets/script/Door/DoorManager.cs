using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

		public GameObject rightdoor;
		public GameObject leftdoor;
		private float rclose,lclose;
		private bool opened=false;

	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.door = this.gameObject;
				rightdoor = GameObject.Find ("doorright");
				rclose = rightdoor.transform.localPosition.x;
				leftdoor = GameObject.Find ("doorleft");
				lclose = leftdoor.transform.localPosition.x;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void open(int type){
				if (opened) {
						deq ();
						return;
				}
				iTween.MoveTo(leftdoor, iTween.Hash("islocal",true,"x",-420, "time", 3.0f,"delay",0.3f, "easetype", iTween.EaseType.easeOutQuad,"oncomplete", "dooropend", "oncompletetarget", this.gameObject));
				if (type == 1)
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", 420, "time", 3.0f, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad, "oncomplete", "deq", "oncompletetarget", this.gameObject));
				else {
						deq ();
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", 420, "time", 3.0f, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad));
				}
		}

		void close(int type){
				if (leftdoor.transform.localPosition.x != lclose)
						iTween.MoveTo (leftdoor, iTween.Hash ("islocal", true, "x", lclose, "time", 3.0f, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad,"oncomplete", "doorclosed", "oncompletetarget", this.gameObject));
				else {
						deq ();
						return;
				}

				if (type == 1)
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", rclose, "time", 3.0f, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad, "oncomplete", "deq", "oncompletetarget", this.gameObject));
				else {
						deq ();
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", rclose, "time", 3.0f, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad));
				}
		}
		void openth(int type){
				if (opened) {
						deq ();
						return;
				}
				iTween.MoveTo(leftdoor, iTween.Hash("islocal",true,"x",-600, "time", 1.4f,"delay",0.3f, "easetype", iTween.EaseType.easeInQuad,"oncomplete", "dooropend", "oncompletetarget", this.gameObject));
				if (type == 1)
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", 600, "time", 1.4f, "delay", 0.3f, "easetype", iTween.EaseType.easeInQuad, "oncomplete", "deq", "oncompletetarget", this.gameObject));
				{
						deq ();
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", 600, "time", 1.4f, "delay", 0.3f, "easetype", iTween.EaseType.easeInQuad));
				}
		}
		void closeth(int type){
				float time = 0.6f;
				if (leftdoor.transform.localPosition.x != lclose)
						iTween.MoveTo (leftdoor, iTween.Hash ("islocal", true, "x",lclose, "time", time, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad,"oncomplete", "doorclosed", "oncompletetarget", this.gameObject));
				else {
						deq ();
						return;
				}
				iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", rclose, "time", time, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad,"oncompletetarget", this.gameObject, "oncomplete", "shakemini"));

		}
		void closeEle1(int type){
				float time = 4.6f;
				if (leftdoor.transform.localPosition.x != lclose)
						iTween.MoveTo (leftdoor, iTween.Hash ("islocal", true, "x",lclose-10f, "time", time, "delay", 0.3f, "easetype", iTween.EaseType.easeOutExpo));
				else {
						deq ();
						return;
				}
				if (type == 1) {
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal", true, "x", rclose + 10f, "time", time, "delay", 0.3f, "easetype", iTween.EaseType.easeOutExpo,"oncompletetarget", this.gameObject, "oncomplete", "deq"));
				} else {
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal", true, "x", rclose + 10f, "time", time, "delay", 0.3f, "easetype", iTween.EaseType.easeOutExpo));
						deq ();
				}
		}
		void closeEle2(int type){
				float time = 0.6f;
				if (leftdoor.transform.localPosition.x != lclose)
						iTween.MoveTo (leftdoor, iTween.Hash ("islocal", true, "x",lclose, "time", time, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad,"oncomplete", "doorclosed", "oncompletetarget", this.gameObject));
				else {
						Debug.Log ("in function");
						deq ();
						return;
				}
				iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", rclose, "time", time, "delay", 0.3f, "easetype", iTween.EaseType.easeOutQuad,"oncompletetarget", this.gameObject, "oncomplete", "shakemini"));

		}
		void openend(int type){
				if (opened) {
						deq ();
						return;
				}
				iTween.MoveTo(leftdoor, iTween.Hash("islocal",true,"x",-600, "time", 4.8f,"delay",0.3f, "easetype", iTween.EaseType.easeInQuad,"oncomplete", "dooropend", "oncompletetarget", this.gameObject));
				if (type == 1)
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", 600, "time", 4.8f, "delay", 0.3f, "easetype", iTween.EaseType.easeInQuad, "oncomplete", "deq", "oncompletetarget", this.gameObject));
				else {
						deq ();
						iTween.MoveTo (rightdoor, iTween.Hash ("islocal",true,"x", 600, "time", 4.8f, "delay", 0.3f, "easetype", iTween.EaseType.easeInQuad));
				}
		}
		void shake(int type){
				iTween.ShakePosition (leftdoor,iTween.Hash("x",10f,"y",10f,"time",2.4f));
				if (type == 1)
						iTween.ShakePosition (rightdoor, iTween.Hash ("x", 10f, "y", 10f, "time", 2.4f, "oncompletetarget", this.gameObject, "oncomplete", "deq"));
				else {
						deq ();
						iTween.ShakePosition (rightdoor, iTween.Hash ("x", 10f, "y", 10f, "time", 2.4f));
				}
		}
		void shaketh(int type){
				iTween.ShakePosition (leftdoor,iTween.Hash("x",10f,"y",10f,"time",3000f,"name","leftshake"));
				if (type == 1)
						iTween.ShakePosition (rightdoor, iTween.Hash ("x", 10f, "y", 10f, "time", 3000f, "name", "rightshake"));//, "oncompletetarget", this.gameObject, "oncomplete", "deq"));
				else {
						deq ();
						iTween.ShakePosition (rightdoor, iTween.Hash ("x", 10f, "y", 10f, "time", 3000f,"name","rightshake"));
				}
		}
		void shakemini(){
				float time = 0.3f;
				iTween.ShakePosition (leftdoor,iTween.Hash("x",4f,"y",4f,"time",time));
				iTween.ShakePosition (rightdoor, iTween.Hash ("x", 4f, "y", 4f, "time", time, "oncompletetarget", this.gameObject, "oncomplete", "deq"));
		}
		void stop(int type){
				iTween.Stop(rightdoor);
				iTween.Stop(leftdoor);
				rightdoor.transform.localPosition = new Vector3 (rclose,0f,-40f);
				leftdoor.transform.localPosition = new Vector3 (lclose,0f,-40f);
				deq ();
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
		void dooropend(){
				if(GameSceneManager.gstate != GameSceneManager.state.THIRTEEN)
						opened = true;
		}
		void doorclosed(){
				opened = false;
		}
}
