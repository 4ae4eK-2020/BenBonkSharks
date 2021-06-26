using UnityEngine;

public class SaveMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private JsonManager json;

    private SaveMusic[] objects;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        json.Load("settings");
        
    }

    void Start()
    {
         objects = FindObjectsOfType<SaveMusic>();
    }
    
    void Update()
    {
        json.Load("settings");
        objects[0].audio.volume = json.vol * json.mus;
        if(objects.Length > 1) Destroy(objects[1]);
    }
}
