using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;

    public CoinCount coinCount;

    public bool canScore = true;

    void OnTriggerEnter(Collider other)
    {

        if (canScore == true)
        {
            canScore = false;
            Managers.Inventory.AddItem(itemName);
            coinCount.coinAmount++;
            Destroy(this.gameObject);
        }
        
    }
}