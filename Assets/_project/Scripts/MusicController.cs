using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private int _sceneIndex;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip[] _levelSongs;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _sceneIndex = scene.buildIndex;

        if (_sceneIndex < _levelSongs.Length && _levelSongs[_sceneIndex] != null)
        {
            if (_audioSource.clip != _levelSongs[_sceneIndex])
            {
                _audioSource.clip = _levelSongs[_sceneIndex];
                _audioSource.Play();
            }
        }
    }
}
