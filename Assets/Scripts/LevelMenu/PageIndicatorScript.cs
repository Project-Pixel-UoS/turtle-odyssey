using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageIndicatorScript : MonoBehaviour
{
    public Sprite activePage;
    public Sprite inactivePage;
    public LevelMenuManager lMManager;
    public LevelSelectSwipeController SwipeController;
    public GameObject pageHolder;
    public GameObject paginationBox;
    public GameObject paginationIndicator;
    public GameObject[] PageIndicators;
    private int numberOfPages;
    // Start is called before the first frame update
    void Start()
    {

        numberOfPages = lMManager.GetNumberOfPages();
        PageIndicators = new GameObject[numberOfPages];
        for (int i = 0; i< numberOfPages; i++ )
        {
            PageIndicators[i]  = Instantiate(paginationIndicator,
                        transform.position,
                        Quaternion.identity,
                        paginationBox.transform);
        }
        SwitchPage();
    }

    public void SwitchPage()
    {
        for (int i = 0; i < numberOfPages; i++)
        {
            Image imageComponent = PageIndicators[i].GetComponent<Image>();
            bool isCurrentPage = i == SwipeController.currentPage-1;
            imageComponent.sprite = isCurrentPage ? activePage : inactivePage;
        }
    }
}
