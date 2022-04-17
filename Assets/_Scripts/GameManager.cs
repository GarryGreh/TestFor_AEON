using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private GameObject spawnBall;

    private float timer = 0;

    private void Awake()
    {
        gm = this;
    }
    private void Start()
    {
        StartTime(false);
    }
    private void Update()
    {
        Timer();
    }
    private void Timer()
    {
        timer += Time.deltaTime;
        UIManager.uim.ShowTimer(timer);
    }
    public void ResetTimer()
    {
        timer = 0;
    }
    public void StartTime(bool _isStartTime)
    {
        if (_isStartTime)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
        }
    }
    public void SpawnBall()
    {
        Instantiate(ballPrefab, spawnBall.transform.position, Quaternion.identity);

    }
    public void Finish()
    {
        StartTime(false);
        PlayerPrefs.SetFloat("TimeResult", timer);
        UIManager.uim.ShowResultPanel(true);
        UIManager.uim.Result(timer);
        DestroyBall();
    }
    public void Lost()
    {
        UIManager.uim.ShowResultPanel(true);
        UIManager.uim.Result();
        StartTime(false);
        DestroyBall();
    }
    public void DestroyBall()
    {
        if (FindObjectOfType<BallController>())
        {
            GameObject ball = FindObjectOfType<BallController>().gameObject;
            Destroy(ball);
        }
    }
}
