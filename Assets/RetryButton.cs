using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    // Attach this function to the onClick event of the RetryButton in the Inspector
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(0);
    }
}
