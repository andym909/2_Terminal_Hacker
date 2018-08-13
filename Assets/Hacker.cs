using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game configuration data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "password", "abc123", "grandpa", "open", "login" };
    string[] level2Passwords = { "mortgage", "unionize", "parental", "bourbon", "corvette" };
    string[] level3Passwords = { "jakepaul", "fidgetspinner", "pansexual", "tidepods", "nintendo" };

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

        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" );
        if (isValidLevelNumber) {
            level = int.Parse(input);
            AskForPassword();
        }
        else {
            Terminal.WriteLine("Not valid. Please choose again:");
        }
    }


    void AskForPassword() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, here's a hint: ");
        Terminal.WriteLine(password.Anagram());


    }

    void SetRandomPassword() {
        switch (level) {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("INVALID LEVEL.  HACKED TOO HARD");
                break;
        }
    }

    void checkPassword(string userGuess) {
        if (userGuess == password) {
            DisplayWinScreen();
        }
        else {
            AskForPassword();
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        ShowLevelReward();
    }

    void ShowLevelReward() {
        switch(level) {
            case 1:
                Terminal.WriteLine("You kids and your damn technology....");
                Terminal.WriteLine(@"  
  __ _ __ __   __ _ 
 / _` || '_ \ / _` |
| (_| || |_) | (_| |
 \__, || .__/ \__,_|
  __/ || |          
 |___/ |_| 
"
                );
                break;
            case 2:
                Terminal.WriteLine("I should ground you....");
                Terminal.WriteLine(@"
     _           _ 
    | |         | |
  __| | __ _  __| |
 / _` |/ _` |/ _` |
| (_| | (_| | (_| |
 \__,_|\__,_|\__,_|
"
                );
                break;
            case 3:
                Terminal.WriteLine(@"
          __
      o__/- \                LET'S
       \\/__ \ __            DO
     __   //\\   \\    /     THE
  o_/o \\-//--\\  \\ _/      DOGGY
  ~\/___  ____=o  |          STYLE!
     _/_/    \\/_/
             /\\
     ----------------"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;

        }
        
    }
}
