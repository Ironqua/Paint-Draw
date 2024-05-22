using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class BrushGenerator : MonoBehaviour
{
 public List<GameObject> lineObj;

    public LineRenderer currentLine;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float distance;
    private Vector2 lastClickPos;

    void Update()
    {

        if (ToolManager.Instance.currentTool == CurrentTool.pencil)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateLine(ColorGenerator.Instance.color);
            }
            else if (Input.GetMouseButton(0))
            {
                Paint();
            }

        }
        else if(ToolManager.Instance.currentTool==CurrentTool.eraser)
        {
             if (Input.GetMouseButtonDown(0))
            {
                CreateLine(Color.white);
            }
            else if (Input.GetMouseButton(0))
            {
                Paint();
            }
        }
    }
#region  LineRenderer
    void CreateLine(Color color)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            currentLine = Instantiate(lineRenderer, Vector3.zero, Quaternion.identity, transform);
            currentLine.startColor = color;
            currentLine.endColor = color;
            currentLine.positionCount = 1;
            currentLine.SetPosition(0, hit.point);
            lastClickPos = Input.mousePosition;
        


            lineObj.Add(currentLine.gameObject);


     }
    }

    void Paint()
    {
        if (currentLine == null)
        {
            return;
        }

        if (Vector2.Distance(lastClickPos, Input.mousePosition) < distance)
        {
            return;
        }

        lastClickPos = Input.mousePosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            AddPoint(hit.point);
        }
    }

    void AddPoint(Vector3 worldPos)
    {
        currentLine.positionCount++;
        currentLine.SetPosition(currentLine.positionCount - 1, worldPos);
    }


#endregion









#region  Line Save Load
 public void LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "lineData.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            List<Data> lineDataList = JsonConvert.DeserializeObject<List<Data>>(jsonData);
            

            if (lineDataList != null && lineDataList.Count > 0)
            {
                foreach (Data lineData in lineDataList)
                {
                    if (lineData != null && lineData.positions != null && lineData.positions.Count > 0)
                    {
                        LineRenderer newLine = Instantiate(lineRenderer, Vector2.zero, Quaternion.identity, transform);
                        newLine.positionCount = 0;
                    
                        for (int i = 0; i < lineData.positions.Count; i++)
                        {
                            newLine.positionCount++;
                            newLine.SetPosition(i, lineData.positions[i]);
                        }

                            if (lineData.saveColors != null && lineData.saveColors.Count > 0 && lineData.saveColors.Count == newLine.positionCount)
                    {
                        for (int i = 0; i < lineData.saveColors.Count; i++)
                        {
                            newLine.startColor = lineData.saveColors[i];
                            newLine.endColor = lineData.saveColors[i];
                        }
                    }
                        lineObj.Add(newLine.gameObject);
                    }
                }

                Debug.Log("data load");
            }
           
        }
       
    }

   public void SavedData()
{
    List<Data> lineDataList = new List<Data>();

    foreach (GameObject lineGameObject in lineObj)
    {
        LineRenderer lineRenderer = lineGameObject.GetComponent<LineRenderer>(); 
        List<Vector3> positions = new List<Vector3>();
        List<Color> colors = new List<Color>(); 

        if (lineRenderer != null)
        {
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                positions.Add(lineRenderer.GetPosition(i)); 
                colors.Add(lineRenderer.startColor); 
            }

            Data lineData = new Data();
            lineData.positions = positions;
            lineData.saveColors = colors; 

            lineDataList.Add(lineData); 
        }
       
    }
  
    var jsonSettings = new JsonSerializerSettings {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };

    string jsonData = JsonConvert.SerializeObject(lineDataList, Formatting.Indented, jsonSettings); 

    string filePath = Path.Combine(Application.persistentDataPath, "lineData.json");
    File.WriteAllText(filePath, jsonData);

    Debug.Log("Data saved.");
}



public void LoadSprites()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "lineData.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            List<Data> lineDataList = JsonConvert.DeserializeObject<List<Data>>(jsonData);
            

            if (lineDataList != null && lineDataList.Count > 0)
            {
                foreach (Data lineData in lineDataList)
                {
                    if (lineData != null && lineData.positions != null && lineData.positions.Count > 0)
                    {
                        LineRenderer newLine = Instantiate(lineRenderer, Vector2.zero, Quaternion.identity, transform);
                        newLine.positionCount = 0;
                    
                        for (int i = 0; i < lineData.positions.Count; i++)
                        {
                            newLine.positionCount++;
                            newLine.SetPosition(i, lineData.positions[i]);
                        }

                            if (lineData.saveColors != null && lineData.saveColors.Count > 0 && lineData.saveColors.Count == newLine.positionCount)
                    {
                        for (int i = 0; i < lineData.saveColors.Count; i++)
                        {
                            newLine.startColor = lineData.saveColors[i];
                            newLine.endColor = lineData.saveColors[i];
                        }
                    }
                        lineObj.Add(newLine.gameObject);
                    }
                }

                Debug.Log("data load");
            }
           
        }
       
    }



#endregion
        
        
        
        }
    








 








   
    

