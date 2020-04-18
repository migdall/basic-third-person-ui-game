using System;
using UnityEngine;
using UnityEngine.UI;

public class PlusButtonController : MonoBehaviour
{
    // This script will control a plus button

    public GameObject m_NumberText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlusByOne()
    {
        int num = Convert.ToInt32(m_NumberText.GetComponent<Text>().text);
        if (num < 9)
        {
            num += 1;
            m_NumberText.GetComponent<Text>().text = num.ToString();
        }
    }
}
