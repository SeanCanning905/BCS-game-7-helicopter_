using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;

    AudioSource audioSource;

    void Start()
    {
        audioSource = FindAnyObjectByType<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Start":
                Debug.Log("Collided with start");
                    break;
            case "Finish":
                StartSuccessSequence();
                Debug.Log("Collided with finish");
                break;
            case "Enemy":
                StartCrashSequence();
                Debug.Log("Collided with enemy");
                    break;
            default:
                Debug.Log("Collided With Other");
                StartCrashSequence();
                break;
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartSuccessSequence()
    {
        //TODO: Add particle effects
        audioSource.PlayOneShot(successSFX);
        Invoke(nameof(LoadNextLevel), loadDelay);
    }

    void StartCrashSequence()
    {
        //TODO: Add particle effects
        audioSource.PlayOneShot(crashSFX);
        GetComponent<PlayerController>().enabled = false;
        Invoke(nameof(ReloadScene), loadDelay);
    }
}
