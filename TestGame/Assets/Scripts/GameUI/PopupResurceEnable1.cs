using UnityEngine;

public class PopupResurceEnable : MonoBehaviour
{  
    [SerializeField] GameObject prefabPopup;

    public void EnablePopup(string name, int val)
    {
        prefabPopup.SetActive(true);
        prefabPopup.transform.position = new Vector3(gameObject.transform.position.x, 2f, gameObject.transform.position.z);
        prefabPopup.GetComponent<PopupInfoData>().SetDataResurs(name, val.ToString());
    }
}
