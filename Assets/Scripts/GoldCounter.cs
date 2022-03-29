using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    // Text for the amount of gold.
    [SerializeField]
    Text goldAmnt;

    int curGold;
    
    // Increment gold amount, may have a playerState menu that this takes from. 
    public void DisplayGoldAmount(int goldOnHand)
    {
        goldAmnt.text =  goldOnHand.ToString();
    }


    // Some sort of count up and count down animation. 


}
