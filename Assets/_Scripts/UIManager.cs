using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uim;

    // ����� ���������� - �������� / �������
    [SerializeField]
    private Text resultText;

    // ����� ���������� ������� ����������� �����
    [SerializeField]
    private Text resultTimeText;

    [SerializeField]
    private GameObject mainScreenPanel;

    [SerializeField]
    private GameObject resultPanel;

    public Text showTimeText;
    private float time;

    private void Awake()
    {
        uim = this;
        mainScreenPanel.SetActive(true);
        resultPanel.SetActive(false);
    }
    private void Start()
    {
        time = PlayerPrefs.GetFloat("TimeResult");
        Result(time);
    }
    public void Result(float _time)
    {
        if (_time > 0)
        {
            resultText.text = "�� ��������!!!";
            resultTimeText.gameObject.SetActive(true);
            resultTimeText.text = "����� ������: " + _time.ToString("f0") + "���";
        }
        else if (_time <= 0)
        {
            resultText.text = "��� ������...";
            resultTimeText.gameObject.SetActive(false);
            resultTimeText.text = "����� ������: " + _time.ToString("f0") + "���";
        }
    }
    public void Result()
    {
        resultTimeText.gameObject.SetActive(false);
        resultText.text = "�� ���������!!!";
    }
    public void ShowTimer(float _time)
    {
        showTimeText.text = _time.ToString("f0");
    }
    public void ShowMainScreen(bool _isActive)
    {
        resultPanel.SetActive(false);
        mainScreenPanel.SetActive(_isActive);
    }
    public void ShowResultPanel(bool _isActive)
    {
        mainScreenPanel.SetActive(false);
        resultPanel.SetActive(_isActive);
    }
}
