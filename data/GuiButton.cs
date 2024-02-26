using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "ce2889b94e6ea7c4b1099053218759969da643fd")]
public class GuiButton : Component
{
	Gui gui;
	WidgetButton btStart_m1, btStart_m2, btContinue, btExit, btRestart, btAboutGame;
	public Node player;
	public Node player_movable;
	// //gameCamera - 839766792
	// //menuCamera - 1530584982

	public bool MenuShow;
	void gameStart(int width, int height, bool mode){
		
		game();
		if (mode)
		{
            Node.GetNode(1842036553).WorldPosition = new vec3(3.50543f, 24.91831f, 0);
        }
		else
		{
            Node.GetNode(1842036553).WorldPosition = new vec3(8.93745f, 24.91831f, 0);
        }
    }

    public void game(){
		Game.Player = (Player)Node.GetNode(487317287);
		MenuShow = false;
		ControlsApp.MouseHandle = Input.MOUSE_HANDLE.GRAB;
		gui.RemoveFocus();
		Node.GetNode(1935626555).Enabled = true;
	}

	void gameContinue(){
		// manager.gameStartContinue();
		Game.Player = (Player)Node.GetNode(487317287);
		MenuShow = false;
		ControlsApp.MouseHandle = Input.MOUSE_HANDLE.GRAB;
		// Node.GetNode(1935626555).Enabled = true;
		gui.RemoveFocus();
	}

	void menuStart(){
		// Node.GetNode(1935626555).Enabled = false;
		Game.Player = (Player)Node.GetNode(1504055302);
		MenuShow = true;
		ControlsApp.MouseHandle = Input.MOUSE_HANDLE.USER;
		gui.RemoveFocus();
	}

	void gameExit(){
		App.Exit();
	}

	void movePlayer(){
		// Game.Player = (Player)Node.GetNode(1115336465);
		// Node.GetNode(1935626555).Enabled = false;
		Game.Player = (Player)Node.GetNode(2058851049);
		MenuShow = false;
		ControlsApp.MouseHandle = Input.MOUSE_HANDLE.USER;
		gui.RemoveFocus();
	}

	private void Init()
	{
		// Node.GetNode(1935626555).Handled = true;
		// Node.GetNode(1935626555).UpdateEnabled();


		gui = (node as ObjectGui).GetGui();
		int width = gui.Width, height = gui.Height;

		btStart_m1 = new WidgetButton(gui, "START MANUAL");
		btStart_m1.Width = 300;
		btStart_m1.Height = 100;
		btStart_m1.ButtonColor = new vec4(1, 0, 0, 1);
		btStart_m1.FontSize = 30;

        btStart_m2 = new WidgetButton(gui, "START ANIM");
        btStart_m2.Width = 300;
        btStart_m2.Height = 100;
        btStart_m2.ButtonColor = new vec4(1, 0, 0, 1);
        btStart_m2.FontSize = 30;

        btContinue = new WidgetButton(gui, "CONTINUE");
		btContinue.Width = 300;
		btContinue.Height = 100;
		btContinue.ButtonColor = new vec4(1, 0, 0,1 );
		btContinue.FontSize = 30;

		btRestart = new WidgetButton(gui, "AUTHORS");
		btRestart.Width = 300;
		btRestart.Height = 100;
		btRestart.ButtonColor = new vec4(1, 0, 0,1 );
		btRestart.FontSize = 30;

		btAboutGame = new WidgetButton(gui, "ABOUT");
		btAboutGame.Width = 300;
		btAboutGame.Height = 100;
		btAboutGame.ButtonColor = new vec4(1, 0, 0,1 );
		btAboutGame.FontSize = 30;

		btExit = new WidgetButton(gui, "EXIT");
		btExit.Width = 300;
		btExit.Height = 100;
		btExit.ButtonColor = new vec4(1, 0, 0,1 );
		btExit.FontSize = 30;

		btStart_m1.SetPosition(width / 2 - btStart_m1.Width / 2, height / 2 - btAboutGame.Height / 2 - btStart_m1.Height - 10);
		btStart_m2.SetPosition(width / 2 - btStart_m2.Width / 2, height / 2 - btAboutGame.Height / 2 - btStart_m2.Height*2 - 20);
		btAboutGame.SetPosition(width / 2 - btAboutGame.Width / 2, height / 2 - btAboutGame.Height / 2);
		btExit.SetPosition(width / 2 - btExit.Width / 2, height / 2 + 10 + btAboutGame.Height / 2);

		btContinue.SetPosition(width / 2 - btContinue.Width / 2, height / 2 - 15 - btStart_m1.Height - btContinue.Height);
		btRestart.SetPosition(width / 2 - btRestart.Width / 2, height / 2 - 5 - btRestart.Height);

		gui.AddChild(btStart_m1, Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);
		gui.AddChild(btStart_m2, Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);
		gui.AddChild(btRestart, Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);
		gui.AddChild(btContinue, Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);
		gui.AddChild(btAboutGame, Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);
		gui.AddChild(btExit, Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);

		btStart_m1.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => gameStart(width, height, false));
		btStart_m2.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => gameStart(width, height, true));
		btContinue.AddCallback(Gui.CALLBACK_INDEX.CLICKED, gameContinue);
		btRestart.AddCallback(Gui.CALLBACK_INDEX.CLICKED, movePlayer);
		btExit.AddCallback(Gui.CALLBACK_INDEX.CLICKED, gameExit);

		btContinue.Hidden = true;
		btRestart.Hidden = true;

		MenuShow = true;
		Game.Player = (Player)Node.GetNode(1504055302);
		ControlsApp.MouseHandle = Input.MOUSE_HANDLE.USER;
	}
	
	private void Update()
	{

        Unigine.Console.WriteLine(Node.GetNode(1842036553).WorldPosition);

        if (Input.IsKeyDown(Input.KEY.ESC) && MenuShow){
			game();
		}
		else if (Input.IsKeyDown(Input.KEY.ESC)){
			menuStart();
		}
	}
}