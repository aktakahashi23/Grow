using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "Scriptable Objects/InventoryItemData")]
public class InventoryItemData : ScriptableObject
{
    public string id; // for item to ref 
    public string displayName;
    public Sprite icon;
    public GameObject prefab; 


}
