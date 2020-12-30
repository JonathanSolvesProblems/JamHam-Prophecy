
using UnityEngine;

// making a blueprint
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item"; // overriding old definition with new

    public Sprite icon = null; // item to show in our inventory.
    public bool isDefaultItem = false;




}
