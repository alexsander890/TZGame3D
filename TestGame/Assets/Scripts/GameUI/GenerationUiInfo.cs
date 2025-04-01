using UnityEngine;
using UnityEngine.UI;

public class GenerationUiInfo : MonoBehaviour
{
    [SerializeField] Text nameText, countText;

    public void SetDataInfo(string name, int val)
    {
        nameText.text = name;
        countText.text = val.ToString();
    }
    
}
