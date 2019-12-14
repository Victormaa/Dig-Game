using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum RocketAction { Launching, Crushing,Winning }
public class Test_Manager : MonoBehaviour
{
    public Toggle state1;
    public Toggle state2;
    public Toggle state3;
    public Toggle state4;
    public Toggle DirTest;

    public Text adjustvalue;

    public Text adjustVector;

    //BGM
    [SerializeField]
    bool tempMusicToggle = true;
    [SerializeField]
    AudioClip bgm;
    [SerializeField]
    float bgmLoopingPoint = 82;

    //SoundsEffects
    [SerializeField]
    AudioClip explosion;
    [SerializeField]
    AudioClip launch;
    [SerializeField]
    AudioClip inwormhole;

    public static RocketAction RocketStatus = RocketAction.Launching;

    public Test_ball Player;

    private SlowDown _slowdown;

    public Slider FlyingUI;

    [SerializeField]
    Image Hand;

    public GameObject CrushUI;

    public GameObject WinUI;

    public Button PrepareUI;

    public Slider PrepareAngle;

    private float originalAngle = 90;

    private static Test_Manager gameManager;

    public Test_level Currentlevel;

    [SerializeField]
    private Texture2D upArrow;

    [SerializeField]
    private Texture2D downArrow;

    [SerializeField]
    private Texture2D normalArrow;

    public GameObject pauseUI;
    private GameObject PUI;

    public GameObject LastImage;

    public static bool GameIsPaused = false;
    public static bool IsRocketCrushed = false;
    public static bool ischangingG = false;

    public static bool CurisLarger = false;

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
        SceneManager.LoadScene(Currentlevel.level);
        Currentlevel.level += 1;

        if(SceneManager.GetActiveScene().name == "Level5")
        {
            SceneManager.LoadScene(0);
            Currentlevel.level = 3;
        }
    }

    private void Awake()
    {
        Debug.Log("manager awake");
        if (gameManager != null)
        {
            return;
        }
        gameManager = this;

        _slowdown = Player.gameObject.GetComponent<SlowDown>();
       
    }
    private void Start()
    {
        GameIsPaused = false;
        Invoke("GameSceneMusic", 3);
    }

    void GameSceneMusic()
    {
        if (tempMusicToggle)
        {
            MusicManager.instance.PlayMusic(bgm, bgmLoopingPoint);
        }
    }

    public void SoundEffect()
    {
        AudioClip clip;
        if(RocketStatus == RocketAction.Launching)
        {
            clip = launch;
            MusicManager.instance.PlayEffectMusic(clip);
        }
        if(RocketStatus == RocketAction.Crushing)
        {
            clip = explosion;
            MusicManager.instance.PlayEffectMusic(clip);
        }
        if (RocketStatus == RocketAction.Winning)
        {
            clip = inwormhole;
            MusicManager.instance.PlayEffectMusic(clip);
        }      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {               
                ResumeGame();
            }
            else
            {
                PauseGame();
                setNorCur();
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            loadScene(2);
            Currentlevel.level = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            loadScene(3);
            Currentlevel.level = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            loadScene(4);
            Currentlevel.level = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            loadScene(5);
            Currentlevel.level = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            loadScene(6);
            Currentlevel.level = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            loadScene(7);
            Currentlevel.level = 8;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            loadScene(0);
        }
    }

    public void setoriginalGravity()
    {
        foreach(GameObject a in _slowdown.Planets)
        {
            var gravity = a.GetComponent<Test_Gravity>();
            gravity.proximityModifier = gravity.maxModifier - gravity.originalG;
        }
    }

    public void setUpCur()
    {
        Cursor.SetCursor(upArrow, Vector2.zero, CursorMode.ForceSoftware);
        Hand.color = new Color(Hand.color.r, Hand.color.g, Hand.color.b, 1);
    }

    public void setDownCur()
    {
        Cursor.SetCursor(downArrow, Vector2.zero, CursorMode.ForceSoftware);
        Hand.color = new Color(Hand.color.r, Hand.color.g, Hand.color.b, 1);
    }

    public void setNorCur()
    {
        Cursor.SetCursor(normalArrow, Vector2.zero, CursorMode.ForceSoftware);
        Hand.color = new Color(Hand.color.r, Hand.color.g, Hand.color.b, 0.7f);
    }

    public void setHandOffToggle()
    {
        Hand.color = new Color(Hand.color.r, Hand.color.g, Hand.color.b, 0.7f);
    }

    public void setHandActive(bool b)
    {
        Hand.gameObject.SetActive(b);
    }

    public void resetangle()
    {
        PrepareAngle.value = originalAngle;
        AngleButtonInput.value = originalAngle;
    }

    void PauseGame()
    {
        PUI = Instantiate(pauseUI, new Vector3(0, 0, 1), Quaternion.identity);
        PrepareUI.interactable = false;
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        Destroy(PUI.gameObject);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    #region for tutorial convinience
    private void loadScene(int scenenum)
    {
        SceneManager.LoadScene(scenenum);
    }

    #endregion
}
