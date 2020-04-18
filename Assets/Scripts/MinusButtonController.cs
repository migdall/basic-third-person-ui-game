using System;
using UnityEngine;
using UnityEngine.UI;

public class MinusButtonController : MonoBehaviour
{
    // This script will control a minus button

    public GameObject m_NumberText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MinusByOne()
    {
        int num = Convert.ToInt32(m_NumberText.GetComponent<Text>().text);
        if (num > 0)
        {
            num -= 1;
            m_NumberText.GetComponent<Text>().text = num.ToString();
        }
    }
}
