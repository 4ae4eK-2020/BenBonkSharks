using System.IO;
using UnityEngine;
using Structs;

public class JsonManager : MonoBehaviour
{
    [Header("Параметры сохранения")] 
    public int characterID;

    [Header("Параметры JSON")]
    [SerializeField] private string preservationPath;
    [SerializeField] private string preservationFileName;

     
    
    public void Save()
    {
        PreservationStruct preservationStruct = new PreservationStruct
        {
            characterID = characterID
        };

        preservationPath = Path.Combine(Application.dataPath + "/Json", preservationFileName);

        string json = JsonUtility.ToJson(preservationStruct, true);
        
        File.WriteAllText(preservationPath, json);
    }

    public void Load()
    {
        if (File.Exists(preservationPath))
        {
            string json = File.ReadAllText(preservationPath);
            PreservationStruct preservationFromJson = JsonUtility.FromJson<PreservationStruct>(json);

            characterID = preservationFromJson.characterID;
        }
    }
}
