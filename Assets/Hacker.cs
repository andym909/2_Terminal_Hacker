using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game State
    int level;

    enum Screen {
        MainMenu,
        Password,
        Win
    }

    Screen currentScreen = Screen.MainMenu;

    // Use this for initialization
    void Start () {
        ShowMainMenu();
	}
	
    void ShowMainMenu () {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the MainFrame, Hacker!");
        Terminal.WriteLine("Whose internet history do you want to  spy on today?");
        Terminal.WriteLine("1. Grandpa");
        Terminal.WriteLine("2. Dad");
        Terminal.WriteLine("3. Little Brother");
        Terminal.WriteLine("");
        Terminal.WriteLine("Please enter an option by number: ");
    }

    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }


    }

    void RunMainMenu(string input) {
        if (input == "1") {
            level = 1;
            StartGame();
        }
        else if (input == "2") {
            level = 2;
            StartGame();
        }
        else if (input == "3") {
            print("You chose 3");
        }
        else {
            print("Not a valid option. Please choose again:");
        }
    }

    void StartGame() {
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
        currentScreen = Screen.Password;
    }
}
