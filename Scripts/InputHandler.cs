﻿using UnityEngine;

// Controls UI menu input
public class InputHandler : MonoBehaviour
{
    // Main menu input
    public void MainMenuInput(string _input)
    {
        if(_input == "ContinueGame")
        {
            // TODO: Loads most recent save file
        }
        else if(_input == "NewGame")
        {
            // TODO: Start a new game
            GameController.CurrentGameState = GameController.GameState.Playing;
            UIController.ShowUI();
        }
        else if(_input == "LoadGame")
        {
            // TODO: Add a load game menu
        }
        else if(_input == "Settings")
        {
            // TODO: Add a settings screen, rebind keys, change graphics, etc
        }
        else if(_input == "Quit")
        {
            Application.Quit();
        }
        else if(_input == "Restart")
        {
            GameController.Restart();
        }
    }
}