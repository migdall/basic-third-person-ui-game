using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Question : MonoBehaviour
{
    public int baseNumber;
    public string questionString;
    public int answerIndex;
    public String[] answers;

    public Question(int p_BaseNumber, string p_Question, int p_AnswerIndex, string answerOne, string answerTwo, string answerThree, string answerFour)
    {
        baseNumber = p_BaseNumber;
        questionString = p_Question;
        answerIndex = p_AnswerIndex;

        answers = new String[4] {
            answerOne,
            answerTwo,
            answerThree,
            answerFour
        };
    }
}
