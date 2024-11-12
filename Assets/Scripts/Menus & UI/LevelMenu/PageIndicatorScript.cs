using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// displays which page which the user is on
/// </summary>
/// <remarks>
/// Maintained by: Olivia StarStuff
/// </remarks>
public class PageIndicatorScript : MonoBehaviour
{
    public LevelMenuManager lMManager;
    public LevelSelectSwipeController SwipeController;
    [Space(10)]
    public GameObject paginationBox;
    public GameObject paginationIndicator;
    GameObject[] PageIndicators;
    [Space(10)]
    public Sprite activePage;
    public Sprite inactivePage;
    // Start is called before the first frame update
    void Start()
    {
        PageIndicators = new GameObject[lMManager.numberOfPages];
        for (int i = 0; i< lMManager.numberOfPages; i++ )
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
        for (int i = 0; i < lMManager.numberOfPages; i++)
        {
            Image imageComponent = PageIndicators[i].GetComponent<Image>();
            bool isCurrentPage = i == SwipeController.currentPage-1;
            imageComponent.sprite = isCurrentPage ? activePage : inactivePage;
        }
    }
}
