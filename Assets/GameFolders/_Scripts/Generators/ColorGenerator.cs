using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    public static ColorGenerator Instance;
   TypeColor typeColor;
public Color color;

void Awake()
{
    Instance=this;
}
   void Start()
   {
        color = Color.black;
   }
   void Update()
   {
    ColorChoose();
    
   }


   public void ColorRed()
   {
    typeColor=TypeColor.red;
   }

   public void ColorGreen()
   {
   typeColor=TypeColor.green;
   }
   public void ColorBlue()
{
    typeColor= TypeColor.blue;
}
public void ColorPink()
{
    typeColor=TypeColor.pink;
}
public void ColorBlack()
{
    typeColor=TypeColor.black;
}
public void ColorYellow()
{
    typeColor=TypeColor.yellow;
}


public void ColorChoose()
{
    switch(typeColor)
    {

    case TypeColor.red:
    color=Color.red;
    break;
    case TypeColor.green:
    color=Color.green;
    break;
    case TypeColor.black:
    color=Color.black;
    break;
    case TypeColor.blue:
    color=Color.blue;
    break;
    case TypeColor.yellow:
    color=Color.yellow;
    break;
    case TypeColor.pink:
    color=Color.grey;
    break;
    }
    
}

}
