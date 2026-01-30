using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Control Speed")]
    [SerializeField] float thrustForce = 100f;
    [SerializeField] float tiltForce = 100f;
    [SerializeField] float yawForce = 100f;
    [SerializeField] float rotationForce = 100f;
    //[SerializeField] AudioClip thrustSound;

    [Header("Crate Mechanics")]
    [SerializeField] GameObject containerPrefab;
    [SerializeField] Transform dropPosition;

    [Header("Particle System")]
    //[SerializeField] ParticleSystem mainThruster;

    Rigidbody rb;
    AudioSource audioSource;

    ObjectiveHandler objectiveHandler;

    //Vector3 dropPosition = new Vector3 (0, -9, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = FindFirstObjectByType<AudioSource>();
        objectiveHandler = GetComponent<ObjectiveHandler>();
        //dropPosition = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessTilt();
        ProcessYaw();
        ProcessRotation();
        DropCrate();
        dropPosition = GetComponentInChildren<Transform>();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(thrustForce * Time.deltaTime * Vector3.up);
            //Debug.Log("Thrust");
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            //if (!mainThruster.isPlaying)
            //{
                //mainThruster.Play();
            //}
        }
        else
        {
            audioSource.Stop();
            //mainThruster.Stop();
        }
    }
    
    void ProcessTilt()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            ApplyTilt(tiltForce);
            //Debug.Log("Spin Left");
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            ApplyTilt(-tiltForce);
            //Debug.Log("Spin Right");
        }
    }

    void ApplyTilt(float tiltThisFrame)
    {
        rb.freezeRotation = true; // freeze rotation 
        transform.Rotate(tiltThisFrame * Time.deltaTime * Vector3.right);
        rb.freezeRotation = false; // unfreeze
    }

    void ProcessYaw()
    {
        if (Input.GetKey(KeyCode.A)  || Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("Yaw Left");
            ApplyYaw(yawForce);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("Yaw Right");
            ApplyYaw(-yawForce);
        }
    }

    void ApplyYaw(float yawThisFrame)
    {
        transform.Rotate(yawThisFrame * Time.deltaTime * Vector3.forward);
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            //Debug.Log("Rotating");
            ApplyRotation(rotationForce);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log("Rotating");
            ApplyRotation(-rotationForce);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(rotationThisFrame * Time.deltaTime * Vector3.up);
    }

    void DropCrate()
    {
        if (Input.GetKey(KeyCode.F) && objectiveHandler.hasCrate == true)
        {

            Debug.Log("Presed F");
            objectiveHandler.hasCrate = false;
            Invoke(nameof(CrateSpawnControl), 0f);
        }
    }

    void CrateSpawnControl()
    {
        Instantiate(containerPrefab, dropPosition, true);
    }

    void UpdateDropPosition()
    {
        //dropPosition.transform.position = new Transform.local.position;
    }
}

// hardcoded vector 3 to save position of children 
// take instantiate of out update method
// check for the input every frame only instatiate when needed!!!!

// simplfy 