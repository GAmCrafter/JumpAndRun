using UnityEngine;
using UnityEngine.SceneManagement;

public class menuFunctionsLibrary : MonoBehaviour
{
    //creates variable to store name of scene that should be loaded
    string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //assigns sceneName the value of the gameObject's name
        sceneName = transform.name;
    }

    //called on Button click
    public void loadSceneWithName()
    {
        //load Scene with Name SceneName
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    //restarts current level
    public void reloadScene()
    {
        //finds index of current scene and loads it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    //quits the game
    public void quitGame()
    {
        //quits
        Application.Quit();
    }
}
