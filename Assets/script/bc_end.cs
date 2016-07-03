using UnityEngine;
using System.Collections;

public class bc_end : MonoBehaviour {


		SpriteRenderer bcendrender;
		public Sprite[] back_ends = new Sprite[3];
		GameObject gm;
		GameObject gecobj;
		GameObject gme;
		Camera gec;
		BoxCollider2D gmebc;

	// Use this for initialization
	void Start () {
				gm = GameObject.Find ("GameManager");
				gme = GameObject.Find ("GameEnd");
				gmebc = gme.GetComponent<BoxCollider2D> ();
				bcendrender = this.gameObject.GetComponent<SpriteRenderer> ();
				iTween.ColorTo (this.gameObject,iTween.Hash("a",0f,"time",0.01f));
				GameSceneManager.gmscript.bc_end = this.gameObject;
				gecobj = GameObject.Find ("GameendCamera");
				gec = gecobj.GetComponent<Camera> ();
				Debug.Log ("bcrenderer"+bcendrender.ToString());
	}
		int count=0;
	// Update is called once per frame
	void Update () {
				if (count == 0) {
						count++;
						bcendrender.sprite = back_ends [1];
						Debug.Log ("1screenheight:"+Screen.width+","+Screen.height);
						Debug.Log ("1CAMERAsize:"+gec.pixelWidth+","+gec.pixelHeight);
						Debug.Log ("1SpriteRectsize:"+ (bcendrender.bounds.size.y * (float)Screen.width / bcendrender.bounds.size.x));
						Debug.Log ("1SpriteRendersize:"+bcendrender.bounds.size);
				}else if(count ==1 ){
						count++;
						bcendrender.sprite = back_ends [2];
						Debug.Log ("2screenheight:"+Screen.height);
						Debug.Log ("2SpriteBoundssize:"+bcendrender.sprite.bounds.size);
						Debug.Log ("2SpriteRectsize:"+ (bcendrender.bounds.size.y * (float)Screen.width / bcendrender.bounds.size.x));
						Debug.Log ("2SpriteRendersize:"+bcendrender.bounds.size);
				}
	}

		void setSprite(int i){
				//before this, use camera off,because hide sprite.??????
				GameSceneManager.endstate t = GameSceneManager.ending;
				if (t == GameSceneManager.endstate.NOCROSS
				   || t == GameSceneManager.endstate.ONENOKEY
				   || t == GameSceneManager.endstate.UNDERNOKEY
				   || t == GameSceneManager.endstate.UNDERWITHONEKEY) {

						bcendrender.sprite = back_ends [0];
				} else if (t == GameSceneManager.endstate.ONEWITHKEY) {
						bcendrender.sprite = back_ends [1];
				} else if (t == GameSceneManager.endstate.UNDERWITHKEY) {
						bcendrender.sprite = back_ends [2];
				} else
						Debug.Log ("Unknown end state @sprite setting");
				deq ();
		}

		void visible(int i){

				float tmp = bcendrender.bounds.size.y; //* (float)Screen.width / bcendrender.bounds.size.x;
				gecobj.transform.position = new Vector3 (gecobj.transform.position.x,( tmp -1156f )/2f,gecobj.transform.position.z);
				iTween.ColorTo (this.gameObject,iTween.Hash("a",1.0f,"time",3.2f,"oncompletetarget",this.gameObject,"oncomplete","deq"));
		}

		void scroll(int type){
				//float tmp = bcendrender.bounds.size.y * 1156f / bcendrender.bounds.size.x;
				float tmp = bcendrender.bounds.size.y;
				float goal = -1.0f *( tmp - 1156f )/2f;
				iTween.MoveTo (gecobj,iTween.Hash("y",goal,"time",3.6f,"oncompletetarget",gameObject,"oncomplete","deq"));
				//iTween.MoveTo (gme,iTween.Hash("y",goal,"time",3.6f,"oncompletetarget",gameObject,"oncomplete","deq"));
				gmebc.offset = new Vector2 (0f,goal);
		}

		void deq(){
				gm.SendMessage ("deq");
		}


}
