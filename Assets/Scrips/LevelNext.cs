using UnityEngine;

public class LevelNext : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LevelManager.instance.LoadNextScene();
        }
    }
}
