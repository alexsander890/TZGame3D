using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    public Text resourceText;
    public ResourceManager resourceManager;


    private void OnEnable()
    {
        resourceManager.OnResourceUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        resourceManager.OnResourceUpdated -= UpdateUI;
    }

    private void UpdateUI()
    {
        //Примерная логика для отображения очков в тексте в канвасе. 
      
        //resourceText.text = "";
        //foreach (var resource in resourceManager.resourceData.resources)
        //{
        //    resourceText.text += $"{resource.Key}: {resource.Value}";
        //}   
    }
}
