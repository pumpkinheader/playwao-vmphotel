using UnityEngine;
using System.Collections.Generic;

public class GameManager : SingletonMonoBehaviour<GameManager> {
	
		public void Awake()
		{
				if(this != Instance)
				{
						Destroy(this);
						return;
				}
				DontDestroyOnLoad(this.gameObject);

				nowload = GameObject.Find ("NowLoadingObj");
				animQ = new Queue<ev> ();
		}
		void Start () {
				touchable = true;
				fromContinue = false;
		}
		void Update () {
		}

		/*
		 * Game
		 */
		public enum Type{
				SEQUENCE=1,
				PARALLEL=2,
				SYSTEM=3,
		}
		private struct ev{
				public GameObject target;
				public string func;
				public Type type;
				public ev(GameObject go,string s,Type t){target = go;func = s;type = t;}
				public ev(GameObject go,string s){target = go;func = s;type = Type.SEQUENCE;}
		}
		private static Queue<ev> animQ;
		private GameObject bg;
		public static bool touchable;

		//Qがnullの時の処理追加！！
		void deq(){
				if (animQ.Count != 0) {
						var now = animQ.Dequeue ();
						if (now.target == null) {
								Debug.Log (now.func + " is Missing");
								deq ();
								//return;
						} else {
								Debug.Log ("EVENT " + animQ.Count + ": " + now.target.name + "." + now.func + "()" + "@" + now.type);
								if (now.type != Type.SYSTEM)
										now.target.SendMessage (now.func, (int)now.type);
								else {
										now.target.SendMessage (now.func);
										deq ();
								}
						}
				} else {
						Debug.Log ("EVENT X: END EVENT");
						setTouch (true);
				}
		}
		void setq(GameObject target,string func){animQ.Enqueue (new ev(target,func));}
		void setq(GameObject target,string func,Type type){animQ.Enqueue (new ev(target,func,type));}
		void setTouch(bool b){touchable = b;}

		/*
		 * Title
		 */

		public GameObject titlelogo;
		public GameObject startlogo;
		public GameObject continuelogo;
		public GameObject pwlogo;
		public GameObject zklogo;
		public GameObject intr;
		public GameObject intrtimer;
		public GameObject im;
		public GameObject nowload;
		public GameObject titleManager;

