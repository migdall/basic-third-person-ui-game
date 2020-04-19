using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanelController : MonoBehaviour
{
    // This script will control setting the current question
    // for the question panel

    public GameObject m_QuestionText;
    public GameObject m_FirstAnswerButtonText;
    public GameObject m_SecondAnswerButtonText;
    public GameObject m_ThirdAnswerButtonText;
    public GameObject m_FourthAnswerButtonText;

    private Question m_CurrentQuestion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_QuestionText != null && GameManager.instance != null && GameManager.instance.IsNewQuestion())
        {
            m_CurrentQuestion = GameManager.instance.GetCurrentQuestion();
            m_QuestionText.GetComponent<Text>().text = m_CurrentQuestion.questionString;

            m_FirstAnswerButtonText.GetComponent<Text>().text = m_CurrentQuestion.answers[0];
            m_SecondAnswerButtonText.GetComponent<Text>().text = m_CurrentQuestion.answers[1];
            m_ThirdAnswerButtonText.GetComponent<Text>().text = m_CurrentQuestion.answers[2];
            m_FourthAnswerButtonText.GetComponent<Text>().text = m_CurrentQuestion.answers[3];
        }
    }
}
