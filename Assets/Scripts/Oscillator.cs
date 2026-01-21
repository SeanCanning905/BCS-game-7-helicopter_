using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float distance = 10f;
    [SerializeField] Vector3 movementAxis = Vector3.up;

    Vector3 startingPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startingPosition + movementAxis.normalized * newPos;
    }
}
