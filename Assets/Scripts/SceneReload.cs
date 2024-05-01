using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    void Update()
    {
        // Überprüfen, ob die R-Taste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Die aktuelle Szene neu laden
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
                if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Das Spiel beenden
            Application.Quit();
        }
    }
}

