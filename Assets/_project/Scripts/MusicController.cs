using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private AudioSource _audioSource;

    private int _sceneIndex, _songIndex;

    [SerializeField] private AudioClip[] _levelSongs;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy() => SceneManager.sceneLoaded -= OnSceneLoaded;

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _sceneIndex = scene.buildIndex;
        _songIndex = _sceneIndex - 1;

        if (_songIndex >= 0 && _songIndex < _levelSongs.Length && _levelSongs[_songIndex] != null)
        {
            if (_audioSource.clip != _levelSongs[_songIndex])
            {
                _audioSource.clip = _levelSongs[_songIndex];
                _audioSource.Play();
            }
        }

        switch (_sceneIndex)
        {
            case 2:
                _audioSource.volume = 0.25f;
                break;
            case 3:
                _audioSource.volume = 0.25f;
                break;
            default:
                _audioSource.volume = 0.75f;
                break;
        }
    }
}