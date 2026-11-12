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
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioSource _bgmSource;

    public static GameManager Instance;


    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        _lives = _startingLives;
        _isGameOver = false;
        _gameOverPanel.SetActive(false);
        _pausePanel.SetActive(false);
        UpdateUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) => UpdateUI();

    public void LoseLife()
    {
        if (_isGameOver) return;
        AudioManager.Instance.PlayTakeDamageSound();
        _lives = _lives > 0 ? _lives - 1 : 0;
        UpdateUI();

        if (_lives <= 0) GameOver();
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        _isGameOver = true;
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;

        if (_bgmSource != null) _bgmSource.Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);

        if (_bgmSource != null) _bgmSource.Pause();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);

        if (_bgmSource != null) _bgmSource.UnPause();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        _lives = _startingLives;
        _pausePanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        
        SceneManager.LoadScene(0);
        UpdateUI();

        if (_bgmSource != null) _bgmSource.UnPause();
    }

    private void UpdateUI()
    {
        _livesText.text = $"x{_lives}";
        _levelText.text = $"Level {SceneManager.GetActiveScene().buildIndex + 1}";
    }
}
