using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    // This script will manage the questions

    public Dictionary<int, Question> questions;

    public QuestionManager()
    {
        questions = new Dictionary<int, Question>();

        questions.Add(1, new Question(
                1,
                "Name of Eve's husband",
                2,
                "Seth",
                "Joshua",
                "Adam",
                "Paul"
            )
        );
    }

    public Question Get()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, questions.Count);
        return questions[randomNumber];
    }
}
