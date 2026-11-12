using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    private int _lives, _sceneIndex;
    private bool _isGameOver;
    readonly int _startingLives = 3;

    [Header("UI Elements")]
    [SerializeField] private Image _characterImage;
    [SerializeField] private Sprite[] _characterSprites;
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

    private void OnDestroy() => SceneManager.sceneLoaded -= OnSceneLoaded;

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
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;

        _livesText.text = $"x{_lives}";
        _levelText.text = $"Level {_sceneIndex + 1}";

        if (_characterImage != null && _sceneIndex < _characterSprites.Length && _characterSprites[_sceneIndex] != null)
            _characterImage.sprite = _characterSprites[_sceneIndex];
    }
}
