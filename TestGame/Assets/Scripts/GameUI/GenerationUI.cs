using UnityEngine;
using UnityEngine.UI;

public class GenerationUI : MonoBehaviour
{
    [SerializeField] Image GenerationImage;

    public void ChangeGenerationProgress( float timeIteration)
    {
        float tempProgres =  1/ timeIteration;
        GenerationImage.fillAmount += tempProgres;     
    }

    public void ResetProgress()
    {
        GenerationImage.fillAmount = 0;
    }
}
