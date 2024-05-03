using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public TMP_InputField saveName;
    public Button loadButtonPrefab;
    public string[] saveFiles;
    public void OnSave()
    {
        SerializationManager.Save(saveName.ToString(), SaveData.current);
        Debug.Log("File Saved: " + SaveData.current);
        Debug.Log("Lapis: " + SaveData.current.currency);
    }

    public void GetLoadFiles()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        saveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");
    }
}
