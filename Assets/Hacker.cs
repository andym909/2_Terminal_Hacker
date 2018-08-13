using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game configuration data
    string[] level1Passwords = { };

    // Game State
    int level;
    enum Screen {MainMenu, Password, Win}
    string password;

    Screen currentScreen;

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
        else if (currentScreen == Screen.Password) {
            checkPassword(input);
        }
    }


    void RunMainMenu(string input) {
        if (input == "1") {
            level = 1;
            Terminal.WriteLine("You have chosen level " + level);
            password = "password";
            StartGame();
        }
        else if (input == "2") {
            level = 2;
            Terminal.WriteLine("You have chosen level " + level);
            password = "lightbulb";
            StartGame();
        }
        else if (input == "3") {
            level = 3;
            Terminal.WriteLine("You have chosen level " + level);
            password = "philosophical";
            StartGame();
        }
        else {
            Terminal.WriteLine("Not valid. Please choose again:");
        }
    }


    void StartGame() {
        Terminal.WriteLine("Please enter the password: ");
        currentScreen = Screen.Password;

    }

    void checkPassword(string userGuess) {
        if (userGuess == password) {
            Terminal.WriteLine("Congratulations, you've entered the mainframe.");
            currentScreen = Screen.Win;
        }
        else {
            Terminal.WriteLine("Incorrect password.  Try again.");
        }
    }
}
