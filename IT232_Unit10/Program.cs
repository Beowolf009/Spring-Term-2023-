using System.Collections.Generic;
using System;
using static System.Formats.Asn1.AsnWriter;

public class Program
{
    public static void Main()
    {
        ScoreKeeperTest.RunScoreKeeperTest();
        BaseballTest.RunBaseballTest();
    }
}

/************************************************************************************************************************************************
 Assignment 10 Section 1
 ***************************************************************************************************************************************************/
// Constructor to initialize gamePlayed and players fields
public class ScoreKeeper
{
    private string gamePlayed;
    private Dictionary<string, int> players;

    public ScoreKeeper(string gamePlayed)
    {
        this.gamePlayed = gamePlayed;
        players = new Dictionary<string, int>();
    }
    // Adds a player to the players dictionary with a score of 0
    public void AddPlayer(string playerName)
    {
        players.Add(playerName, 0);
    }
    // Adds a score to a player's current score in the players dictionary
    // If the player is not in the dictionary, they are added with the score
    public void AddScore(string playerName, int score)
    {
        if (players.ContainsKey(playerName))
        {
            players[playerName] += score;
        }
        else
        {
            players.Add(playerName, score);
        }
    }
   // Adds a score to one player and subtracts the same score from another player's current score
  // If either player is not in the dictionary, the operation is not performed
    public void AddScore(string playerName, int score, string otherPlayerName)
    {
        if (players.ContainsKey(playerName) && players.ContainsKey(otherPlayerName))
        {
            players[otherPlayerName] += score;
        }
    }
    // Adds a player to the players dictionary with a score of 0, if they are not already in the dictionary
    public void AddName(string name)
    {
        if (!players.ContainsKey(name))
        {
            players.Add(name, 0);
        }
    }
    // Returns the score of the given player
    // If the player is not in the dictionary, 0 is returned
    public int GetScore(string playerName)
    {
        if (players.ContainsKey(playerName))
        {
            return players[playerName];
        }
        else
        {
            return 0;
        }
    }
    // Returns the name of the game being played
    public string GetGamePlayed()
    {
        return gamePlayed;
    }

    public Dictionary<string, int> GetPlayers()
    {
        return players;
    }
    // Subtracts a score from a player's current score in the players dictionary
    // If the player is not in the dictionary, the operation is not performed
    // If the result is negative, the score is set to 0
    public int SubScore(string playerName, int score)
    {
        if (players.ContainsKey(playerName))
        {
            int currentScore = players[playerName];
            int newScore = currentScore - score;

            if (newScore < 0)
            {
                players[playerName] = 0;
            }
            else
            {
                players[playerName] = newScore;
            }

            return players[playerName];
        }
        else
        {
            return 0;
        }
    }
    // Prints all player scores in the players dictionary for the game being played
    public void ListAllScores()
    {
        Console.WriteLine("Player Scores for " + gamePlayed + ":");
        Console.WriteLine("------------------------");
        foreach (KeyValuePair<string, int> player in players)
        {
            Console.WriteLine(player.Key + ": " + player.Value);
        }
    }
}
/*******************************************************************************************************************************************
 Assignment 10 Section 2
 *******************************************************************************************************************************************/
public class Baseball : ScoreKeeper
{
    // The number of fouls, balls, strikes, and outs in the game
    private int fouls;
    private int balls;
    private int strikes;
    private int outs;
   
    private float inning;
    public string homeTeam;
    public string awayTeam;

