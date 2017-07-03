using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private CanvasGroup canvasgroup;

    private Container container;

	// Use this for initialization
	void Start () {
        canvasgroup = GetComponent<CanvasGroup>();
        container = GetComponentInParent<Container>();
	}

    void showArrow()
    {
        canvasgroup.alpha = 1.0f;
    }

    void hideArrow()
    {
        GameManager_Input.Instance.commandindex[container.direction]++;

        canvasgroup.alpha = 0;
        transform.localPosition = new Vector3(0, 0, 0);
        GameManager_GenerateArrow.Instance.failCount++;
        GameManager_GenerateArrow.Instance.totalInputCount = GameManager_GenerateArrow.Instance.perfectCount + GameManager_GenerateArrow.Instance.goodCount + GameManager_GenerateArrow.Instance.failCount;
        GameManager_GenerateArrow.Instance.calLife(1, 0);
        GameManager_GenerateArrow.Instance.displayLife();

    }
}
