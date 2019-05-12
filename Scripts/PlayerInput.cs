﻿using UnityEngine;

// Reads and stores inputs from player
public class PlayerInput
{
    public float horizontal;
    public float vertical;
    public bool impulse;
    public bool warp;
    public bool fire;
    public bool bomb;
    public bool shield;
    public bool scanner;
    public bool pause;
    public bool readyToClear;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        ClearInput();
        ProcessInputs();
    }

    // Fixed Update is called a fixed number of times per second
    public void FixedUpdate()
    {
        readyToClear = true;
    }

    // Clears the inputs to default state
    private void ClearInput()
    {
        if(!readyToClear)
            return;
        horizontal = 0f;
        vertical = 0f;
        impulse = false;
        warp = false;
        fire = false;
        bomb = false;
        shield = false;
        scanner = false;
        pause = false;
        readyToClear = false;
    }

    // Reads the inputs and stores them
    private void ProcessInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        impulse = Input.GetButton("Impulse");
        warp = Input.GetButton("Warp");
        fire = Input.GetButton("Fire");
        bomb = Input.GetButton("Bomb");
        shield = Input.GetButton("Shield");
        scanner = Input.GetButton("Scanner");
        pause = Input.GetButton("Pause");
    }
}