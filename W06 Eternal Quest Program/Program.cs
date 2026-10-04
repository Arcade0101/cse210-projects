using System;

/*
 * CREATIVITY AND EXCEEDING REQUIREMENTS:
 * --------------------------------------
 * 1. Implemented a Leveling and Title System based on total score.
 *    - Every 1,000 points earned unlocks a new level and RPG title 
 *      (e.g., Novice Wanderer, Apprentice Seeker, Pathfinder, Goal Crusher).
 * 2. Level-Up Celebrations:
 *    - Detects level threshold crossings and triggers highlighted console output.
 * 3. Robust State Handling:
 *    - Guards against re-recording completed goals and empty loads.
 */

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}
