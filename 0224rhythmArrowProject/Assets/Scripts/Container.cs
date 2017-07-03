using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public bool isPlaying = false;
    

    public Song songPlaying;

    public GameObject[] Arrow;

    public List<float> commands;

    public int commandIndex = 0;

    public float nodeSize;

    public float nodePadding;

    public float containerWidth;

    public int nodes;

    private RectTransform containerRect;

    private float tempDegree; // 이동한 각도를 임시로 저장할 배열

    private int arrowIndex;

    [SerializeField]
    public int direction;

    bool isEnd = false;
        
        
    private void Start()
    {
        containerRect = GetComponent<RectTransform>();

        InitializeContainer();

        InstantiateArrows();

        RotateArrows();

        commandIndex = 0;
    }

    private void Update()
    {
        if (isPlaying && commands.Count > 0 && (commands[commandIndex] <= Time.time - TimeCheck.tempTime) )
        {
            Drop();

            commandIndex++;
            if(commandIndex >= commands.Count)
            {
                isPlaying = false;
            }
        }
        if (songPlaying != null)   //커맨드가 다끝나고 3초후에 리절트창뜬다.
        {
            
            if (!isEnd &&Time.time >= songPlaying.CommandsArray[songPlaying.CommandsArray.Length - 1] + 3.0f && !songPlaying.audioSource.isPlaying && !GameManager_GotoResultmenu.Instance.resultMenu.activeSelf)
            {
                isEnd = true;
                GameManager_GotoResultmenu.Instance.GoToResultCanvas();
                Debug.Log("asdf");
            }
        }
    }

    public  void LoadingCommands()
    {
        commands = new List<float>();
    }

    void InitializeContainer()
    {
        int i = 0, j = 0;

        switch (direction.ToString()) // 랜덤으로 큐에 들어간 Arrow의 수를 회전할 각도로 변환
        {
            case "1":
                i = +1; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                j = +1;
                break;
            case "2":
                i = 0; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                j = +1;
                break;
            case "3":
                i = -1; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                j = +1;
                break;
            case "4":
                i = +1; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                j = 0;
                break;
            case "6":
                i = -1; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                j = 0;
                break;
            case "7":
                i = +1; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                j = -1;
                break;
            case "8":
                i = 0; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                j = -1;
                break;
            case "9":
                i = -1; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                j = -1;
                break;
            default:
                break;
        }

        GetComponent<RectTransform>().localPosition = new Vector3(GameManager_GenerateArrow.Instance.containerWidth / 2 * -i, GameManager_GenerateArrow.Instance.containerHeight / 2 * -j);
    }

    public void InstantiateArrows()
    {
        Arrow = new GameObject[10];   //방향 하나당 10개의 화살표를 미리 로딩;

        GameObject UIPrefab = GameManager_GenerateArrow.Instance.UIPrefab;

        Canvas canvas = GameManager_GenerateArrow.Instance.canvas;

        for (int i = 0; i < 10; i++)
        {
            Arrow[i] = Instantiate(UIPrefab, this.transform);

            tempDegree = 0;
          
           // Arrow[i].transform.SetParent(canvas.transform);

            RectTransform nodeRect = Arrow[i].GetComponent<RectTransform>();

           // Arrow[i].transform.SetParent(this.transform);

            nodeRect.localPosition = new Vector3(0, 0, 0);

            nodeRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nodeSize * canvas.scaleFactor);

            nodeRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, nodeSize * canvas.scaleFactor);
        }
    }

    public void RotateArrows() //현재 nodes(8개)만큼 화살표방향을 설정하였다.
    {
        containerRect = GetComponent<RectTransform>();

        int rotateDegree = 0;

        for (int i = 0; i < nodes; i++)
        {
            RectTransform arrowLocation = Arrow[i].GetComponent<RectTransform>();

            Arrow[i].transform.SetParent(containerRect);

            switch (direction.ToString()) // 랜덤으로 큐에 들어간 Arrow의 수를 회전할 각도로 변환
            {
                case "1":
                    rotateDegree = 315; // 기본 Arrow 이미지에서 315도 z축으로 돌리면 키패드 1번 위치의 화살표
                    break;
                case "2":
                    rotateDegree = 0; // 키패드 2번이 기본 이미지이므로 각도 추가 없음
                    break;
                case "3":
                    rotateDegree = 45; // 키패드 3번은 +45도, 이런식으로 9번까지 할당
                    break;
                case "4":
                    rotateDegree = 270;
                    break;
                case "6":
                    rotateDegree = 90;
                    break;
                case "7":
                    rotateDegree = 225;
                    break;
                case "8":
                    rotateDegree = 180;
                    break;
                case "9":
                    rotateDegree = 135;
                    break;
                default:
                    break;
            }
            tempDegree = rotateDegree; // 최초 실행시 tempDegree[i] = 0, 이후에는 그 전에 돌아간 각도만큼 다시 원래대로 돌려준후, 다시 rotateDegree만큼 각도이동, 반복

            Arrow[i].GetComponent<Transform>().Rotate(0, 0, tempDegree);

            Arrow[i].GetComponent<CanvasGroup>().alpha = 0.0f;
        }
    }

    public void Drop()
    {

        int i = 0, j = 0;

        switch (direction.ToString()) // 랜덤으로 큐에 들어간 Arrow의 수를 회전할 각도로 변환
        {
            case "1":
                i = +1; 
                j = +1;
                break;
            case "2":
                i = 0; 
                j = +1;
                break;
            case "3":
                i = -1;
                j = +1;
                break;
            case "4":
                i = +1; 
                j = 0;
                break;
            case "6":
                i = -1; 
                j = 0;
                break;
            case "7":
                i = +1;
                j = -1;
                break;
            case "8":
                i = 0;
                j = -1;
                break;
            case "9":
                i = -1; 
                j = -1;
                break;
            default:
                break;
        }
       // Debug.Log("start at : " + Time.time);
        iTween.MoveTo(Arrow[arrowIndex], iTween.Hash("position", new Vector3(GameManager_GenerateArrow.Instance.containerWidth / 2 * i, GameManager_GenerateArrow.Instance.containerHeight / 2 * j) - new Vector3(GameManager_GenerateArrow.Instance.containerWidth / 2 * i, GameManager_GenerateArrow.Instance.containerHeight / 2 * j).normalized * 150, "islocal", true, "easeType", "Linear", "time", 1.0f , "oncomplete", "hideArrow" , "onstart" , "showArrow" ,"oncompletetarget" , Arrow[arrowIndex], "onstarttarget", Arrow[arrowIndex]));

        arrowIndex++;

        if (arrowIndex >= 10)
        {
            arrowIndex = 0;
        }
       // Debug.Log(Time.time);

      //  Debug.Log(direction.ToString());
   
    }
}
