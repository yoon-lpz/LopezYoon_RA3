using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource _audioSource;

    [Header("Audios")]
    public AudioClip TakeDamage;
    public AudioClip GainLife;
    public AudioClip Door;
    public AudioClip OpenChest;

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
    public void PlayOpenChestSound() => _audioSource.PlayOneShot(OpenChest);
    public void PlayDoorSound() => _audioSource.PlayOneShot(Door);
}