    //the constructor that sets the game up to start
    public Baseball() : base("Baseball")
    {
        fouls = 0;
        balls = 0;
        strikes = 0;
        outs = 0;
        inning = 1.0f;
        homeTeam = "";
        awayTeam = "";
    }
    // Constructor that sets the default values for a new baseball game, and sets the home and away team names
    public Baseball(string homeTeam, string awayTeam) : base("Baseball")
    {
        fouls = 0;
        balls = 0;
        strikes = 0;
        outs = 0;
        inning = 1.0f;
        this.homeTeam = homeTeam;
        this.awayTeam = awayTeam;
    }
    // Advances the number of outs in the game, and resets the balls, strikes, and fouls to 0 if there are 3 outs
    public void AdvOuts()
    {
        outs++;
        if (outs >= 3)
        {
            inning += 0.5f;
            outs = 0;
            balls = 0;
            strikes = 0;
            fouls = 0;
        }
    }
    // Returns the current number of outs in the game
    public int GetOuts()
    {
        return outs;
    }
    // Advances the number of strikes in the game, and calls AdvOuts() if there are 3 strikes
    public void AdvStrikes()
    {
        strikes++;
        if (strikes >= 3)
        {
            AdvOuts();
        }
    }
    // Returns the current number of strikes in the game
    public int GetStrikes()
    {
        return strikes;
    }
    // Advances the number of fouls in the game, and calls AdvStrikes() if there are 4 fouls
    public void AdvFouls()
    {
        fouls++;
        if (fouls >= 4)
        {
            AdvStrikes();
        }
    }
    // Returns the current number of fouls in the game
    public int GetFouls()
    {
        return fouls;
    }
    // Advances the number of balls in the game, and calls AdvOuts() if there are 4 balls
    public void AdvBalls()
    {
        balls++;
        if (balls >= 4)
        {
            AdvOuts();
        }
    }
    // Returns the current number of balls in the game
    public int GetBalls()
    {
        return balls;
    }
    // Returns the current inning of the game
    public float GetInning()
    {
        return inning;
    }
}

/****************************************************************************************************************************
 Assignment 10 Section 3
 *******************************************************************************************************************************/

public class ScoreKeeperTest
{
    public static void RunScoreKeeperTest()
    {
        // Print the title of the section being tested
        Console.WriteLine("Assignment 10 - Classes and Inheritance\n");

        // Print the title of the subsection being tested
        Console.WriteLine("Section 3: Base Class Results After Adding\n");

        // Create a new ScoreKeeper object for the game Canasta and add some player names
        var gameOne = new ScoreKeeper("Canasta");
        gameOne.AddName("Larry");
        gameOne.AddName("Moe");
        gameOne.AddName("Curly");

        // Print a blank line to separate the section header from the output
        Console.WriteLine();

        // Add some scores for the players Larry, Moe, and Curly
        gameOne.AddScore("Larry", 20);
        gameOne.AddScore("Moe", 35, "Curly"); // Moe scores and assigns some points to Curly
        gameOne.AddScore("Curly", 45);

        // List all the scores for the players in the game
        gameOne.ListAllScores();

        // Print a blank line to separate the previous output from the next one
        Console.WriteLine();

        // Subtract some scores from Moe and Curly
        gameOne.SubScore("Moe", 15);
        gameOne.SubScore("Curly", 5);

        // Print the title of the subsection being tested
        Console.WriteLine("Section 3: Base Class Results After Subtracting\n");

        // List all the scores again to see the changes
        gameOne.ListAllScores();

        // Print two blank lines to separate the output from the next section header
        Console.WriteLine();
        Console.WriteLine();
    }
}

/**************************************************************************************************************************************
 Assignment 10 Section 4
 *************************************************************************************************************************************/
public class BaseballTest
{
    public static void RunBaseballTest()
    {
        // Print out the section title for this test
        Console.WriteLine("Section 4: Derived Class Results: Baseball scoring\n");

        // Create a new instance of the Baseball class with home team "Cubs" and away team "Braves"
        var gameTwo = new Baseball("Cubs", "Braves");

        // Add 2 points to the "Cubs" team
        gameTwo.AddScore("Cubs", 2);

        // Advance outs by 3, which should move to the next inning
        gameTwo.AdvOuts();
        gameTwo.AdvOuts();
        gameTwo.AdvOuts();

        // Add 3 points to the "Braves" team
        gameTwo.AddScore("Braves", 3);

        // Advance outs by 1
        gameTwo.AdvOuts();

        // Advance strikes by 1
        gameTwo.AdvStrikes();

        // Advance fouls by 3, which should move to the next strike
        gameTwo.AdvFouls();
        gameTwo.AdvFouls();
        gameTwo.AdvFouls();

        // Advance balls by 1, which should move to the next out
        gameTwo.AdvBalls();

        // Print out the scores for both teams
        gameTwo.ListAllScores();
        Console.WriteLine();

        // Print out the current inning, outs, strikes, fouls, and balls
        Console.WriteLine("Current Inning: " + gameTwo.GetInning());
        Console.WriteLine("Current Outs: " + gameTwo.GetOuts());
        Console.WriteLine("Current Strikes: " + gameTwo.GetStrikes());
        Console.WriteLine("Current Fouls: " + gameTwo.GetFouls());
        Console.WriteLine("Current Balls: " + gameTwo.GetBalls());
    }
}

