using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader_random : MonoBehaviour

{
    private string[] scenes = { "SampleScene", "sichume", "svaniinternetshi","umaglesi" };

    public void LoadRandomScene()
    {
        int randomIndex = Random.Range(0, scenes.Length);
        string selectedScene = scenes[randomIndex];
        SceneManager.LoadScene(selectedScene);
    }
}
