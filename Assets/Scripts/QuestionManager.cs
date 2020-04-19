using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    // This script will manage the questions

    public Dictionary<int, Question> questions;
    public Dictionary<int, Question> m_FirstBaseQuestions;
    public Dictionary<int, Question> m_SecondBaseQuestions;
    public Dictionary<int, Question> m_ThirdBaseQuestions;
    public Dictionary<int, Question> m_HomeBaseQuestions;

    public QuestionManager()
    {
        m_FirstBaseQuestions = new Dictionary<int, Question>();
        m_SecondBaseQuestions = new Dictionary<int, Question>();
        m_ThirdBaseQuestions = new Dictionary<int, Question>();
        m_HomeBaseQuestions = new Dictionary<int, Question>();

        Question q1 = new Question(1, "What is the name of the first book of the Bible", 1, "Genesis", "Isaiah", "Beginning", "Matthew");
        m_FirstBaseQuestions.Add(1, q1);

        m_SecondBaseQuestions.Add(1, new Question(
                1,
                "Who baptized Jesus Christ",
                3,
                "Moses",
                "Rebekah",
                "Peter",
                "John the Baptist"
            )
        );

        m_ThirdBaseQuestions.Add(1, new Question(
                1,
                "What was the occupation of Matthew before following Jesus",
                1,
                "Carpenter",
                "Tax Collector",
                "Fisherman",
                "Shepherd"
            )
        );

        m_HomeBaseQuestions.Add(1, new Question(
                1,
                "What is the plural name for God found in Genesis",
                2,
                "Yahweh",
                "Jesus",
                "Elohim",
                "Jehovah"
            )
        );
    }

    public Question Get(int baseNumber)
    {
        int randomNumber;
        System.Random random = new System.Random();

        if (baseNumber == 2)
        {
            randomNumber = random.Next(1, m_SecondBaseQuestions.Count);
            return m_SecondBaseQuestions[randomNumber];
        }
        else if (baseNumber == 3)
        {
            randomNumber = random.Next(1, m_ThirdBaseQuestions.Count);
            return m_ThirdBaseQuestions[randomNumber];
        }
        else if (baseNumber == 4)
        {
            randomNumber = random.Next(1, m_HomeBaseQuestions.Count);
            return m_HomeBaseQuestions[randomNumber];
        }

        randomNumber = random.Next(1, m_FirstBaseQuestions.Count);
        return m_FirstBaseQuestions[randomNumber];
    }
}
