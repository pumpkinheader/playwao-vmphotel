using UnityEngine;
using System.Collections;

public class GameSceneManager : MonoBehaviour {
		public static GameObject gm;
		public static GameManager gmscript;
		public static int floorNum;
		public int debugFloorNum;
		public bool startEventOn=true;//屈辱のフラグ管理
		public bool fromContinue = false;
		public static bool GAMEEND = false;
		public bool noAnswerCheck = false;

		public static Vector2 movetogoal;
		public static Vector2 movetogoallist;
		public static MessageState m;
		private string[] answers = new string[]{"いいたいほうだい","りべんじ","ぐらいだー","ちまなこ","どぐう","あほうどり","ちょぞうこ","かりぶかい","のひつじ","ひえらるきー","つちだんご","ぎしんあんき"};
		//public static string youranswer;
		private bool shelf=false;
		private bool dozo=false;
		private bool hikidashi=false;
		public static int thcounter=0;//defalut 0
		public static int remain = 3;//default 3

		public enum state{
				INTRO1 = -3,
				INTRO2 = -2,
				INTRO3 = -1,
				INTROEND = 0,
				Q=1,
				ANSWER=2,
				RESULT=3,
				NEXT=4,
				ZZZ=5,
				THIRTEEN = 13,
				keymessage = 14,
				ELEPANEL = 15,
				MENU = 20,
				GAMEEND = 99,
		}public static state gstate;
		public static state before;
		public static keynum gkey = keynum.NOKEY;//defalut normal
		public static endElevator gelepanel = endElevator.NOCROSS;
		public static endstate ending = endstate.NORMAL;

