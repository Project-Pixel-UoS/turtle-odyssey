using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;

public class LevelSelectSwipeController : MonoBehaviour//, IDropTarget
{
    public int maxPage;
    public int currentPage;
    public Vector3 targetPos;
    public Vector3 pageStep;
    public RectTransform levelPagesRect;
    public float tweenTime;
    public LeanTweenType tweenType;
    float dragThreshold;
    public GameObject pageIndicatorBox;
    public RectTransform pageIndicatorRect;
    // Start is called before the first frame update
    void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
        dragThreshold = Screen.width / 15;
    }

    void Start()
    {
        // GameObject child = pageIndicatorBox.transform.GetChild(currentPage-1).gameObject;
        // Debug.Log(child.GetComponent<RectTransform>().transform.localPosition);
        // Debug.Log(child.GetComponent<RectTransform>().position);
        // Debug.Log(child.name);
        // pageIndicatorRect.localPosition = child.GetComponent<RectTransform>().localPosition;
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos -= pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Reset()
    {
        targetPos += (currentPage-1) * pageStep;
        currentPage = 1;
        MovePage();

    }
    // Update is called once per frame
    void MovePage()
    {
        // Vector3 indicatorPos = pageIndicatorBox.transform.GetChild(currentPage-1).GetComponent<RectTransform>().localPosition;
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
        // pageIndicatorRect.LeanMoveLocal(indicatorPos, tweenTime).setEase(tweenType);
    }
    public void OnMouseDown()
    {
        Debug.Log("Hello");
    }
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshold)
    //     {
    //         if (eventData.position.x > eventData.pressPosition.x)
    //         {
    //            Previous();
    //         }
    //         else
    //         {
    //             Next();
    //         }
    //     }
    //     else
    //     {
    //         MovePage();
    //     }
    // }
}
