using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                DisplayPlayerInfo();
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoalDetails();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            int level = (_score / 1000) + 1;
            string title = GetLevelTitle(level);

            Console.WriteLine("==================================================");
            Console.WriteLine($"  Player Rank: Level {level} [{title}]");
            Console.WriteLine($"  Total Score: {_score} points");
            Console.WriteLine("==================================================");
        }

        private string GetLevelTitle(int level)
        {
            return level switch
            {
                1 => "Novice Wanderer",
                2 => "Apprentice Seeker",
                3 => "Pathfinder",
                4 => "Goal Crusher",
                5 => "Master Accomplisher",
                _ => "Legendary Champion"
            };
        }

        public void ListGoalNames()
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
            }
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("The goals are:");
            if (_goals.Count == 0)
            {
                Console.WriteLine("  (No goals created yet)");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");

            string typeChoice = Console.ReadLine() ?? "";

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine() ?? "";

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine() ?? "";

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.TryParse(Console.ReadLine(), out int p) ? p : 0;

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.TryParse(Console.ReadLine(), out int t) ? t : 1;
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.TryParse(Console.ReadLine(), out int b) ? b : 0;
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You have no goals to record!");
                return;
            }

            Console.WriteLine("The goals are:");
            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            int index = choice - 1;

            if (index >= 0 && index < _goals.Count)
            {
                Goal selectedGoal = _goals[index];

                if (selectedGoal.IsComplete())
                {
                    Console.WriteLine("This goal is already completed!");
                    return;
                }

                int pointsEarned = selectedGoal.RecordEvent();
                int oldLevel = (_score / 1000) + 1;
                _score += pointsEarned;
                int newLevel = (_score / 1000) + 1;

                Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");

                if (newLevel > oldLevel)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"*** LEVEL UP! You reached Level {newLevel}: {GetLevelTitle(newLevel)}! ***");
                    Console.ResetColor();
                }

                Console.WriteLine($"You now have {_score} points.\n");
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        public void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine() ?? "goals.txt";

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }

        public void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine() ?? "goals.txt";

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length > 0)
            {
                _score = int.TryParse(lines[0], out int scoreVal) ? scoreVal : 0;

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(":");
                    if (parts.Length < 2) continue;

                    string type = parts[0];
                    string[] details = parts[1].Split(",");

                    if (type == "SimpleGoal" && details.Length >= 4)
                    {
                        string name = details[0];
                        string description = details[1];
                        int points = int.Parse(details[2]);
                        bool isComplete = bool.Parse(details[3]);
                        _goals.Add(new SimpleGoal(name, description, points, isComplete));
                    }
                    else if (type == "EternalGoal" && details.Length >= 3)
                    {
                        string name = details[0];
                        string description = details[1];
                        int points = int.Parse(details[2]);
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (type == "ChecklistGoal" && details.Length >= 6)
                    {
                        string name = details[0];
                        string description = details[1];
                        int points = int.Parse(details[2]);
                        int bonus = int.Parse(details[3]);
                        int target = int.Parse(details[4]);
                        int amountCompleted = int.Parse(details[5]);
                        _goals.Add(new ChecklistGoal(name, description, points, bonus, target, amountCompleted));
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
    }
}