		void Awake(){
				gm = GameObject.Find ("GameManager");
				gmscript = gm.GetComponent<GameManager> ();
				Debug.Log ("gmscript attach");
				this.fromContinue = gmscript.fromContinue;
		}
	// Use this for initialization
	void Start () {
				gstate = state.NEXT;
				gstate = state.INTRO1;
				gm = GameObject.Find ("GameManager");
				gmscript = gm.GetComponent<GameManager> ();
				gmscript.gsm = this.gameObject;
				floorNum = 0;
				//load ();
				movetogoallist = new Vector2 (0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
				if (startEventOn) {
						thcounter = 0;
						remain = 3;
						startEventOn = false;
						floorNum = debugFloorNum-1;
						Debug.Log (fromContinue);
						if(this.fromContinue)load ();
						Debug.Log ("gamestart @ "+floorNum+"floor");
						setTouch(false);
						changeMessage (MessageState.INTROTOGAME);
						gm.SendMessage ("gamestartEv");
				}
	}

		void touch(string name){
				if (GameManager.touchable) {
						setTouch (false);
						if (name == "next")
								stateUp ();
						else if (name == "answer")
								checkAnswer ();
						if (name == "optionbutton") {
								before = state.MENU;
								gm.SendMessage (name + "Ev");
								/*} else if (name == "closeth") {
								gm.SendMessage (name + "Ev");*/
						} else {
								if (gstate == state.INTROEND)
										gm.SendMessage ("toGameEv");
								else
										gm.SendMessage (gstate.ToString ("F") + "Ev");
						}

				} else {
						Debug.Log ("CANT TOUCH");
						return;
				}
		}
		void touchth(string name){
				if (GameManager.touchable) {
						thcounter++;
						setTouch (false);
						if (name == "keyS") {
								gkey = keynum.SILVER;
								changeMessage (MessageState.ELE);
								//gm.SendMessage ("keyEv");
								gm.SendMessage ("preEleEv");
						} else if (name == "keyG") {
								gkey = keynum.GOLD;
								changeMessage (MessageState.ELE);
								//gm.SendMessage ("keyEv");
								gm.SendMessage ("preEleEv");
						} else if ((name == "SHELF") && (!shelf) && (!dozo) && (!hikidashi)) {
								shelf = true;
								changeMessage (MessageState.SHELF);
								gm.SendMessage ("messageEv");
						} else if ((name == "DOZO") && (shelf) && (!dozo) && (!hikidashi)) {
								dozo = true;
								changeMessage (MessageState.DOZO);
								gm.SendMessage ("messageEv");
						} else if ((name == "HIKIDASHI") && (shelf) && (dozo) && (!hikidashi)) {
								//hikidashi = true;
								changeMessage (MessageState.HIKIDASHI);
								gstate = state.keymessage;
								gm.SendMessage ("keymessageEv");
						} else {
								changeMessage (MessageState.NORMAL);
								gm.SendMessage ("messageEv");
						}

				} else {
						Debug.Log ("CANT TOUCH");
						return;
				}

		}

		void floorchange(int type){	
				floorNum++;
				Debug.Log ("move to "+ floorNum);

				save ();
				gm.SendMessage("deq");
		}





		void save(){
				PlayerPrefs.SetInt ("floornum",floorNum);
				//PlayerPrefs.SetInt ("floornum",10);
				Debug.Log ("Save@"+floorNum);
		}
		void load(){
				int temp;
				temp = PlayerPrefs.GetInt ("floornum",-99);
				Debug.Log ("Load@"+temp);
				if (temp != -99)
						floorNum = temp-1;
		}
		public void setTouch(bool b){GameManager.touchable = b;}

		void checkAnswer(){
				MessageState temp;
				string text = GuiManager.textFieldString;
				bool correct=true;
				if (text == "ひらがなで！")return;
				if (!noAnswerCheck) {
						if (text != answers [floorNum-1]) {
								correct = false;
						}
				}
				if (correct)
						temp = MessageState.CORRECT;
				else {
						GAMEEND = true;
						temp = MessageState.INCORRECT;
				}
				changeMessage (temp);
				stateUp ();
		}
		void changeMessage(MessageState ms){
				m = ms;
				Debug.Log ("Message is "+ m.ToString("F"));
		}
		void setmessageBlood(){
				changeMessage (MessageState.ELE);
		}
		void setmessageDefeat(){
				changeMessage (MessageState.GUWAAAAAAAA);
		}
		void changeMessageInc(){
				Debug.Log ("changeMessage from"+m.ToString("F")+" to "+(++m).ToString("F"));
		}
		void changeStatekeymessage(){
				gstate = state.keymessage;;
		}

		void stateUp(){
				before = gstate;
				if (floorNum == 13 && gstate != state.keymessage){gstate = state.THIRTEEN;changeMessage (MessageState.INTOTHIRTEEN);return;}
				//if (GAMEEND) {gstate = state.GAMEEND;return;}
				gstate++;
				GuiManager.textFieldString = "ひらがなで！";
				if (gstate == state.ZZZ)
						gstate = state.Q;
		}
		int count = 1;
		void checkend(){
				if (GAMEEND) {
						gstate = state.GAMEEND;

				}else{
						gstate = state.GAMEEND;
				}
				if (gelepanel == endElevator.TOUNDERGROUND) {
						if (gkey == keynum.GOLD) {
								if (count == 1) {
										ending = endstate.UNDERWITHKEY;
										m = MessageState.UNDERWITHKEY;
										count--;
								} else {
										m = MessageState.UNDERWITHKEYSCROL;
										return;
								}
						} else if (gkey == keynum.SILVER) {
								ending = endstate.UNDERWITHONEKEY;
								m = MessageState.UNDERWITHONEKEY;
						} else {
								ending = endstate.UNDERNOKEY;
								m = MessageState.UNDERNOKEY;
						}
				} else if (gelepanel == endElevator.TOONE) {
						if (gkey == keynum.SILVER) {
								if (count == 1) {
								ending = endstate.ONEWITHKEY;
								m = MessageState.ONEWITHKEY;
										count--;
								} else {
										m = MessageState.ONEWITHKEYSCROL;
										return;
								}
						} else {
								ending = endstate.ONENOKEY;
								m = MessageState.ONENOKEY;
						}
				} else if (gelepanel == endElevator.NOCROSS) {

								ending = endstate.NOCROSS;
								m = MessageState.NOCROSS;

				}
				else
						Debug.Log ("UNKNOWN GAMEEND STATE.......");

				gm.SendMessage (ending.ToString("F")+"Ev");

		}

		public enum keynum{
				GOLD = -1,
				SILVER = 1,
				NOKEY = 99,
		}
		public enum endElevator{
				NOCROSS = 1,
				TOONE,
				TOUNDERGROUND,
		}
		public enum endstate{
				NORMAL,
				NOCROSS,
				ONENOKEY,
				ONEWITHKEY,
				UNDERNOKEY,
				UNDERWITHKEY,
				UNDERWITHONEKEY,
		}
}