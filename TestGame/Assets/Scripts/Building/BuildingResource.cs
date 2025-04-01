using System;
using System.Collections;
using UnityEngine;

public class BuildingResource : MonoBehaviour, ICollect
{
    public string resourceName;
    public int resourceAmount = 0;
    public bool isComleteResurs = false;
  

    [SerializeField] GenerationUI generationUi;
    [SerializeField] GenerationUiInfo generationInfo;
    [SerializeField] PlayerCollector playerCollector;
    [SerializeField] float timerGenerateResurs = 0, timePassed = 0;


    private void Start()
    {
        isComleteResurs = false;
        StartCoroutine(GenerateResurs());
    }

    private void OnMouseDown()
    {
        playerCollector.SetBuldingFarm(gameObject);
        playerCollector.CollectInPlace();

    }

    public void Collect()
    {
        if (isComleteResurs)
        {
            ResourceManager.Instance.AddResource(resourceName, resourceAmount);
            isComleteResurs = false;
            resourceAmount = 0;
            StartCoroutine(GenerateResurs());
        }
        else Debug.Log("Ресурс не готов");
    }
 
    IEnumerator GenerateResurs()
    {
        yield return new WaitForSeconds(1);

        if (timePassed < timerGenerateResurs)
        {
            timePassed += 1;
            resourceAmount += 1;
            generationUi.ChangeGenerationProgress(timerGenerateResurs);
            generationInfo.SetDataInfo(resourceName, resourceAmount);
            StartCoroutine(GenerateResurs());         
        }
        else
        {
            if (!isComleteResurs)
            {
                isComleteResurs = true;
                timePassed = 0;
                generationUi.ResetProgress();
                StopAllCoroutines();
            }
        }
    }
}
