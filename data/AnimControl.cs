using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "95929a2e4ccd1bb59090799003447faf29e02942")]
public class AnimControl : Component
{
	[ShowInEditor][ParameterAsset(Filter =".anim")]
	private string EngineAnim;

    [ShowInEditor]
    public ObjectMeshSkinned MainEngine;

	private void Init()
	{

        //MainEngine = node as ObjectMeshSkinned;
        MainEngine = (ObjectMeshSkinned)Node.GetNode(662564463);
		MainEngine.NumLayers = 1;


        int _def = MainEngine.AddAnimation(EngineAnim);

		MainEngine.SetLayer(0, true, 1);

		MainEngine.SetAnimation(0, _def);
		
	}
	
	private void Update()
	{
		if (Input.IsKeyPressed(Input.KEY.E) && MainEngine.GetFrame(0) < 376)
		{
            MainEngine.SetFrame(0, MainEngine.GetFrame(0) + Game.IFps *	30, 0, 380);
        }else if(Input.IsKeyPressed(Input.KEY.Q) && MainEngine.GetFrame(0) > 0)
		{
            MainEngine.SetFrame(0, MainEngine.GetFrame(0) - Game.IFps * 30, 0, 380);
        }

		Unigine.Console.WriteLine(MainEngine.GetFrame(0));
        // write here code to be called before updating each render frame

    }
}