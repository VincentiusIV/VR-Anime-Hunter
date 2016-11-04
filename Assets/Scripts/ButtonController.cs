using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    /* This script holds functions that buttons can use
     * when they are clicked.
     * All the functions should be public so that they can
     * be set in the OnClick() event in the Unity3D Editor
     * */

    // Loads new scene based on the given parameter
    public void loadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    // Closes the application
    public void exitButton()
    {
        Application.Quit();
    }

}
