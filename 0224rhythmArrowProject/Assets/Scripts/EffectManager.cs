using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private static EffectManager instance;
    public static EffectManager Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<EffectManager>();
            }
            return EffectManager.instance;
        }
    }

    public ParticleSystem inputEffect;

    public RectTransform parent;

    public float parentWidth;
    public float parentHeight;

    public float nodeSize;

    public float scale;
    [SerializeField]
    GameObject arrowPrefab;

    public RectTransform containerRect;

    public GameObject[] guideArrow;

    // Use this for initialization
    void Start()
    {
        //  parent.position = new Vector3(GameManager_GenerateArrow.Instance.containerWidth / 2, GameManager_GenerateArrow.Instance.containerHeight / 2);

        guideArrow = new GameObject[10];
           
        parent.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, parentWidth);
        parent.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, parentHeight);

        for (int i = 1; i < 10; i++)
        {
            if (i == 5)
                continue;

            guideArrow[i] = (GameObject) Instantiate(arrowPrefab, parent.transform);

            RectTransform arrowRect = guideArrow[i].GetComponent<RectTransform>();

            guideArrow[i].transform.localPosition = getPosition(i);

            guideArrow[i].GetComponent<CanvasGroup>().alpha = 0.5f;

            arrowRect.Rotate(0,0,RotateArrows(i));

            arrowRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nodeSize );

            arrowRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, nodeSize );

            guideArrow[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int RotateArrows(int direction) //현재 nodes(8개)만큼 화살표방향을 설정하였다.
    {
        int rotateDegree = 0;

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

        return rotateDegree;
      }
    

    public Vector3 getPosition(int direction)
    {
        int i = 0;
        int j = 0;

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
        return new Vector3(parentWidth * (-i), parentHeight * (-j), 0).normalized * parentWidth;

    }

    public void ShowEffect(int direction)
    {
        ParticleSystem effect = Instantiate(inputEffect, parent);

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

      
        effect.transform.localPosition = getPosition(direction);
        Debug.Log(effect.transform.localPosition);
    }

}

