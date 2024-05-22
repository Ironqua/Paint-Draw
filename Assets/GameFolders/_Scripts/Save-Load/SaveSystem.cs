//using Newtonsoft.Json;
//using System.Collections.Generic;
//using System.IO;
//using Unity.VisualScripting;
//using UnityEngine;



//public class SaveSystem : MonoBehaviour
//{

//    [SerializeField] GameObject spriteCircle;
//    [SerializeField] GameObject cubeSprite;
//    [SerializeField] GameObject triAngleSprite;
//    [SerializeField] GameObject spriteHexagon;
//    GameObject newSprite;
//    public void LoadData(LineRenderer? lineRenderer,
//        List<GameObject>? lineObj,)
//    {
//        string fileName;
//         if (lineRenderer != null)
//        {
//            fileName = "lineData.json";
//        }
//        else
//        {
//            fileName = "spriteData.json";
//        }

//        string filePath = Path.Combine(Application.persistentDataPath, fileName);

//        if (File.Exists(filePath))
//        {
//            if (lineRenderer != null )
//            {
//                string jsonData = File.ReadAllText(filePath);
//                List<Data> lineDataList = JsonConvert.DeserializeObject<List<Data>>(jsonData);


//                if (lineDataList != null && lineDataList.Count > 0)
//                {
//                    foreach (Data lineData in lineDataList)
//                    {
//                        if (lineData != null && lineData.positions != null && lineData.positions.Count > 0)
//                        {
//                            LineRenderer newLine = Instantiate(lineRenderer, Vector2.zero, Quaternion.identity, transform);
//                            newLine.positionCount = 0;

//                            for (int i = 0; i < lineData.positions.Count; i++)
//                            {
//                                newLine.positionCount++;
//                                newLine.SetPosition(i, lineData.positions[i]);
//                            }

//                            if (lineData.saveColors != null && lineData.saveColors.Count > 0 && lineData.saveColors.Count == newLine.positionCount)
//                            {
//                                for (int i = 0; i < lineData.saveColors.Count; i++)
//                                {
//                                    newLine.startColor = lineData.saveColors[i];
//                                    newLine.endColor = lineData.saveColors[i];
//                                }
//                            }
//                            lineObj.Add(newLine.gameObject);
//                        }
//                    }

//                    Debug.Log("data load");
//                }

//            }
//            else
//            {
//                string jsonData = File.ReadAllText(filePath);
//                List<SpriteData> spriteDatas = JsonConvert.DeserializeObject<List<SpriteData>>(jsonData);

//                if (spriteDatas != null && spriteDatas.Count > 0)
//                {
                  
//                    foreach (SpriteData spriteData in spriteDatas)
//                    {
//                        if (spriteData != null)
//                        {

//                            GameObject newSprite = InstantiateSprite(spriteData.spritePos);

//                            if (newSprite != null)
//                            {
//                                Debug.Log("Sprite instantiated at position: " + spriteData.spritePos);
//                            }

//                        }
//                    }

//                    Debug.Log("Data .");
//                }
//            }
//        }

//    }
//    private GameObject InstantiateSprite(Vector3 position)
//    {
//        GameObject newSprite = null;

//        if (cubeSprite != null)
//        {
//            newSprite = Instantiate(cubeSprite, position, Quaternion.identity);
//        }
//        else if (spriteCircle != null)
//        {
//            newSprite = Instantiate(spriteCircle, position, Quaternion.identity);
//        }
//        else if (triAngleSprite != null)
//        {
//            newSprite = Instantiate(triAngleSprite, position, Quaternion.identity);
//        }
//        else if (spriteHexagon != null)
//        {
//            newSprite = Instantiate(spriteHexagon, position, Quaternion.identity);
//        }

//        return newSprite;
//    }

//    private void SaveData(List<GameObject>? sprites)
//    {
//        if (sprites != null)
//        {
//            List<SpriteData> spriteDataList = new List<SpriteData>();

//            foreach (GameObject spriteObject in sprites)
//            {
//                SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();

//                if (spriteRenderer != null)
//                {
//                    SpriteData spriteData = new SpriteData();
//                    spriteData.spritePos = spriteObject.transform.position;

//                    spriteDataList.Add(spriteData);
//                }
//            }

//            var jsonSettings = new JsonSerializerSettings
//            {
//                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
//            };

//            string jsonData = JsonConvert.SerializeObject(spriteDataList, Formatting.Indented, jsonSettings);

//            string filePath = Path.Combine(Application.persistentDataPath, "spriteData.json");
//            File.WriteAllText(filePath, jsonData);

//            Debug.Log("Sprite data saved.");
//        }
//        else
//        {

//        }
//    }
//}

 