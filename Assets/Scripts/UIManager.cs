using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverPanel;
    private bool gameOver = false;
    
    void Start() {
        gameOverPanel.SetActive(false);
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.G) && !gameOver) {
            gameOver = true;
            gameOverPanel.SetActive(true);
        }
    }

    public void GoToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitGame() {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
