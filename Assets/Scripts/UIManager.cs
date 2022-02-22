using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverPanel;
    
    void Start() {
        gameOverPanel.SetActive(false);
    }
    public void ActivatePanel() {
        gameOverPanel.SetActive(true);
    }

    public void GoToMenu() {
        SceneManager.LoadScene(0);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitGame() {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
