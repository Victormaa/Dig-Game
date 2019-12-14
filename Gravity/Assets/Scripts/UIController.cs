using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    GameObject buttonResume;
    [SerializeField]
    GameObject buttonRestart;
    [SerializeField]
    GameObject buttonHelp;
    [SerializeField]
    GameObject buttonBackToMenu;
    [SerializeField]
    GameObject helpCanvas;

    private Button BR;
    private Button BRS;
    private Button BH;
    private Button BB;
    public bool isPause = true;

    // Start is called before the first frame update
    void Start()
    {
        BR = buttonResume.GetComponent<Button>();
        BRS = buttonRestart.GetComponent<Button>();
        BH = buttonHelp.GetComponent<Button>();
        BB = buttonBackToMenu.GetComponent<Button>();
        BR.onClick.AddListener(ResumeGame);
        BRS.onClick.AddListener(RestartGame);
        BH.onClick.AddListener(Help);
        BB.onClick.AddListener(BackToMenu);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        Test_Manager.GameIsPaused = false;
        Destroy(gameObject);
    }
    void RestartGame()
    {
        Test_Manager.Instance.Restart();
        AngleButtonInput.value = 90f;
        ResumeGame();
    }
    void Help()
    {
        Instantiate(helpCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        
    }
    void BackToMenu()
    {
        Application.LoadLevel("ui_main menu");
    }
}
