using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Utils;
using Controllers;

public class Button : MonoBehaviour
{
    InputField field;
    Timer timer;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        field = GameObject.FindWithTag("EquationField").GetComponent<InputField>();
    }

    public void HandleButtonClicked()
    {
        String text = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
        Image image = gameObject.GetComponent<Image>();

        if (!text.Equals("Go") && image.sprite != ButtonSprites.buttonSpriteGray)
        {
            if (!text.Equals("=") && !text.Equals("+") && !text.Equals("-"))
            { 
                image.overrideSprite = ButtonSprites.buttonSpriteGray;
            }
            field.text = field.text + text;
        }
        else
        {
            bool correct = validate(field.text);
            if(correct)
            {
                Tracker.addEquation(field.text);
                field.text = "";
            }
            else
            {
                foreach(char c in field.text)
                {
                    if (Char.IsDigit(c))
                    {
                        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Button"))
                        {
                            if(obj.transform.GetChild(0).gameObject.GetComponent<Text>().text.Equals(c.ToString()))
                            {
                                obj.GetComponent<Image>().overrideSprite = null;
                            }
                        }
                    }
                }
                field.text = "Try again";
                timer.Run(1f);
            }
        }
    }

    bool validate(string equation)
    {
        int indexOfEqualSign = findEqualSignIndex(equation);
        string part1 = equation.Substring(0, indexOfEqualSign);
        string part2 = equation.Substring(indexOfEqualSign + 1);
        int part1Eval = 0;
        int part2Eval = 0;

        part1Eval = evaluate(part1);
        part2Eval = evaluate(part2);

        return part1Eval == part2Eval;
    }

    int findEqualSignIndex(string equation)
    {
        for(int i = 0; i < equation.Length; i++)
        {
            if (equation[i].Equals('='))
            {
                return i;
            }
        }
        return -1;
    }

    int evaluate(string part)
    {
        int currNumber = 0;
        string currOperator = "";

        for (int i = 0; i < part.Length; i++)
        {
            if (!Char.IsDigit(part[i]))
            {
                currOperator = part[i].ToString();
            }
            else if (Char.IsDigit(part[i]) && currOperator.Equals(""))
            {
                currNumber = Int32.Parse(part[i].ToString());
            }
            else if (Char.IsDigit(part[i]))
            {
                switch (currOperator)
                {
                    case "+":
                        currNumber = currNumber + Int32.Parse(part[i].ToString());
                        break;
                    case "-":
                        currNumber = currNumber - Int32.Parse(part[i].ToString());
                        break;
                    case "*":
                        currNumber = currNumber * Int32.Parse(part[i].ToString());
                        break;
                    case "/":
                        currNumber = currNumber / Int32.Parse(part[i].ToString());
                        break;
                }
            }
        }

        return currNumber;
    }

    public void clearField()
    {
        field.text = "";
    }
}
