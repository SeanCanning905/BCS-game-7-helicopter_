using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{    
    public bool hasCrate = false;

    void Start()
    {

    }

    void Update()
    {
        CrateHandler();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crate"))
        { 
            hasCrate = true;
            Destroy(other.gameObject);
        }
    }

    void CrateHandler()
    {
        if (hasCrate)
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
