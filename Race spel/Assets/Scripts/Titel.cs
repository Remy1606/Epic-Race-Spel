using UnityEngine;
using UnityEngine.SceneManagement;  
public class Titel : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Racing");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}
