using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMenager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu") LoadScene("Main Menu");
    }
}
