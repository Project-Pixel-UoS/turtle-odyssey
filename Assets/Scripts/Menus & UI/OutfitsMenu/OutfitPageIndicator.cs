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
public class OutfitPageIndicator : MonoBehaviour
{
    public OutfitSwipeManager outfitManager;
    public OutfitSwipeController SwipeController;
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
        Debug.Log(outfitManager.numberOfPages);
        PageIndicators = new GameObject[outfitManager.numberOfPages];
        for (int i = 0; i< outfitManager.numberOfPages; i++ )
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
        for (int i = 0; i < outfitManager.numberOfPages; i++)
        {
            Image imageComponent = PageIndicators[i].GetComponent<Image>();
            bool isCurrentPage = i == SwipeController.currentPage-1;
            imageComponent.sprite = isCurrentPage ? activePage : inactivePage;
        }
    }
}
