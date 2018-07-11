using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game State
    int level;

    enum Screen {
        MainMenu,
        LevelOne,
        LevelTwo,
        LevelThree,
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
        else if (currentScreen == Screen.LevelOne) {
            if (input == "password") {
                Terminal.WriteLine("Congratulations, you have entered the mainframe.");
                currentScreen = Screen.Win;
            }
            else {
                Terminal.WriteLine("Incorrect, please try again.");
            }
        }
        else if (currentScreen == Screen.LevelTwo) {
            if (input == "lightbulb") {
                Terminal.WriteLine("Congratulations, you have entered the mainframe.");
                currentScreen = Screen.Win;
            }
            else {
                Terminal.WriteLine("Incorrect, please try again.");
            }
        }
        else if (currentScreen == Screen.LevelThree) {
            if (input == "philosophical") {
                Terminal.WriteLine("Congratulations, you have entered the   mainframe.");
                currentScreen = Screen.Win;
            }
            else {
                Terminal.WriteLine("Incorrect, please try again.");
            }
        }
    }


    void RunMainMenu(string input) {
        if (input == "1") {
            StartGame(1);
        }
        else if (input == "2") {
            StartGame(2);
        }
        else if (input == "3") {
            StartGame(3);
        }
        else {
            Terminal.WriteLine("Not a valid option. Please choose again:");
        }
    }


    void StartGame(int level) {
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter the password: ");
        if (level == 1)
            currentScreen = Screen.LevelOne;
        else if (level == 2)
            currentScreen = Screen.LevelTwo;
        else if (level == 3)
            currentScreen = Screen.LevelThree;
        

    }
}
