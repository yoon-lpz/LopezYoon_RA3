using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource _audioSource;

    [Header("Audios")]
    public AudioClip TakeDamage;
    public AudioClip GainLife;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }   

    public void PlayTakeDamageSound() => _audioSource.PlayOneShot(TakeDamage);
    public void PlayGainLifeSound() => _audioSource.PlayOneShot(GainLife);
}
