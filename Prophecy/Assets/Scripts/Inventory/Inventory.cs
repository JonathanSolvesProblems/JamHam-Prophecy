using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public List<Item> items = new List<Item>();

    // creating singleton for inventory
    // can only have 1 inventory at all times.
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found. Watch out.");
            return;
        }
        instance = this; // sets to this particular component. 
    }


    #endregion

    public int space = 25; // limited space for inventory

    // delegate, can subscribe methods to (like observer pattern)
    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;


    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room in inventory.");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null) // will get error if null
                onItemChangedCallback.Invoke(); // updates UI
        }

        return true;

    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

}
