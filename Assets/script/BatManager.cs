using UnityEngine;
using System.Collections;

public class BatManager : MonoBehaviour {

		private GameObject batnumU;
		private GameObject batnumB;
		private GameObject wingL;
		private GameObject wingR;
		Quaternion tmpL ;
		Quaternion tmpR ;

	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.batmanage = gameObject;
				batnumU = GameObject.Find ("batnum_0");
				batnumB = GameObject.Find ("batnum_1");
				wingL = GameObject.Find ("batleft");
				wingR = GameObject.Find ("batright");
				tmpL = wingL.transform.rotation;
				tmpR = wingL.transform.rotation;
	}
	
		// Update is called once per frame
	void Update () {
	
	}
		void init(int type){
				int floor = GameSceneManager.floorNum;
				batnumU.SendMessage ("init",floor);
				batnumB.SendMessage ("init",floor+1);
		}
		float pretime = 2.1f;
		void roomup(int type){
				float delay = 0.6f;
				deq ();
				batnumB.SendMessage ("setnum",GameSceneManager.floorNum);
				//batnumU.SendMessage ("setnum",GameSceneManager.floorNum);
				//iTween.ShakePosition (batnumU,iTween.Hash("x",4f,"time",pretime));

				//wing
				iTween.RotateTo (wingL,iTween.Hash("z",349f,"time",pretime,"easetype","easeinoutback"));
				iTween.RotateTo (wingR,iTween.Hash("z",11f,"time",pretime,"easetype","easeinoutback"));

				//roomnum
				iTween.MoveTo (batnumU,iTween.Hash("y",420f,"time",pretime-delay,"delay",delay,"easetype","easeoutbounce"));
				iTween.MoveTo (batnumB,iTween.Hash("y",340f,"time",pretime-delay,"delay",delay,"easetype","easeoutbounce","oncompletetarget",gameObject,"oncomplete","endchangingfloor"));

		}
		/*void nextchangingfloor(){
				iTween.MoveAdd (batnumU,iTween.Hash("y",15f,"time",pretime*2f/3f));
				iTween.MoveAdd (batnumB,iTween.Hash("y",15f,"time",pretime*2f/3f,"oncompletetarget",gameObject,"oncomplete","endchangingfloor"));
		}*/

		void endchangingfloor(){
				Debug.Log ("endchanging IN");
				float delay = 0.3f;

				iTween.RotateTo (wingL,iTween.Hash("z",360f,"time",pretime,"delay",delay,"easetype","easeoutback"));
				iTween.RotateTo (wingR,iTween.Hash("z",0f,"time",pretime,"delay",delay,"easetype","easeoutback"));

				iTween.MoveTo(batnumU,iTween.Hash("y",460f,"time",2.4f-pretime,"delay",delay,"easetype","easeoutelastic"));
				iTween.MoveTo (batnumB,iTween.Hash("y",380f,"time",pretime,"delay",delay,"easetype","easeoutelastic","oncompletetarget",gameObject,"oncomplete","shakemini"));
		}

		void shakemini(){
				Debug.Log ("shakeminiBat IN");
				changeposition ();
				//deq ();
		}

		void changeposition(){
				GameObject tmp;
				Vector3 vec = batnumU.transform.position;
				batnumU.transform.position = new Vector3 (vec.x,300f,vec.z);

				tmp = batnumU;
				batnumU = batnumB;
				batnumB = tmp;
		}


		void shakewing(int type){
				wingL.transform.rotation = new Quaternion(0f,0f,0f,tmpL.w);
				wingR.transform.rotation = new Quaternion(0f,0f,0f,tmpR.w);
				iTween.RotateTo (wingL,iTween.Hash("z",356f,"time",2.4f,"looptype","pingpong","easetype","easeoutsine"));
				iTween.RotateTo (wingR,iTween.Hash("z",4f,"time",2.4f,"looptype","pingpong","easetype","easeoutsine"));
				deq ();
		}
		void shakewingwithnondeq(){
				wingL.transform.rotation = new Quaternion(0f,0f,0f,tmpL.w);
				wingR.transform.rotation = new Quaternion(0f,0f,0f,tmpR.w);
				iTween.RotateTo (wingL,iTween.Hash("z",356f,"time",2.4f,"looptype","pingpong","easetype","easeoutsine"));
				iTween.RotateTo (wingR,iTween.Hash("z",4f,"time",2.4f,"looptype","pingpong","easetype","easeoutsine"));
		}
		int c=0;
		void patapataup(int type){
				c++;
				if (c == 1) {
						deq ();
				}
				else if (c == 4) {
						shakewingwithnondeq ();
						c = 0;
						return;
				}
				iTween.RotateTo (wingL, iTween.Hash ("z", 361f, "time", 0.04f, "easetype", "easeinsine","oncompletetarget",gameObject,"oncomplete","patapatadown"));
				iTween.RotateTo (wingR,iTween.Hash("z",-1f,"time",0.04f,"easetype","easeinsine"));
		}
		void patapatadown(){
				iTween.RotateTo (wingL, iTween.Hash ("z", 360f, "time", 0.2f, "easetype", "easeoutsine","oncompletetarget",gameObject,"oncomplete","patapataup","oncompleteparams",1));
				iTween.RotateTo (wingR,iTween.Hash("z",0f,"time",0.2f,"easetype","easeoutsine"));
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}

}
