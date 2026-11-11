using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    private int _lives;
    private bool _isGameOver;
    readonly int _startingLives = 3;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _restartPanel;

    public static GameManager Instance;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        _lives = _startingLives;
        _isGameOver = false;
        _gameOverPanel.SetActive(false);
        _restartPanel.SetActive(false);
        UpdateUI();
    }

    public void LoseLife()
    {
        if (_isGameOver) return;
        _lives = _lives > 0 ? _lives - 1 : 0;
        UpdateUI();

        if (_lives <= 0) GameOver();
    }

    public void GameOver()
    {
        _isGameOver = true;
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _restartPanel.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        _restartPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        _lives = _startingLives;
        SceneManager.LoadScene(0);
    }

    private void UpdateUI()
    {
        _livesText.text = $"x{_lives}";
        _levelText.text = $"Level: {SceneManager.GetActiveScene().buildIndex + 1}";
    }
}
