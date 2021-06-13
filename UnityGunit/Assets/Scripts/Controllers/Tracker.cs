using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Controllers
{
    public static class Tracker
    {
        static List<string> equationsInputted;
        static int score; 

        public static void Init()
        {
            equationsInputted = new List<string>();
            score = 0;
        }

        public static int Score
        {
            get { return score; }
        }

        public static void addEquation(string equation)
        {
            equationsInputted.Add(equation);
        }

        public static void calculateScore()
        {
            foreach(string s in equationsInputted)
            {
                foreach(char c in s)
                {
                    if (char.IsDigit(c))
                    {
                        score += Int32.Parse(c.ToString());
                    }
                }
            }
        }

        public static void clear()
        {
            score = 0;
            equationsInputted.Clear();
        }
    }
}
