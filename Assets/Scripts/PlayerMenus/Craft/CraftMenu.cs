using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMenu : MonoBehaviour, iPlayerMenuTab
{
    [SerializeField]
    CookingSlot slotOne;

    [SerializeField]
    CookingSlot slotTwo;

    [SerializeField]
    CookingOutputSlot slotOut;

    [SerializeField]
    Button BakeButton;

    public PlayerMenu playerMenu { get; private set; }

    List<Food> foodInSlots;

    void Start()
    {
        BakeButton.onClick.AddListener(new BakeCommand(this).Execute);
        BakeButton.interactable = false;
    }

    public void showProps()
    {
        playerMenu.setMenu(this);
        foodInSlots = new List<Food>();
        this.gameObject.SetActive(true);
        slotOne.gameObject.SetActive(true);
        slotTwo.gameObject.SetActive(true);
        slotOut.gameObject.SetActive(true);
        BakeButton.gameObject.SetActive(true);
        slotOne.OnCardAdd = CheckForRecipie;
        slotOne.OnCardRemove = removeFromRecipie;
        slotTwo.OnCardAdd = CheckForRecipie;
        slotTwo.OnCardRemove = removeFromRecipie;        
    }

    public void hideProps()
    {
        slotOne.gameObject.SetActive(false);
        slotTwo.gameObject.SetActive(false);
        slotOut.gameObject.SetActive(false);
        BakeButton.gameObject.SetActive(false);
    }

    public void setPlayerMenu(PlayerMenu pm)
    {
        playerMenu = pm;
    }

    public void CheckForRecipie(InventoryCard ic)
    {
       foodInSlots.Add(playerMenu.getSpecificFood(ic.idForFood));
       BakeButton.interactable = playerMenu.checkForRecipie(foodInSlots, slotOut);
    }
    
    public void removeFromRecipie(InventoryCard ic)
    {
        foodInSlots.Remove(playerMenu.getSpecificFood(ic.idForFood));
        BakeButton.interactable = playerMenu.checkForRecipie(foodInSlots, slotOut);
    }

    // Need a command for bake button click. 
    public void Bake()
    {

            slotOut.storedCard.GetComponent<Button>().interactable = true;
            playerMenu.addFoodToInventoryById(slotOut.storedCard.idForFood, 1);


            if (slotOne.cardInSlot != null)
                playerMenu.subtractFoodFromInventory(playerMenu.getSpecificFood(slotOne.cardInSlot.idForFood));
        //if (!slotOne.cardInSlot.gameObject.activeInHierarchy)
        // slotOne.cardInSlot = null;

        if (slotTwo.cardInSlot != null)
                playerMenu.subtractFoodFromInventory(playerMenu.getSpecificFood(slotTwo.cardInSlot.idForFood));
        // if (!slotTwo.cardInSlot.gameObject.activeInHierarchy)
        //  slotTwo.cardInSlot = null;

    }
}
