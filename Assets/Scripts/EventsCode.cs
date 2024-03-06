using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsCode : MonoBehaviour
{

    public bool Range;
    public KeyCode interactKey;
    public UnityEvent InteractAction;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Range)
        {
            if (Input.GetKeyDown(interactKey))
            {
                InteractAction.Invoke();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Range = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Range = false;
        }
    }
}
