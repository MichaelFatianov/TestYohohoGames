using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ItemsDatabase", fileName = "ItemsDatabase")]
public class ItemsDatabase : ScriptableObject
{

    [SerializeField] private ItemData[] _itemsData;
    private Dictionary<ItemType, ItemData> _mappedItems;

    public ItemData[] ItemsData => _itemsData;   
    
    public Dictionary<ItemType, ItemData> MappedItems
    {
        get
        {
            if (_mappedItems.IsUnityNull())
            {
                MapItemData();
            }
            return _mappedItems;
        }
    }

    private void MapItemData()
    {
        _mappedItems = new Dictionary<ItemType, ItemData>();
        foreach (var itemData in _itemsData)
        {
            MappedItems.Add(itemData.Type, itemData);
        }
    }
}
