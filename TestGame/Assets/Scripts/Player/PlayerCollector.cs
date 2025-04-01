using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] Collider currentBuildingCollider;
    [SerializeField] GameObject buildingFarm;

    public void SetBuldingFarm(GameObject farmObj)
    {
        buildingFarm = farmObj;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentBuildingCollider = other;

        if (other.tag == "Building" && buildingFarm == other.gameObject)
        {
            Collect(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentBuildingCollider = null;     
    }

    public void CollectInPlace()
    {
        if (currentBuildingCollider != null && buildingFarm != null)
        {
            Collect(currentBuildingCollider);
        }
    }

    private void Collect(Collider other)
    {
        ICollect collectible = other.GetComponent<ICollect>();

        if (collectible != null)
        {
            collectible.Collect();
        }
    }
}
