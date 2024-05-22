using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIButtonManager : MonoBehaviour
{
    [SerializeField] BrushGenerator brushGenerator;
    [SerializeField] SpriteGenerator spriteGenerator;
    [SerializeField] FiilGenerator  fiilGenerator;
    [SerializeField] GameObject menuPanel;

    void Awake()
    {
     
    }
    
    public void Save()
    {
      brushGenerator.SavedData();
      spriteGenerator.SaveSprites();
        fiilGenerator.SavedData();

        //menuPanel.SetActive(true);
    } 

    public void NewScene()
    {
       
       menuPanel.SetActive(false);
    }

    public void Load()
    {
        brushGenerator.LoadData();
        spriteGenerator.LoadSprites();
        fiilGenerator.LoadData();
        menuPanel.SetActive(false);
    }
    
    public void QuitGame()
    {
        brushGenerator.SavedData();
        spriteGenerator.SaveSprites();
        fiilGenerator.SavedData();

        Application.Quit();

    }
}

