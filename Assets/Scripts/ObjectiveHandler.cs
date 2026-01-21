using TMPro;
using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{    
    bool hasCrate = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (hasCrate)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.CompareTag("Crate"))
                {
                    child.gameObject.SetActive(true);
                }
            }
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
