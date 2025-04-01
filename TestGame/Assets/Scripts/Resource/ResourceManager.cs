using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public ResourceData resourceData; // ������ �� ScriptableObject
    public event Action OnResourceUpdated; // ������� ��� ���������� UI
 
    [SerializeField] PopupResurceEnable popupInfo;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddResource(string resourceName, int amount)
    {
        resourceData.AddResource(resourceName, amount);       
        OnResourceUpdated?.Invoke();
        popupInfo.EnablePopup(resourceName, GetResourceAmount(resourceName));
    }

    public int GetResourceAmount(string resourceName)
    {
        return resourceData.resources.ContainsKey(resourceName) ? resourceData.resources[resourceName] : 0;
    }
}
