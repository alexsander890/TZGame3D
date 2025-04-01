using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Game/Resource Data")]
public class ResourceData : ScriptableObject
{
    public Dictionary<string, int> resources = new Dictionary<string, int>();

    public void AddResource(string resourceName, int amount)
    {
        if (!resources.ContainsKey(resourceName))
            resources[resourceName] = 0;

        resources[resourceName] += amount;
    }

    public void ResetResources()
    {
        resources.Clear();
    }
}
