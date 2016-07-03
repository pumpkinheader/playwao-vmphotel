using UnityEngine;
using System.Collections;

public class introMesage : MonoBehaviour {

		private string text = "text field";
		public bool ongui;
		public GUISkin cinema;

		private string message = "正解！\n 次のかいへ。";
		private float windowwidth;
		private float windowheight;
		private float fontsize;
		private float line;
		//int remain = 3;
		private Color defc;
		private Color tempc;
		public float heightPos = 2.0f;
		private float index = -1.2f;
		// Use this for initialization
		private GameObject gm;
		private GameManager gmscript;
		void Start () {
				gm = GameObject.Find ("GameManager");
				gmscript = gm.GetComponent<GameManager>();
				gmscript.im = gameObject;
				text = message;
				//windowwidth = GameSceneManager.gm;
				windowwidth = Screen.width / 3.0f;
				windowheight = Screen.height / 3.0f;
				fontsize = Screen.height / 42.0f;

				windowheight = fontsize * line * 1.2f;
				windowwidth = fontsize * 24.0f;
				defc = cinema.window.normal.textColor;
				tempc = new Color (defc.r, defc.g, defc.b, 1f);
				//cinema.window.normal.textColor = new Color (defc.r,defc.g,defc.b,1f);
				iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));

		}

		// Update is called once per frame
		void Update () {

		}

		void hide(int type){
				//cinema.window.normal.textColor = tempc;
				intro.touchable = false;
				iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",1.2f,"onupdate","colorupdate","oncompletetarget",gameObject,"oncomplete","disGui"));

		}
		void visible(int type){
				//cinema.window.normal.textColor = new Color (1,1,1,0);
				index+=0.7f;
				ongui = true;
				//iTween.ValueTo (this.gameObject,iTween.Hash("from",0,"to",1.0f,"time",0.8f,"oncompletetarget",this.gameObject,"oncomplete","supportvisi","onupdate","colorupdate"));
				//iTween.ColorTo (gameObject,iTween.Hash("a",1.0f,"time",12.0f,"oncompletetarget",this.gameObject,"oncomplete","supportvisi"));
				iTween.ValueTo (this.gameObject,iTween.Hash("from",0.0f,"to",1.0f,"time",1.6f,"onupdate","colorupdate","oncompletetarget",this.gameObject,"oncomplete","deq"));
				//deq ();
		}
		void disGui(){
				ongui = false;
				cinema.window.normal.textColor = new Color (defc.r, defc.g, defc.b,0);
				deq();
		}
		void supportvisi(){
				//ongui = true;
				deq ();
		}
		void goalcal(int type){
				changeMessage(intro.m++);
				deq ();
		}
		void colorupdate(float value){
				tempc.a = value;
				cinema.window.normal.textColor = tempc;
		}
		void deq(){
				//intro.touchable = true;
				gm.SendMessage ("deq");
		}
				
		void move(int type){
				iTween.ValueTo (this.gameObject,iTween.Hash("from",2.0f,"to",3.0f,"delay", 0.4f, "time", 0.8f,"oncompletetarget",gameObject,"oncomplete","deq","onupdate","moving"));
		}
		void moving(float value){
				heightPos = value;
		}
		void slideIn(int type){
				iTween.ValueTo (this.gameObject,iTween.Hash("from",2.0f,"to",1.0f,"delay", 0.4f, "time", 0.8f,"oncompletetarget",gameObject,"oncomplete","deq","onupdate","moving"));
		}
		void movere(int type){
				heightPos = 2.0f;
				deq ();
		}

		void OnGUI(){
				cinema.window.fontSize = (int)fontsize;
				GUI.skin = cinema;
				if (ongui) {
						var rect = new Rect ((Screen.width - windowwidth) / 2.0f, (Screen.height-windowheight+Screen.height / 12) / heightPos + Screen.height*105.0f/1136.0f + Screen.height*index/24, windowwidth, windowheight);
						GUI.Window (0, rect, fc, text);
				}

		}
		void fc(int windowID){}




		void changeMessage(MessageState m) {
				//GameSceneManager.remain--;
				switch(m){
				case MessageState.INTRO:
						tempc = new Color (0.9f, 0.9f, 0.8f, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "遊園地「タイニィドリームランド」にあるアトラクシ\nョン、\n「ホーンテッド・ホテル」。\nオーナーが失踪したというホテルを探検する､いわゆる\n「お化け屋敷」のようなアトラクションだ。\n\nこのホテルのオーナーは、ある晩突然姿を消しました｡\n赤い満月が登ったその夜、不思議なことに、宿泊客は\n誰もエレベーターに乗っていなかったそうです。\nその日から､ホテルには良くない噂が立ち始めました。\nエレベーターに乗ると、吸血鬼に襲われる。命からが\nら逃れた人は、こう言ったそうです。";
						line = 24f;
						break;
				case MessageState.INTROTWO:
						tempc = new Color (0.9f, 0.9f, 0.8f, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));

						text = "「自分の身を守ったのは、偶然ではなく奇跡だった」";
						line = 4f;
						break;
				case MessageState.INTROTHIR:
						tempc = new Color (0.9f, 0.9f, 0.8f, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));

						text = "さあ、皆さんもホテルも見学し、噂の真実に近づいて\nみましょう・・・\n\nところで、TDLには様々な都市伝説があります。\nこのアトラクションにまつわる噂は、こう。\n\n「あるとき、アトラクションに入ったまま出てこなか\nったゲストがいるらしい。彼は本物の吸血鬼として永\n遠に囚われているのだ」、と・・・";
						line = 18f;
						break;
				case MessageState.CORRECT:
						text = "正解！\n次のかいへ。";//CORRECT
						line = 4.0f;
						windowheight = fontsize * line;
						break;
				case  MessageState.INCORRECT:
						text = "不正解\nもう一度考えてみましょう・・・";//INCORRECT
						line = 4.0f;
						break;
				case MessageState.INTOTHIRTEEN:
						text = "ここはホテルのオーナー室｡\n" +
						                               "3ヶ所を調べることができます。\nよくお考えの上、調べたい場所を\nタッチしてください。";
						line = 8.0f;
						break;
				case MessageState.DOZO:
						text = "ぐうぜん　　｜　　きせき　\n" +
						                               "イーブン　　｜　　オッド　\n" +
						                               "てんごく　　｜　　じごく　\n" +
						                               "　　くび　　｜　　めだま　\n" +
						                               "ちんぼつせん｜せんちょう　";
						line = 10.0f;
						break;
				case MessageState.HIKIDASHI:
						text = "自分の身を守ったのは、\n" +
						                               "偶然ではなく奇跡だった。\n\n" +
						                               "鍵をひとつ、手に取れ。";
						line = 8.0f;
						break;
				case MessageState.SHELF:
						text = "20XX年5月27日\n\n" +
						                               "　私がここに囚われてから、もう\n何日がたっただろう。一人で出る\n" +
						                               "ことは不可能だった。\n" +
						                               "しかし、吸血鬼として罪のない人\nを襲うのは、もううんざりだ。\n\n" +
						                               "きっと上の連中にはバレている。\n私はさらに狭いところに閉じ込め\n" +
						                               "られるのだ。\n" +
						                               "新しい吸血鬼からゲストの方々が\n逃げ延びてくれることを願いつつ､\n" +
						                               "私は高みから深みへ降りよう。\n\n" +
						                               "地下通路を見つけられさえすれば､\n従業員に紛れて脱出できるのだが､\n" +
						                               "それもはかない幻想だったようだ。\n\n" +
						                               "オーナーたちともお別れか。\n" +
						                               "エレベーターが待っている";
						line = 32.0f;
						break;
				case MessageState.NORMAL:
						int remain = GameSceneManager.remain-GameSceneManager.thcounter;
						if (remain > 0) {
								text = "よく考えてみましょう・・・\n何か手がかりがあるはずです。\n" +
								                                       "残り" + remain + "ヶ所調べられます。";
								line = 6.0f;
						}else{
								text = "よく考えてみましょう・・・\n何か手がかりがあるはずです。";
								line = 4.0f;
						}
						break;
				case MessageState.ELE:
						text = "「チヲ…ノマセロ！！！」";
						break;
				case MessageState.NOCROSS:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "吸血鬼は容赦なく私の血を吸って\nいく、遠のく意識の中で、私は悩\nみ続けていた。\n" +
						                               "「偶然」とは「奇跡」とは、一体\n何だったのだろうと…\n" +
						                               "BADEND...";
						line = 12f;
						break;
				case MessageState.ONENOKEY:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "入口ドアの鍵を持ってない私は、\n必死に扉を叩くしかなかった。\n" +
						                               "「誰か！！開けてください！！！」\n" +
						                               "漏れてくる光も、次第に弱まり、\n玄関広間は闇に溶け込んだ。\n" +
						                               "私も、やみニ…溶ケ…\n" +
						                               "BADEND...";
						line = 12f;
						break;
				case MessageState.ONEWITHKEY:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "鍵を使って、\n" +
						                               "私はホーンテッドホテルを出た。";
						line = 4f;
						break;
				case MessageState.ONEWITHKEYSCROL:
						text = "あの吸血鬼の正体は、\n一体何だったのだろう…\n" +
						                               "CLEAR...";
						line = 6f;
						break;
				case MessageState.UNDERNOKEY:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "冷たい地下室、おどろおどろしい\n棺、エレベーターがここまで降り\n" +
						                               "てくることはないだろう…。部屋\nから抜け出す通路も探しだすこと\n" +
						                               "はできなかった。\n" +
						                               "...地下室の遺体は２体になった\n" +
						                               "BADEND...";
						line = 14f;
						break;
				case MessageState.UNDERWITHONEKEY:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "冷たい地下室、おどろおどろしい\n棺、エレベーターがここまで降り\n" +
						                               "てくることはないだろう…。部屋\nから抜け出す通路も探しだすこと\n" +
						                               "はできなかった。手元にあるのは\nもはや役に立たない鍵だけ。\n" +
						                               "...地下室の遺体は２体になった\n" +
						                               "BADEND...";
						line = 16f;
						break;
				case MessageState.UNDERWITHKEY:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "地下の棺の鍵を使って、私は棺桶\nを開けた。そこには痩せこけた男\n" +
						                               "性が横たわっていた\n" +
						                               "「ありがとう。きっと誰かが私をみ\nつけてくれると信じていた。さぁ､\n" +
						                               "こんな忌まわしいところからは早\nく抜けだそう」";
						line = 14f;
						break;
				case MessageState.UNDERWITHKEYSCROL:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "キャスト専用の地下通路を通り、\n私たちはTDLを抜けだした。\n" +
						                               "いつか、TDLに呪われた人が、\n皆救われることを信じて…\n" +
						                               "TRUE END...";
						line = 10f;
						break;
				case MessageState.NOCROSSTEST:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "テキストきりかえ！";
						line = 4.0f;
						break;   
				default:
						Debug.Log ("UNKNON MESSAGE STATE");
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "テキスト準備中だよ！";
						line = 4.0f;
						break;                           
				}
				windowheight = fontsize * line * 1.0f;
				GameSceneManager.movetogoal.y = windowheight/2.0f;
				Debug.Log ("windowheight = "+windowheight +" goal = "+GameSceneManager.movetogoal.y+"\n"+"fontsize = "+fontsize+" line = "+line );
		}
}
