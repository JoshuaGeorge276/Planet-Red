using System.Collections;
using System.Collections.Generic;
using PlanetRed.Core;
using UnityEngine;

public class InputManager : SingletonBehaviour<InputManager>
{
    [SerializeField]
    private InputPlayer[] players;

    private float _deltaTime;

    private void Awake()
    {
        for (int i = 0; i < players.Length; ++i)
        {
            players[i].ID = i;
        }
    }

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _deltaTime = Time.deltaTime;
	    for (int i = 0; i < players.Length; ++i)
	    {
            players[i].Update(_deltaTime);
	    }
	}

    void LateUpdate()
    {
        for (int i = 0; i < players.Length; ++i)
        {
            players[i].LateUpdate(_deltaTime);
        }
    }
}
