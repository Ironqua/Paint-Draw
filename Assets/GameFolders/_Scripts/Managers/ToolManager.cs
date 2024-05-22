using UnityEngine;

public class ToolManager : MonoBehaviour,IToolType
{
    public CurrentTool currentTool;
public static ToolManager Instance;


void Awake()
{
    Instance=this;
}
   void Start()
   {
    currentTool=CurrentTool.pencil;
   }


  public void OnDraw()
   {
    currentTool=CurrentTool.pencil;
    
   }

public void OnClean()
{
    currentTool=CurrentTool.eraser;
}
public void OnFiil()
{
    currentTool=CurrentTool.fiilTool;
}
public void SpriteCircle()
{
    currentTool=CurrentTool.circle;
    Debug.Log(currentTool);

}
public void SpriteCube()
{
    currentTool=CurrentTool.cube;
}

public void SpriteTriAngle()
{
    currentTool=CurrentTool.triangle;
}
public void SpriteHexagon()
{
currentTool=CurrentTool.Hexagon;

}


}
