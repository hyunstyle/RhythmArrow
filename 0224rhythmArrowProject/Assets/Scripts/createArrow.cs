using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createArrow : MonoBehaviour
{

    public int arrowNum;

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;

    void Start()
    {
        StartCoroutine(creatArrow());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator creatArrow()
    {
        arrowNum = Random.Range(0, 8);
        arrow1.GetComponent<RectTransform>().transform.Rotate(new Vector3(0,0, 45 * arrowNum));
        arrowNum = Random.Range(0, 8);
        arrow2.GetComponent<RectTransform>().transform.Rotate(new Vector3(0, 0, 45 * arrowNum));
        arrowNum = Random.Range(0, 8);
        arrow3.GetComponent<RectTransform>().transform.Rotate(new Vector3(0, 0, 45 * arrowNum));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(creatArrow());
    }
}

