using UnityEngine;

public class FiilGenerator : MonoBehaviour
{
  


void Update()
{
    if(ToolManager.Instance.currentTool==CurrentTool.fiilTool)
    {
    FiilAmount(ColorGenerator.Instance.color);

    }
}



void FiilAmount(Color color)
 {
      Vector3 mousePosition = Input.mousePosition;

    
    if (mousePosition.x < 0 || mousePosition.x > Screen.width || mousePosition.y < 0 || mousePosition.y > Screen.height)
    {
        return;
    }

    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);
    if (hit.collider != null)
    {
        Debug.Log(hit.collider);
        SpriteRenderer spriteRenderer = hit.collider.gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
        else if(spriteRenderer==null)
        {
            Debug.Log("COMPONENT YOK");
        }
       
    }
}




 public void SavedData()
    {

    }

    public void LoadData()
    {
        
    }









}

