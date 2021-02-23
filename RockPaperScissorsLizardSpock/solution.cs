using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        var players = new Queue<(int, string, List<int>)>();;

        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int NUMPLAYER = int.Parse(inputs[0]);
            string SIGNPLAYER = inputs[1];
            players.Enqueue((NUMPLAYER, SIGNPLAYER, new List<int>()));
        }

        Play(players);

        var winner = players.Dequeue();

        Console.WriteLine(winner.Item1);
        Console.WriteLine(string.Join(" ", winner.Item3));
    }

    private static void Play(Queue<(int, string, List<int>)> players)
    {
        var rules = new string [] {
            "CP", //Scissors cuts Paper
            "PR", //Paper covers Rock
            "RL", //Rock crushes Lizard
            "LS", //Lizard poisons Spock
            "SC", //Spock smashes Scissors
            "CL", //Scissors decapitates Lizard
            "LP", //Lizard eats Paper
            "PS", //Paper disproves Spock
            "SR", //Spock vaporizes Rock
            "RC" //Rock crushes Scissors
        };

        var p1 = players.Dequeue();
        var p2 = players.Dequeue();

        Console.Error.WriteLine($"{p1.Item1} vs {p2.Item1}");

        if (p1.Item2 == p2.Item2)
        {
            if (p1.Item1 < p2.Item1)
            {
                Console.Error.WriteLine($"  P2 Lost {p2.Item1} = {p1.Item1} defeated {p2.Item1}");
                p1.Item3.Add(p2.Item1);
                players.Enqueue(p1);
            }
            else{
                Console.Error.WriteLine($"  P1 Lost {p1.Item1} = {p2.Item2} defeated {p1.Item2}");
                p2.Item3.Add(p1.Item1);
                players.Enqueue(p2);
            }
        }
        else if (rules.Contains($"{p2.Item2}{p1.Item2}"))
        {
            Console.Error.WriteLine($"  P1 Lost {p1.Item1} = {p2.Item2} defeated {p1.Item2}");
            p2.Item3.Add(p1.Item1);
            players.Enqueue(p2);
        }
        else if (rules.Contains($"{p1.Item2}{p2.Item2}"))
        {
            Console.Error.WriteLine($"  P2 Lost {p2.Item1} = {p1.Item2} defeated {p2.Item2}");
            p1.Item3.Add(p2.Item1);
            players.Enqueue(p1);
        }

        if (players.Count == 1)
        {
            return;
        }
 
        Play(players);
    }

}
