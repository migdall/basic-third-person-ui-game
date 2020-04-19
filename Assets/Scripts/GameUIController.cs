using UnityEngine;

public class GameUIController : MonoBehaviour
{
    // This script will control the panels and game ui for the questions

    public GameObject m_WelcomePanel;
    public GameObject m_TeamsSetupPanel;
    public GameObject m_BattingPanel;
    public GameObject m_InningPanel;
    public GameObject m_QuestionPanel;
    public GameObject m_BaseQuestionPanel;

    public Camera m_TopCamera;

    public GameObject m_Player;

    private bool m_MovePlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_MovePlayer = false;

        m_WelcomePanel.SetActive(true);
        m_TeamsSetupPanel.SetActive(false);
        m_BattingPanel.SetActive(false);
        m_InningPanel.SetActive(false);
        m_QuestionPanel.SetActive(false);
        m_BaseQuestionPanel.SetActive(false);

        m_TopCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_MovePlayer)
        {
            if (m_Player.transform.position.x <= 30.4 && m_Player.transform.position.z <= 29.52) {
                m_Player.transform.Translate(Time.deltaTime, 0f, Time.deltaTime);
            }
            else
            {
                m_MovePlayer = false;
            }
        }
        else
        {
            m_Player.transform.position = new Vector3(0f, 0.5f, 0f);
        }
    }

    public void ShowTeamsSetupPanel()
    {
        m_QuestionPanel.SetActive(false);
        m_BaseQuestionPanel.SetActive(false);
        m_InningPanel.SetActive(false);
        m_BattingPanel.SetActive(false);
        m_WelcomePanel.SetActive(false);
        m_TeamsSetupPanel.SetActive(true);
    }

    public void ShowBattingPanel()
    {
        m_QuestionPanel.SetActive(false);
        m_BaseQuestionPanel.SetActive(false);
        m_InningPanel.SetActive(false);
        m_WelcomePanel.SetActive(false);
        m_TeamsSetupPanel.SetActive(false);
        m_BattingPanel.SetActive(true);
    }

    public void ShowInningPanel()
    {
        m_QuestionPanel.SetActive(false);
        m_BaseQuestionPanel.SetActive(false);
        m_BattingPanel.SetActive(false);
        m_TeamsSetupPanel.SetActive(false);
        m_WelcomePanel.SetActive(false);
        m_InningPanel.SetActive(true);
    }

    public void ShowBaseQuestionPanel()
    {
        m_BattingPanel.SetActive(false);
        m_TeamsSetupPanel.SetActive(false);
        m_WelcomePanel.SetActive(false);
        m_InningPanel.SetActive(false);
        m_QuestionPanel.SetActive(false);
        m_BaseQuestionPanel.SetActive(true);
    }

    public void ShowQuestionPanel()
    {
        m_BattingPanel.SetActive(false);
        m_TeamsSetupPanel.SetActive(false);
        m_WelcomePanel.SetActive(false);
        m_InningPanel.SetActive(false);
        m_BaseQuestionPanel.SetActive(false);
        m_QuestionPanel.SetActive(true);
    }

    public void TriggerFirstBaseQuestion()
    {
        GameManager.instance.SelectQuestion(1);
    }

    public void TriggerSecondBaseQuestion()
    {
        GameManager.instance.SelectQuestion(2);
    }

    public void TriggerThirdBaseQuestion()
    {
        GameManager.instance.SelectQuestion(3);
    }

    public void TriggerHomeBaseQuestion()
    {
        GameManager.instance.SelectQuestion(4);
    }

    public void Answer()
    {
        m_QuestionPanel.SetActive(false);
        m_TopCamera.gameObject.SetActive(true);

        m_MovePlayer = true;
    }
}
