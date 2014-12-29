using UnityEngine;
using System.Collections;

public class Message: MonoBehaviour {
		private string text = "text field";
		public bool ongui;
		public GUISkin cinema;
		public GUISkin cinemadef;

		private string message = "正解！\n 次のかいへ。";
		private float windowwidth;
		private float windowheight;
		private float fontsize;
		private float line;
		//int remain = 3;
		private Color defc;
		private Color tempc;
	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.message = this.gameObject;
				text = message;
				//windowwidth = GameSceneManager.gm;
				windowwidth = Screen.width / 3.0f;
				windowheight = Screen.height / 3.0f;
				fontsize = Screen.height / 42.0f;

				windowheight = fontsize * line * 1.2f;
				windowwidth = fontsize * 16.0f;
				cinema.window.normal.textColor = cinemadef.window.normal.textColor;
				defc = cinema.window.normal.textColor;
				tempc = new Color (defc.r, defc.g, defc.b, 1f);
				//cinema.window.normal.textColor = new Color (defc.r,defc.g,defc.b,1f);
				iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));

	}
	
	// Update is called once per frame
	void Update () {

	}

		void hide(int type){
				ongui = false;
				iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
				deq();
		}
		void visible(int type){
				ongui = true;
				//iTween.ValueTo (this.gameObject,iTween.Hash("from",0,"to",1.0f,"time",0.8f,"oncompletetarget",this.gameObject,"oncomplete","supportvisi","onupdate","colorupdate"));
				//iTween.ColorTo (gameObject,iTween.Hash("a",1.0f,"time",12.0f,"oncompletetarget",this.gameObject,"oncomplete","supportvisi"));
				iTween.ValueTo (this.gameObject,iTween.Hash("from",0.0f,"to",1.0f,"time",0.8f,"onupdate","colorupdate","oncompletetarget",this.gameObject,"oncomplete","deq"));
				//deq ();
		}
		void supportvisi(){
				//ongui = true;
				deq ();
		}
		void goalcal(int type){
				changeMessage(GameSceneManager.m);
				deq ();
		}
		void colorupdate(float value){
				tempc.a = value;
				cinema.window.normal.textColor = tempc;
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}

		private float heightPos = 2.0f; 
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
						var rect = new Rect ((Screen.width - windowwidth) / 2.0f, (Screen.height-windowheight+Screen.height / 21) / heightPos + Screen.height*105.0f/1136.0f, windowwidth, windowheight);
						GUI.Window (0, rect, fc, text);
				}

		}
		void fc(int windowID){}




		void changeMessage(MessageState m) {
				//GameSceneManager.remain--;
				switch(m){
				case MessageState.INTROTOGAME:
						text = "ヴァンパイアホテルへ\n" +
						                               "ようこそ...\n" +
						                               "ご案内の前に、当館の規約を\n" +
						                               "ご確認くださいませ。\n";
						line = 10.0f;
						break;
				case MessageState.INTROTOGAME2:
						text = "１．１階ごとに謎を１つ解く\n" +
						                               "２．答えはすべてひらがなで\n" +
						                               "３．困ったら右上のボタンを\n";
						line = 8.0f;
						break;
				case MessageState.INTROTOGAME3:
						text = "それでは、上へ参りましょう...";
						line = 4.0f;
						break;
				case MessageState.CORRECT:
						text = "正解！\n次の階へ。";//CORRECT
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
						                               "<b>偶</b>然ではなく<b>奇</b>跡だった。\n\n" +
						                               "鍵をひとつ、手に取れ。\n\n\n\n" +
						                               "? ? ? ? ? ?   ? ? ? ? ? ?\n" +
						                               "‾ ‾ ‾ ‾ ‾ ‾   ‾ ‾ ‾ ‾ ‾ ‾";
						line = 18.0f;
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
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "「チヲ…ノマセロ！！！」";
						break;
				case MessageState.GUWAAAAAAAA:
						tempc = new Color (defc.r, defc.g, defc.b, 0f);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject, iTween.Hash ("from", 1.0f, "to", 0.0f, "time", 0.01f, "onupdate", "colorupdate"));
						text = "「グワァアア・・・！！」";
						line = 4.0f;
						break;
				case MessageState.NOCROSS:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "吸血鬼は容赦なく私の血を吸って\nいく、遠のく意識の中で、私は悩\nみ続けていた。\n" +
						                               "「偶然」とは「奇跡」とは、一体\n何だったのだろうと……\n\n" +
						                               "BADEND...";
						line = 14f;
						break;
				case MessageState.ONENOKEY:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "入口ドアの鍵を持ってない私は、\n必死に扉を叩くしかなかった。\n" +
						                               "「誰か！！開けてください！！！」\n" +
						                               "漏れてくる光も、次第に弱まり、\n玄関広間は闇に溶け込んだ。\n" +
						                               "私も、やみニ…溶ケ……\n\n" +
						                               "BADEND...";
						line = 14f;
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
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "しかし、あの吸血鬼の正体は、\n一体何だったのだろう……\n\n" +
						"CLEAR...";
						line = 8f;
						break;
				case MessageState.UNDERNOKEY:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "冷たい地下室、おどろおどろしい\n棺、エレベーターがここまで降り\n" +
						                                                                           "てくることはないだろう…。部屋\nから抜け出す通路も探しだすこと\n" +
						                                                                               "はできなかった。\n" +
						                               "...地下室の遺体は２体になった\n\n" +
						                                                                               "BADEND...";
						line = 16f;
						break;
				case MessageState.UNDERWITHONEKEY:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "冷たい地下室、おどろおどろしい\n棺、エレベーターがここまで降り\n" +
						"てくることはないだろう…。部屋\nから抜け出す通路も探しだすこと\n" +
						"はできなかった。手元にあるのは\nもはや役に立たない鍵だけ。\n" +
						                               "...地下室の遺体は２体になった\n\n" +
						"BADEND...";
						line = 18f;
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
						                               "いつか、TDLに呪われた人が、\n皆救われることを信じて……\n\n" +
						"TRUE END...";
						line = 12f;
						break;
				case MessageState.NOCROSSTEST:
						tempc = new Color (1, 1, 1, 0);
						cinema.window.normal.textColor = tempc;
						iTween.ValueTo (this.gameObject,iTween.Hash("from",1.0f,"to",0.0f,"time",0.01f,"onupdate","colorupdate"));
						text = "テキストきりかえ！";
						line = 4.0f;
						break;   
				case MessageState.preEle1:
						text = "さぁ下に戻りましょう……";
						line = 4.0f;
						break;
				case MessageState.preEle2:
						//tempc = new Color (1, 1, 1, 0);
						//cinema.window.normal.textColor = tempc;
						text = "私が乗ると、エレベーターは突然\n" +
						                               "閉まりはじめた……。";
						line = 4f;
						break;
				case MessageState.preEle3:
						text = "扉の隙間から見えた案内人の顔は､\n薄気味悪く微笑んでいた……";
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