		void startEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (startlogo,"move",Type.PARALLEL);
				setq (continuelogo,"move",Type.PARALLEL);
				setq (pwlogo,"move",Type.PARALLEL);
				setq (zklogo,"move",Type.PARALLEL);
				setq (titlelogo,"move");
				setq (im,"goalcal");
				setq (im,"visible");
				//setq (intr,"visible");
				fromContinue = false;
				keyview = false;
				introCount = 0;
				introEv ();
				Debug.Log (animQ);
				//nowload.SendMessage ("visible");
				//deq ();
		}
		public int introCount = 1;
		void introEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				intro.touchable = false;
				if (introCount == 2) {
						setq (intrtimer,"waittimerintro");
						setq (im, "hide");
						setq (titleManager, "toGame");
						deq ();
				} else {
						introCount++;
						setq (intrtimer,"waittimerintro");
						//intro.m++;
						setq (im, "hide");
						setq (im, "goalcal");
						setq (im, "visible");
						introEv();
						//setq (nowload,"visible",Type.PARALLEL);
				}
				//Application.LoadLevel ("GameScene");
		}
		public bool fromContinue = false;
		void continueEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (startlogo,"move",Type.PARALLEL);
				setq (continuelogo,"move",Type.PARALLEL);
				setq (pwlogo,"move",Type.PARALLEL);
				setq (zklogo,"move",Type.PARALLEL);
				setq (titlelogo,"move");
				setq (titleManager,"toGame");
				this.fromContinue = true;
				deq ();
		}
		void zerokitEv(){
				Application.OpenURL ("http://zer0kit.web.fc2.com/");
		}
		void playwaoEv(){
				Application.OpenURL ("http://playwao.blog.fc2.com/");
		}


		/*
		 * GameScene 
		 */

		public GameObject door;
		public GameObject menu;
		public GameObject optionbutton;
		//public GameObject qback;
		public GameObject q;
		public GameObject back;
		public GameObject gui;
		public GameObject message;
		public GameObject option;
		public GameObject list;
		public GameObject gsm;

		public GameObject elepanel;
		public GameObject timer;
		public GameObject endback;
		public GameObject colli;
		public GameObject backth;
		public GameObject blood;
		public GameObject fogall;
		public GameObject fogback;
		public GameObject batnum;
		public GameObject batmanage;

		//GameStart
		void gamestartEv(){
				setq (nowload,"hide",Type.PARALLEL);
				setq (batnum,"init");
				NEXTEv ();
				//deq ();
		}

		//optionEv
		void optionbuttonEv(){
				if (keyview) {
						keyview = false;
						setq (menu,"bottomon");
				}
				setq (menu,"keyoff");
				setq (message, "hide",Type.PARALLEL);
				setq (gui,"hide",Type.PARALLEL);
				setq (q,"hide",Type.PARALLEL);
				setq (option,"hide",Type.PARALLEL);
				setq (list,"hide");
				setq (colli,"hide");

				setq (batmanage,"patapataup");
				setq (menu, "close");
				setq (menu,"replacetomenu");

				setq (option,"goalcal");
				setq (menu,"optionopen");
				setq (option,"visible");
				deq ();
		}
		void backtopEv(){
				Application.LoadLevel ("TitleScene");
		}
		void logEv(){
				setq (option,"hide");
				setq (list,"goalcal");
				setq (menu,"listopen");
				setq (list,"visible");
				deq ();
		}


		//floorChange
		void QEv(){
				if (GameSceneManager.floorNum == 11 && GameSceneManager.before == GameSceneManager.state.MENU) {elevenEv ();return;}
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (gui,"hide",Type.PARALLEL);
				setq (q, "hide",Type.PARALLEL);
				setq (option,"hide",Type.PARALLEL);
				setq (list,"hide");

				setq (menu, "close");
				setq (menu,"replaceBar",Type.SYSTEM);


				setq (door,"open");
				setq (batmanage,"shakewing");
				setq (menu,"open");
				setq (q,"visible");
				deq ();


		}
		void ANSWEREv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				//方針外だが、緊急措置として、ここにゲーム状態に応じる条件分岐を入れた

				if (GameSceneManager.before == GameSceneManager.state.MENU) {
						setq (gui, "hide", Type.PARALLEL);
						setq (q, "hide", Type.PARALLEL);
						setq (option, "hide", Type.PARALLEL);
						setq (list, "hide");
						setq (q,"qreturn",Type.SYSTEM);

						setq (menu, "close");
						setq (menu, "replaceBar", Type.SYSTEM);

						setq (menu, "fullopen");
						setq (q, "visible",Type.PARALLEL);
						setq (q, "move");
						setq (gui, "visible");
				} else {
				
						setq (menu, "fullopen");
						setq (menu, "replaceBar", Type.SYSTEM);
						setq (q, "move");
						//setq (q, "visible");
						setq (gui, "visible");
				}
				deq ();
		}
		void RESULTEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (gui,"hide",Type.PARALLEL);
				setq (q, "hide",Type.PARALLEL);
				setq (option,"hide",Type.PARALLEL);
				setq (list,"hide");

				setq (menu, "close");
				setq (menu,"replaceBar",Type.SYSTEM);

				setq (message,"goalcal");
				setq (menu,"open");
				setq (message,"visible");
				deq ();
		}

		void NEXTEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (gsm,"floorchange");
				setq (gsm,"stateUp",Type.SYSTEM);
				setq (q,"next",Type.SYSTEM);
				setq (message, "hide");
				setq (menu, "close",Type.PARALLEL);
				setq (fogall,"visible");
				setq (door,"close");

				setq (fogback,"stop");
				setq (fogback,"setDefault");
				setq (menu,"roomnumup",Type.SYSTEM);
				setq (menu,"replaceBar",Type.SYSTEM);

				if (GameSceneManager.floorNum != 14) {
						setq (batmanage, "roomup",Type.PARALLEL);
						setq (door, "shake");
				}
				setq (fogback,"move");
				//setq (door,"open");
				if (GameSceneManager.floorNum == 10)
						elevenEv ();
				else if (GameSceneManager.floorNum == 12)
						thirteenstartEv ();
				else
						QEv ();
		}

		void elevenEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (gui,"hide",Type.PARALLEL);
				setq (q, "hide");
				setq (option,"hide",Type.PARALLEL);
				setq (list,"hide");

				//setq (menu, "close");
				setq (menu,"replaceBar",Type.SYSTEM);

				setq (door,"open");
				setq (menu, "fullopen");
				setq (q,"visible");
				setq (q, "elevenmove");
				deq ();
		}

		void thirteenstartEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (q,"hide");
				setq (message, "hide");
				setq (menu, "close",Type.PARALLEL);
				setq (menu,"replaceBar",Type.SYSTEM);

				setq (backth,"visible");

				setq (door,"open");

				setq (message,"goalcal");
				setq (menu,"open",Type.PARALLEL);
				setq (message, "visible");
				deq ();
		}

		void THIRTEENEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (message, "hide");
				setq (option,"hide",Type.PARALLEL);
				setq (list, "hide");
				setq (menu, "close");
				setq (menu,"replaceBar",Type.SYSTEM);
				setq (menu, "hide");
				//setq (door,"close");

				//setq (backth,"visible");

				//setq (door,"shake");
				if (GameSceneManager.thcounter == 3) {
						keyEv ();
						return;
				}
				setq (door,"openth");
				setq (colli,"visible");

				/*
				setq (message,"goalcal");
				setq (menu,"open");
				setq (message, "visible");
				*/
				deq ();
		}
		void closeEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (message, "hide");
				setq (menu, "close");
				deq ();
		}


		//THIRTEEN
		void closethEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (message, "hide");
				setq (menu, "close");
				setq (menu,"hide");
				setq (colli,"visible");
				deq ();
		}
		void messageEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (colli,"hide");
				//setq (menu,"visible");
				setq (message,"goalcal");
				setq (menu,"open",Type.PARALLEL);
				setq (message,"visible");
				deq ();
		}
		private bool keyview = false;
		void keymessageEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (colli,"hide");
				setq (gui, "hide", Type.PARALLEL);
				//setq (q, "hide", Type.PARALLEL);
				setq (option, "hide", Type.PARALLEL);
				setq (list, "hide");
				setq (message,"movere",Type.PARALLEL);
				//setq (menu,"move");

				if (!keyview) {
						setq (menu, "bottomoff");
						//setq (menu, "visible");
						setq (message, "goalcal");
						setq (menu, "open");
						setq (message, "visible");
						setq (menu, "fullopen");
						setq (message,"move");
						setq (menu,"keyon");
						keyview = true;
				} else {
						setq (menu, "close");
						setq (menu, "bottomoff");
						setq (menu, "fullopen");
						setq (menu,"keyon");
				}
						
				deq ();
		}

		void preEleEv(){
				//issue81
				//エレベーター前のメッセージ
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				//menuBAR初期化
				setq (message,"movere");
				setq (menu,"keyoff",Type.PARALLEL);
				setq (message, "hide",Type.PARALLEL);
				setq (menu, "close");
				//setq (menu,"hide");

				//messagevisibleをいれないといけないかな？？？
				//下の階に降りましょう＿＿＿
				setq (gsm, "setmessageBlood", Type.SYSTEM);
				setq (gsm, "changeMessageInc",Type.SYSTEM);
				setq (message, "goalcal");
				setq (menu,"open");
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (message, "hide");
				setq (menu, "closeNoHide");
				//setq (menu,"hide");

				setq (door,"closeEle1",Type.PARALLEL);
				setq (fogall,"visiblefull");

				//エレベーターは閉まり始めた
				setq (gsm, "changeMessageInc",Type.SYSTEM);
				setq (message, "goalcal");

				setq (menu, "open", Type.PARALLEL);
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (timer,"waitasecond");
				setq (timer,"waitasecond");
				setq (message, "hide");
				//setq (menu, "closeNoHide");

				//扉から見えた管理人
				setq (gsm, "changeMessageInc",Type.SYSTEM);
				setq (message, "goalcal");

				setq (menu, "open", Type.PARALLEL);
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (timer,"waitasecond");

				setq (door, "closeEle2");
				setq (message, "hide");
				setq (menu, "close");
				setq (gsm,"setmessageBlood", Type.SYSTEM);
				setq (gsm,"stateUp",Type.SYSTEM);
				ELEPANELEv ();
				//deq ();

		}
		void keyEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (gsm, "setmessageBlood", Type.SYSTEM);
				setq (gsm,"stateUp",Type.SYSTEM);
				setq (message,"movere");

				//setq (door,"shake",Type.PARALLEL);
				setq (menu,"keyoff",Type.PARALLEL);
				//setq (menu, "remove",Type.PARALLEL);
				setq (message, "hide",Type.PARALLEL);
				setq (menu,"hide");
				setq (menu, "close",Type.PARALLEL);
				setq (menu,"bottomon");
				setq (door,"closeth");
				setq (fogall, "visibleEle");
				setq (menu,"overdoor",Type.PARALLEL);
				//setq (menu,"visible");
				setq (message,"goalcal");
				setq (menu,"open");
				setq (message,"visible");
				deq ();
		}
		void ELEPANELEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (message,"hide");
				setq (menu,"close");
				setq (menu,"hide");
				setq (menu,"bottomoff");
				setq (elepanel,"visible");

				//setq (fogall, "tored");
				//setq (blood,"start");
				setq (door,"shaketh",Type.PARALLEL);
				setq (timer, "start");
				//setq (this.gameObject,"timeupEv");
				deq ();
		}

		public float limit = 6.0f;
		void timeupEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				//setq (fogall,"fog");
				setq (elepanel,"hide");
				setq (elepanel,"checkbutton");
				setq (door,"stop");
				//setq (door,"close",Type.PARALLEL);
				//setq (blood,"hide");
				setq (fogback,"hide");
				setq (fogall,"towhite");
				setq (fogall,"hideEnd");
				setq (gsm,"checkend",Type.SYSTEM);
				//setq (endback, "visible");
				deq ();
		}

		public GameObject bc_end;
		public GameObject UICamera;
		public GameObject MainCamera;
		public GameObject Endobj;
		void NORMALEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				setq (fogall,"fog");
				setq (bc_end,"setSprite");
		}
		/*void NOCROSSEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);

				setq (back,"hide",Type.PARALLEL);
				setq (backth,"hide");
				setq (bc_end,"setSprite");
				setq (door,"openend",Type.PARALLEL);
				setq (UICamera,"hide",Type.PARALLEL);
				setq (fogback,"visibleEnd");
				setq (bc_end,"visible");
				setq (message,"goalcal");
				setq (message,"visible");

				//change message state
				setq (gsm,"checkend",Type.SYSTEM);
				setq (timer,"waittimer");
				//scroll
				setq (message, "hide");
				setq (message,"goalcal");
				setq (bc_end,"scroll");
				setq (message,"visible");
		}*/
		void NOCROSSEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				//setq (fogall,"fog");
				setq (bc_end,"setSprite");
				setq (UICamera,"hide",Type.PARALLEL);
				setq (bc_end,"visible");
				setq (message,"goalcal");
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (Endobj,"enableColli");
		}
		void ONENOKEYEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				//setq (fogall,"fog");
				setq (back,"hide",Type.PARALLEL);
				setq (backth,"hide");
				setq (bc_end,"setSprite");
				setq (MainCamera,"th");
				setq (door,"openend");
				setq (UICamera,"hide",Type.PARALLEL);
				setq (bc_end,"visible");
				setq (message,"goalcal");
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (Endobj,"enableColli");
		}
		void ONEWITHKEYEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);

				setq (back,"hide",Type.PARALLEL);
				setq (backth,"hide");
				setq (bc_end,"setSprite");
				setq (MainCamera,"th2");
				setq (door,"openend",Type.PARALLEL);
				setq (UICamera,"hide",Type.PARALLEL);
				setq (fogback,"visibleEnd");
				setq (bc_end,"visible");
				setq (message,"goalcal");
				setq (message,"visible");

				//change message state
				setq (gsm,"checkend",Type.SYSTEM);
				setq (timer,"waittimer");
				//scroll
				setq (message, "hide");
				setq (message,"goalcal");
				setq (bc_end,"scroll");
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (Endobj,"enableColli");
		}
		void UNDERNOKEYEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				//setq (fogall,"fog");
				setq (back,"hide",Type.PARALLEL);
				setq (backth,"hide");
				setq (bc_end,"setSprite");
				setq (door,"openend");
				setq (MainCamera,"th");
				setq (UICamera,"hide",Type.PARALLEL);
				setq (bc_end,"visible");
				setq (message,"goalcal");
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (Endobj,"enableColli");
		}
		void UNDERWITHKEYEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);

				setq (back,"hide",Type.PARALLEL);
				setq (backth,"hide");
				setq (bc_end,"setSprite");
				setq (MainCamera,"th2");
				setq (door,"openend",Type.PARALLEL);
				setq (UICamera,"hide",Type.PARALLEL);
				setq (fogback,"visibleEnd");
				setq (bc_end,"visible");
				setq (message,"goalcal");
				setq (message,"visible");

				//change message state
				setq (gsm,"checkend",Type.SYSTEM);
				setq (timer,"waittimer");
				//scroll
				setq (message, "hide");
				setq (message,"goalcal");
				setq (bc_end,"scroll");
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (Endobj,"enableColli");
		}
		void UNDERWITHONEKEYEv(){
				Debug.Log ("Set Ev : "+System.Reflection.MethodBase.GetCurrentMethod().Name);
				//setq (fogall,"fog");
				setq (back,"hide",Type.PARALLEL);
				setq (backth,"hide");
				setq (bc_end,"setSprite");
				setq (MainCamera,"th");
				setq (door,"openend");
				setq (UICamera,"hide",Type.PARALLEL);
				setq (bc_end,"visible");
				setq (message,"goalcal");
				setq (message,"visible");
				setq (timer,"waitasecond");
				setq (Endobj,"enableColli");
		}
}
