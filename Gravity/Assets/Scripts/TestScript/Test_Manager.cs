using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test_Manager : MonoBehaviour
{
    public Toggle state1;
    public Toggle state2;
    public Toggle state3;
    public Toggle state4;

    public Test_ball Player;

    public GameObject FlyingUI;

    public GameObject CrushUI;

    public GameObject WinUI;

    public GameObject PrepareUI;

    private static Test_Manager gameManager;

    public Test_level Currentlevel;

    public static Test_Manager Instance
    {
        get
        {
            if (gameManager == null)
            {
                new Test_Manager();

            }
            return gameManager;
        }
    }

    public void Restart()
    {
        Player.RePrepare();
    }

    public void NextLev()
    {
        SceneManager.LoadScene(Currentlevel.level + 1);
        Currentlevel.level += 1;
        if (Currentlevel.level == 2)
            Currentlevel.level = -1;
    }

    private void Awake()
    {
        Debug.Log("manager awake");
        if (gameManager != null)
        {
            return;
        }
        gameManager = this;
    }
}
