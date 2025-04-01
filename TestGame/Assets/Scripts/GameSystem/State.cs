using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    [SerializeField] Button openSettingsButton, closeSettingsButton;
    [SerializeField] GameObject UiMenuSettings;
    [SerializeField] StatType stat;

    public enum StatType
    {
        Menu =1,
        Camera =2,
        Move =3
    }

    private void Start()
    {
        openSettingsButton.onClick.AddListener(() => ChangeStat(StatType.Menu));
        closeSettingsButton.onClick.AddListener(() => ChangeStatMenu());
    }

    public void ChangeStat(StatType current)
    {
        stat = current;
    }

    public bool GetStatMove()
    {
        if (stat==StatType.Move)
        {
            return true;
        }
        return false;
    }
    public bool GetStatMenu()
    {
        if (stat == StatType.Menu)
        {
            return true;
        }
        return false;
    }

    public void ChangeStatMenu()
    {
        stat = StatType.Menu;
        UiMenuSettings.SetActive(false);
        StartCoroutine(WaitChangeStateMenu(StatType.Move));
    }
    IEnumerator WaitChangeStateMenu(StatType current)
    {
        yield return new WaitForSeconds(0.4f);
        stat = current;
    }
}
