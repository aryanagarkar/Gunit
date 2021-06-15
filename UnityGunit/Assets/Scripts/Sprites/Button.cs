using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Utils;
using Controllers;
using NCalc;

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

        if (!text.Equals("Go") && !text.Equals("Back") && image.overrideSprite != ButtonSprites.buttonSpriteGray)
        {
            if (!text.Equals("=") && !text.Equals("+") && !text.Equals("-"))
            { 
                image.overrideSprite = ButtonSprites.buttonSpriteGray;
            }
            field.text = field.text + text;
        }
        else if (text.Equals("Back"))
        {
            String lastCharacterTyped = field.text[field.text.Length - 1].ToString();
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Button"))
            {
                int n;
                if (int.TryParse(lastCharacterTyped, out n))
                {
                    if (lastCharacterTyped.Equals(obj.transform.GetChild(0).gameObject.GetComponent<Text>().text)
                        && obj.GetComponent<Image>().overrideSprite == ButtonSprites.buttonSpriteGray)
                    {
                        obj.GetComponent<Image>().overrideSprite = null;
                        field.text = field.text.Substring(0, field.text.Length - 1);
                        break;
                    }
                }
                else
                {
                    if (lastCharacterTyped.Equals(obj.transform.GetChild(0).gameObject.GetComponent<Text>().text))
                    {
                        field.text = field.text.Substring(0, field.text.Length - 1);
                        break;
                    }
                }
            }
        }
        else if(text.Equals("Go"))
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
        int indexOfEqualSign = equation.IndexOf("=");
        string part1 = equation.Substring(0, indexOfEqualSign);
        string part2 = equation.Substring(indexOfEqualSign + 1);
        int part1Eval = 0;
        int part2Eval = 0;

        part1Eval = Convert.ToInt32(new Expression(part1).Evaluate());
        part2Eval = Convert.ToInt32(new Expression(part2).Evaluate());

        return part1Eval == part2Eval;
    }

    public void clearField()
    {
        field.text = "";
    }
}
