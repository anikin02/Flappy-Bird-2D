using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class saveGame : MonoBehaviour
{
    [SerializeField] private GameObject bird;

    private Save save = new Save();
    private string path;
 
    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (File.Exists(path))
        {   
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            
            bird.GetComponent<Bird>().Record = save.Record;
        }
    }

    private void SaveRecord()
    {
        save.Record = bird.GetComponent<Bird>().Record;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {   
            SaveRecord();
            File.WriteAllText(path, JsonUtility.ToJson(save));
        }   
    }
}

// Class of what we need to save.
[Serializable]
public class Save
{
    public int Record = 0;
}