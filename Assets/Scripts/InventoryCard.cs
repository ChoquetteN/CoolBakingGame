using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCard : MonoBehaviour
{
    public int idForFood { get; private set; }

    Vector3 startPos;

    Vector3 lastPos;

    // Number of Good text
    [SerializeField]
    Text numberOfGoodText;

    // Good art
    [SerializeField]
    Image foodImage;

    // good price to sell
    public int SalePriceForGood { get; private set; }

    // Text for price to sell
    [SerializeField]
    Text SalePriceForGoodText;

    // text for name
    [SerializeField]
    Text GoodNameText;

    const int offsetBetweenCards = 1;


    // Show Card
    public void CreateCard(Food f)
    {
        idForFood = f.ID;
        GoodNameText.text = f.Name;
        foodImage.sprite = SpriteHolder.instance.GetFoodArtFromIDNumber(f.ID);
        SalePriceForGoodText.text = f.Sell.ToString();
        this.gameObject.SetActive(true);
        
        //ToDo, Set location;
    }

    public void UpdateNumberOfGood(int amnt)
    {
        numberOfGoodText.text = amnt.ToString();
    }

    public void OffsetCard(int numberOfCards)
    {
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(new Vector3((numberOfCards * 1), 0, 0));
        this.gameObject.GetComponent<RectTransform>().anchorMin = viewportPoint;
        this.gameObject.GetComponent<RectTransform>().anchorMax = viewportPoint;
        startPos = this.transform.position;
        lastPos = startPos;
    }
    // Hide Card
    public void HideCard()
    {
        this.gameObject.SetActive(false);
    }

    public void OnCardClick(Vector3 pointerLocation)
    {
        transform.position = pointerLocation;
    }

    public void MoveCardToLastPos()
    {
        transform.position = lastPos;
    }

    public void SetNewLastPos(Vector3 newLastPos)
    {
        lastPos = newLastPos;
    }

    public Vector3 GetLastPos()
    {
        return lastPos;
    }

    public void SetToStartPos()
    {
        lastPos = startPos;
    }
}
