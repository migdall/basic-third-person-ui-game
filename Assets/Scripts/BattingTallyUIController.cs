using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BattingTallyUIController : MonoBehaviour
{
    // This script will control the UI on the batting panel
    public GameObject m_BattingTallyPanelNextButton;
    public GameObject m_ResultText;
    public InputField m_RedTeamInput;
    public InputField m_BlueTeamInput;

    private static readonly int MinimumTally = 1;
    private static readonly int MaximumTally = 100;

    private int m_RandomNumber;

    // Start is called before the first frame update
    void Start()
    {
        m_ResultText.SetActive(false);
        m_BattingTallyPanelNextButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tally()
    {
        int redInput = Convert.ToInt32(m_RedTeamInput.text);
        int blueInput = Convert.ToInt32(m_BlueTeamInput.text);

        System.Random random = new System.Random();
        int randomNumber = random.Next(MinimumTally, MaximumTally);

        int redDifference = Math.Abs(randomNumber - redInput);
        int blueDifference = Math.Abs(randomNumber - blueInput);

        m_ResultText.SetActive(true);
        if (redDifference < blueDifference)
        {
            m_ResultText.GetComponent<Text>().text = "Blue";
        }
        else
        {
            m_ResultText.GetComponent<Text>().text = "Red";
        }

        m_BattingTallyPanelNextButton.SetActive(true);
    }
}
