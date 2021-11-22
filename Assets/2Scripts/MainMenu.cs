using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string tutorial;
    public string loadedLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads the tutorial lever and is attached to the NewGameButton in the editor
    public void StartNewGame()
    {
        //SceneManager.LoadScene("Tutorial");
        LoadingSceneController.LoadScene(tutorial);

    }

    //Quits the game and is attached to the ExitButton in the editor
    public void QuitGame()
    {
        Debug.Log("Game has quit!");
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene(loadedLevel);
    }
}
