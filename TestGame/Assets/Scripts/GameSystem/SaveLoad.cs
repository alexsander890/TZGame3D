using UnityEngine;
using System.IO;
using System;

public class SaveLoad : MonoBehaviour
{
    public PlayerDataPrefs dataPlayer;
    public static Action loadComplete;

    [SerializeField] bool isWeb;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (!File.Exists(Application.persistentDataPath + "/Json.json"))
        {
            JsonSave();
        }
        else
        {
            JsonLoad();
            loadComplete?.Invoke();
        }
    }


    public void JsonSave()
    {
        File.WriteAllText(Application.persistentDataPath + "/Json.json", JsonUtility.ToJson(dataPlayer));
    }

    public void JsonLoad()
    {
        dataPlayer = JsonUtility.FromJson<PlayerDataPrefs>(File.ReadAllText(Application.persistentDataPath + "/Json.json"));
    }

    public void SaveFloat(string name, float val)
    {
        switch (name)
        {
            case "playerMusicVolume":

                dataPlayer.playerMusicVolume = val;
                JsonSave();
                return;
        }
    }

    public float LoadFloat(string name)
    {
        switch (name)
        {
            case "playerMusicVolume":
                return dataPlayer.playerMusicVolume;
        }
        return 0;
    }

    // Сохранение ресурсов пример

    //public void SaveInt(string name, int val)
    //{
    //    switch (name)
    //    {
    //        case "Gold":            
    //            return;
    //        case "Oil":             
    //            return;
    //    }    
    //}


    //Закрузка ресурсов пример

    //public int LoadInt(string name)
    //{
    //    switch (name)
    //    {
    //        case "levelNumber":
    //            return dataPlayer.levelNumber;
    //        case "coins":
    //            return dataPlayer.coins;          
    //    }
    //    return 0;
    //}




    [System.Serializable]
    public class PlayerDataPrefs
    {
        public float playerMusicVolume = 1;
    }
}
