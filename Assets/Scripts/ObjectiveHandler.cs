using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{    
    public bool hasCrate = false;
    Container container;

    void Start()
    {
        GetComponentInChildren<Container>();
    }

    void Update()
    {
        if(hasCrate)
        {
            gameObject.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crate"))
        { 
            hasCrate = true;
            other.gameObject.SetActive(false); 
        }
    }
}
