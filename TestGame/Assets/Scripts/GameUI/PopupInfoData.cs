using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupInfoData : MonoBehaviour
{
    [SerializeField] Text nameResurs, countResurs;
    [SerializeField] float timeDisable = 0;

    private void OnEnable()
    {
        StartCoroutine(WaitDisable());
    }

    public void SetDataResurs(string name, string count)
    {
        if (nameResurs != null && countResurs != null)
        {
            nameResurs.text = name;
            countResurs.text = count;
        }
    }

    IEnumerator WaitDisable()
    {
        yield return new WaitForSeconds(timeDisable);
        gameObject.SetActive(false);
    }
}
