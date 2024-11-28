using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.UI;

/// <summary>
/// Manages the swipe and scroll snap behaviour of the level menu
/// </summary>
/// <remarks>
/// Maintained by: Olivia StarStuff
/// Created following Rehope Games tutorial at
/// https://www.youtube.com/watch?v=qf9xe2mbWeU
/// </remarks>
public class OutfitSwipeController : MonoBehaviour
{

    [Header("Swipe details")]
    public Vector3 pageStep;
    public RectTransform levelPagesRect;
    public float tweenTime;
    public LeanTweenType tweenType;
    float dragThreshold;
    [Space]
    public int maxPage;
    public int currentPage;
    Vector3 targetPos;
    [Header("Button References")]
    public GameObject nextBtn;
    public GameObject previousBtn;
    private Vector2 dragStart;
    public OutfitSwipeManager outfitManager;
    // Start is called before the first frame update
    void Awake()
    {
        OutfitSwipeManager outfitManager = GetComponent<OutfitSwipeManager>();
        currentPage = 1;
        // Debug.Log(currentPage);
        targetPos = levelPagesRect.localPosition;
        targetPos -= (currentPage-1) * pageStep;
        dragThreshold = Screen.width / 15;
    }

    void Start()
    {
        maxPage = outfitManager.numberOfPages;
        // DisableNavigationButtonsAtEachEnds();
        // MovePage();
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

    public void DisableNavigationButtonsAtEachEnds()
    {
        nextBtn.GetComponent<Button>().interactable = currentPage < maxPage;
        previousBtn.GetComponent<Button>().interactable = currentPage > 1;
    }

    // Update is called once per frame
    void MovePage()
    {
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }

    public void OnStartDrag()
    {
        dragStart = Input.mousePosition;
    }

    public void OnEndDrag()
    {
        if (Mathf.Abs(Input.mousePosition.x - dragStart.x) > dragThreshold)
        {
            if (Input.mousePosition.x > dragStart.x)
            {
               Previous();
            }
            else
            {
                Next();
            }
        }
        else
        {
            MovePage();
        }
    }
}
