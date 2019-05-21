﻿using UnityEngine;

// Sends Start(), Update(), and FixedUpdate() calls from UnityEngine to GameController to propogate to all non-MonoBehaviour scripts
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        GameController.Initialize();
    }

    // Update is called once per frame
    public void Update()
    {
        GameController.Update();
    }

    // Fixed Update is called a fixed number of times per second, Physics updates should be done in FixedUpdate
    public void FixedUpdate()
    {
        GameController.FixedUpdate();
    }
}
