using System.IO;
using UnityEngine;
using Structs;
using TMPro;
using UnityEngine.UI;

public class JsonManager : MonoBehaviour
{
    [Header("Параметры сохранения")] 
    [SerializeField] private int characterID;

    [Header("Параметры настроек")] 
    [SerializeField] private Slider volume;
    [SerializeField] private Slider music;
    [SerializeField] private Slider sounds;
    [SerializeField] private TMP_Dropdown mode;
    [SerializeField] private TMP_Dropdown resolution;
    
    [Header("Параметры JSON")]
    [SerializeField] private string preservationPath;
    [SerializeField] private string preservationFileName;

    [HideInInspector] public float vol;
    [HideInInspector] public float mus;
    [HideInInspector] public float snd;
    
    void Awake()
    {
        preservationPath = Path.Combine(Application.dataPath + "/Json", preservationFileName);
        Load("settings");
    }
    
    public void Save(string type)
    {
        preservationPath = Path.Combine(Application.dataPath + "/Json", preservationFileName);
        string json;
        
        switch (type)
        {
            case "playerInfo": 
                PreservationStruct preservationStruct = new PreservationStruct
                {
                    characterID = characterID
                };

                 json = JsonUtility.ToJson(preservationStruct, true);
        
                File.WriteAllText(preservationPath, json); 
            break;
            case "settings":
                SettingsStruct settingsStruct = new SettingsStruct
                {
                    volume = volume.value,
                    music = music.value,
                    sounds = sounds.value,
                    mode = mode.value,
                    resolution = resolution.value
                };
                
                 json = JsonUtility.ToJson(settingsStruct, true);
        
                File.WriteAllText(preservationPath, json);
            break;
        }
    }

    public void Load(string type)
    {
        if (File.Exists(preservationPath))
        {
            string json = File.ReadAllText(preservationPath);

            switch (type)
            {
                case "playerInfo":
                    PreservationStruct preservationFromJson = JsonUtility.FromJson<PreservationStruct>(json);

                    characterID = preservationFromJson.characterID;
                break;
                case "settings":
                    SettingsStruct settingsFromJson = JsonUtility.FromJson<SettingsStruct>(json);

                    vol = settingsFromJson.volume;
                    mus = settingsFromJson.music;
                    snd = settingsFromJson.sounds;
                    
                    if(volume != null && music != null && sounds != null && mode != null && resolution != null)
                    {
                        volume.value = settingsFromJson.volume;
                        music.value = settingsFromJson.music;
                        sounds.value = settingsFromJson.sounds;
                        mode.value = settingsFromJson.mode;
                        resolution.value = settingsFromJson.resolution;
                    }
                    break;
            }
        }
    }
}
