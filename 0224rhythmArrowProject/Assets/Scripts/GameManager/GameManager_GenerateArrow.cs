using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_GenerateArrow : MonoBehaviour {

    private static GameManager_GenerateArrow instance;
    public static GameManager_GenerateArrow Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<GameManager_GenerateArrow>();
            }
            return GameManager_GenerateArrow.instance;
        }
    }

    public float life = 10;
    public float lifeDisplayed = 10; 
    public Canvas canvas;
    public int TotalScore;
    public Text scoreEffect;
    public int combo = 0;

    public bool isEditing;

    public GameObject[] arrowUI;

    private float nodeSize = 200;
    public GameObject UIPrefab;

    private RectTransform containerRect;
    public GameObject container;
    private RectTransform contentRect;
    public GameObject content;
    public float containerWidth;
    public float containerHeight;
    private float contentWidth;
    private float contentHeight;
    public float nodePadding;
    public float nodePaddingTop;
    public int nodes = 8; //노드 숫자
    public int rows; //row갯수 보통 1
    public Image ArrowContainer;

    public Text ScoreBoard;
    private int nodeIndex = 0;   // arrowIndex 를 nodeIndex로 이름 수정했음.
    public int Difficulty = 1;
    private int Difficulty_Max = 9;
    private int tempDifficulty = 4;

    private float[] tempDegree;

    [SerializeField]
    private Container[] containers;

    public float totalInputCount = 0;
    public float perfectCount = 0;
    public float goodCount = 0;
    public float failCount = 0;

    public Text successPercentage;
    public Text perfectCounter;
    public Text goodCounter;
    public Text failCounter;

    public GameObject challengerRank;
    public GameObject diamondRank;
    public GameObject platinumRank;
    public GameObject goldRank;
    public GameObject silverRank;
    public GameObject bronzeRank;
    public int tempi = 0;
    public float realTime;
    public float tempTime = 0;

    public GameObject IngameCanvas;
    public AudioSource StartBGM;

    public GameObject ResultCanvas;
    public Animator anim;

    void Start()
    {
        InitializeUI();       // 우선 컨테이너에 최대(9)만큼 인스턴스를만들어놓는다. 
        IngameCanvas.SetActive(false);
        Time.timeScale = 0;
        if(!isEditing)
        anim = scoreEffect.GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time > 0 && !IngameCanvas.activeSelf && canvas.GetComponent<CanvasGroup>().alpha == 1)
        {
            IngameCanvas.SetActive(true);
            StartBGM.Stop();
        }
    }


    void InitializeUI()                             //우선 max만큼 화살표를 만들어놓고 다 컨테이너에 옮겨놓는다.
    {
        arrowUI = new GameObject[Difficulty_Max];

        containerRect = container.GetComponent<RectTransform>();

        float LeftSideNode = nodes / 2;

        containerRect.localPosition = new Vector3(0, 0, 0);
        containerHeight = 1000 ;
        containerWidth = 1000;

        containerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, containerWidth + nodePadding);
        containerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, containerHeight + nodePaddingTop);
    }


    public void PopScoreEffect(int score)
    {
        if (score == 10)
            scoreEffect.text = "Perfect!!";
        else if (score == 8)
            scoreEffect.text = "Good";
        else if (score == 0)
            scoreEffect.text = "Fail";
    }

    public void judgeCounter(int score)
    {
        if (score == 2)
        {
            combo++;
            scoreEffect.text = combo.ToString() + "\nPerfect";
            scoreEffect.color = new Color(0, 0, 1);

            anim.ResetTrigger("POP");
            anim.SetTrigger("POP");

            perfectCount++;
            failCount--;
            calLife(0, 1.2f);
        }
        else if (score == 1)
        {
            combo++;
            scoreEffect.text = combo.ToString() + "\nGood";
            scoreEffect.color = new Color(0, 1, 0);

            anim.ResetTrigger("POP");
            anim.SetTrigger("POP");

            goodCount++;
            failCount--;
            calLife(0, 1.2f);
        }
        else if (score == 0)
        {
            combo = 0;
            scoreEffect.text = combo.ToString() + "\nFail";
            anim.SetTrigger("POP");
            scoreEffect.color = new Color(1, 0, 0);
            totalInputCount = perfectCount + goodCount + failCount;
        }


    }

    public void judgeRank(bool isNotOn)
    {
        if (isNotOn == true)
        {
            perfectCounter.text = "Perfect : " + perfectCount.ToString();
            goodCounter.text = "Good : " + goodCount.ToString();
            failCounter.text = "Fail : " + failCount.ToString();
            successPercentage.text = (100f * (perfectCount + goodCount) / totalInputCount).ToString();

            if (perfectCount == totalInputCount) // ALL Perfect 시 challenger 랭크
                challengerRank.SetActive(!challengerRank.activeSelf);
            else if (perfectCount + goodCount == totalInputCount) // 전부 perfect는 아니지만 Fail이 1개도 없을때 diamond 랭크
                diamondRank.SetActive(!diamondRank.activeSelf);
            else if ((perfectCount + goodCount) < totalInputCount && (perfectCount + goodCount) >= totalInputCount * 0.85f)
            {
                platinumRank.SetActive(!platinumRank.activeSelf);
            }
            else if ((perfectCount + goodCount) < totalInputCount && (perfectCount + goodCount) >= totalInputCount * 0.7f)
            {
                goldRank.SetActive(!goldRank.activeSelf);
            }
            else if ((perfectCount + goodCount) < totalInputCount && (perfectCount + goodCount) >= totalInputCount * 0.55f)
            {
                silverRank.SetActive(!silverRank.activeSelf);
            }
            else
                bronzeRank.SetActive(!bronzeRank.activeSelf);
        }
        else // 랭크가 켜져있으면 전부 끈다.
        {
            challengerRank.SetActive(false);
            diamondRank.SetActive(false);
            platinumRank.SetActive(false);
            goldRank.SetActive(false);
            silverRank.SetActive(false);
            bronzeRank.SetActive(false);
        }
    }

    public void calLife(float damage , float heal)
    {
        life -= damage;
        life += heal;

        //if (life == Mathf.Floor(life))  // 0.2가 1을 모으면 display해준다.         {
        //    displayLife();
        
    }

    public void displayLife()
    {
        lifeDisplayed = Mathf.Floor(life);

        if (lifeDisplayed < 1)
        {
            Time.timeScale = 0;
            AudioPeer.Instance._audioSource.Stop();
            
            GameManager_GotoResultmenu.Instance.GoToResultCanvas();
            bronzeRank.SetActive(true);
            successPercentage.text = "GameOver";
        }
    }
    
}
