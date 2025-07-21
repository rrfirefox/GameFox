using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string mainMenu;
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
