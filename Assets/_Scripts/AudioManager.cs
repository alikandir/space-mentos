using UnityEngine;
using UnityEngine.Pool;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSourcePrefab; // Prefab for AudioSource
    [SerializeField] private bool collectionChecks = true; // Enable safety checks for the pool
    [SerializeField] private int defaultPoolSize = 10; // Initial pool size

    private ObjectPool<AudioSource> audioSourcePool;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize the AudioSource pool
        audioSourcePool = new ObjectPool<AudioSource>(
            CreatePooledItem,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPooledItem,
            collectionChecks,
            defaultPoolSize
        );
    }

    private AudioSource CreatePooledItem()
    {
        AudioSource audioSource = Instantiate(audioSourcePrefab, transform);
        audioSource.gameObject.SetActive(false);
        return audioSource;
    }

    private void OnTakeFromPool(AudioSource audioSource)
    {
        audioSource.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(AudioSource audioSource)
    {
        audioSource.Stop();
        audioSource.clip = null;
        audioSource.gameObject.SetActive(false);
    }

    private void OnDestroyPooledItem(AudioSource audioSource)
    {
        Destroy(audioSource.gameObject);
    }

    public void PlaySound(AudioClip clip, Vector3 position, float volume = 1f, float pitch = 1f)
    {
        if (clip == null) return;
    
        // Get an AudioSource from the pool
        AudioSource audioSource = audioSourcePool.Get();
        audioSource.transform.position = position;
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        

        audioSource.Play();

        // Return the AudioSource to the pool after the clip finishes
        StartCoroutine(ReturnToPoolAfterPlayback(audioSource, clip.length));
    }

    private System.Collections.IEnumerator ReturnToPoolAfterPlayback(AudioSource audioSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSourcePool.Release(audioSource);
    }
}
