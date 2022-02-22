using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PlayerController playerController;
    public Text levelCount;

    void Start() {
        gameOverPanel.SetActive(false);
    }
    public void ActivatePanel() {
        gameOverPanel.SetActive(true);
        DisplayLevelCount();
    }
    
    private void DisplayLevelCount() {
        levelCount.text = playerController.LevelCount.ToString();
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
