using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SpriteGenerator : MonoBehaviour
{
public List<GameObject> sprites;


    [SerializeField] GameObject spriteCircle;
    [SerializeField] GameObject cubeSprite;
    [SerializeField] GameObject triAngleSprite;
     GameObject newSprite;

[SerializeField] GameObject spriteHexagon;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnSprite();
        }
       
    }
#region  SPRİTE SPAWN
    public void SpawnSprite()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (mousePosition.x < 0 || mousePosition.x > Screen.width || mousePosition.y < 0 || mousePosition.y > Screen.height)
        {
            return;
        }

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        switch (ToolManager.Instance.currentTool)
        {
            case CurrentTool.cube:
                
                if (cubeSprite != null && hit.collider != null)
                {
                    newSprite= Instantiate(cubeSprite, hit.point, Quaternion.identity);
                    sprites.Add(newSprite);
                }
                break;
            case CurrentTool.circle:
                if (spriteCircle != null && hit.collider != null)
                {
                    newSprite= Instantiate(spriteCircle, hit.point, Quaternion.identity);
                    sprites.Add(newSprite);
                }
                break;
                case CurrentTool.triangle:
                 if (triAngleSprite != null && hit.collider != null)
                {
                   newSprite= Instantiate(triAngleSprite, hit.point, Quaternion.identity);
                   sprites.Add(newSprite);
                }
                break;
                   case CurrentTool.Hexagon:
                 if (spriteHexagon != null && hit.collider != null)
                {
                     newSprite= Instantiate(spriteHexagon, hit.point, Quaternion.identity);
                     sprites.Add(newSprite);
                }
                break;
                case CurrentTool.clearSprite:
                if (hit.collider != null)
                {
                    Destroy(hit.collider.gameObject);
                }
                break;
                

        }
    }


#endregion




    #region  SPRİTE SAVE LOAD 
public void LoadSprites()
{
    string filePath = Path.Combine(Application.persistentDataPath, "spriteData.json");

    if (File.Exists(filePath))
    {
        string jsonData = File.ReadAllText(filePath);
        List<SpriteData> spriteDatas = JsonConvert.DeserializeObject<List<SpriteData>>(jsonData);

        if (spriteDatas != null && spriteDatas.Count > 0)
        {
            foreach (SpriteData spriteData in spriteDatas)
            {
                if (spriteData != null)
                {
                   
                    GameObject newSprite = InstantiateSprite(spriteData.spritePos);

                    if (newSprite != null)
                    {
                        Debug.Log("Sprite instantiated at position: " + spriteData.spritePos);
                    }
                   
                }
            }

            Debug.Log("Data .");
        }
        
    }
    
}

private GameObject InstantiateSprite(Vector3 position)
{
    GameObject newSprite = null;

    if (cubeSprite != null)
    {
        newSprite = Instantiate(cubeSprite, position, Quaternion.identity);
    }
    else if (spriteCircle != null)
    {
        newSprite = Instantiate(spriteCircle, position, Quaternion.identity);
    }
    else if (triAngleSprite != null)
    {
        newSprite = Instantiate(triAngleSprite, position, Quaternion.identity);
    }
    else if (spriteHexagon != null)
    {
        newSprite = Instantiate(spriteHexagon, position, Quaternion.identity);
    }

    return newSprite;
}



    
    public void SaveSprites()
    {
        List<SpriteData> spriteDataList = new List<SpriteData>();

        foreach (GameObject spriteObject in sprites)
        {
            SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
               SpriteData spriteData = new SpriteData();
                spriteData.spritePos = spriteObject.transform.position;

                spriteDataList.Add(spriteData);
            }
        }

        var jsonSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        string jsonData = JsonConvert.SerializeObject(spriteDataList, Formatting.Indented, jsonSettings);

        string filePath = Path.Combine(Application.persistentDataPath, "spriteData.json");
        File.WriteAllText(filePath, jsonData);

        Debug.Log("Sprite data saved.");
    }

    #endregion
}

