using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController inputController;

    private float h;
    private float v;

    public float Horizontal
    {
        get
        {
            return h;
        }
    }
    public float Vertical
    {
        get
        {
            return v;
        }
    }

    private void Awake()
    {
        inputController = this;
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.uim.ShowMainScreen(true);
            GameManager.gm.DestroyBall();
        }
    }
    public void PlayButton()
    {
        UIManager.uim.ShowMainScreen(false);
        GameManager.gm.ResetTimer();
        GameManager.gm.StartTime(true);
        GameManager.gm.SpawnBall();
    }
    public void ResultButton()
    {
        UIManager.uim.ShowResultPanel(true);
        UIManager.uim.Result(PlayerPrefs.GetFloat("TimeResult"));
    }
}
