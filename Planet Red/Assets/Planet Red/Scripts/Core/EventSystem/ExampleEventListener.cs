using System.Collections;
using System.Collections.Generic;
using PlanetRed.Core.EventSystem;
using PlanetRed.Core.EventSystem.Events.TestEvents;
using UnityEngine;

public class ExampleEventListener : MonoBehaviour 
{

    void OnEnable()
    {
        EventSystem.Instance.Subscribe<ExampleTestEvent>(PrintText);
    }

    void Start()
    {
        EventSystem.Instance.Raise(new ExampleTestEvent()); // Prints below text
    }

    void PrintText(ExampleTestEvent a_args)
    {
        Debug.Log(a_args.text);
    }

    void OnDisable()
    {
        EventSystem.Instance.Unsubscribe<ExampleTestEvent>(PrintText);
    }
}
