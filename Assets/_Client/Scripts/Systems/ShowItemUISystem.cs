using Leopotam.Ecs;
using System.Collections.Generic;
using YohohoTest;

public class ShowItemUISystem : IEcsRunSystem
{
    private ItemsDatabase _itemDatabase;

    private EcsFilter<Player, ItemStorage, StorageChanged> _playerFilter;
    private EcsFilter<ItemUIRef> _uiFilter;

    private List<ItemUIRef> _itemUIs;

    public void Run()
    {
        foreach(var changeIndex in _playerFilter)
        {            
            ref var stack = ref _playerFilter.Get2(changeIndex).BoundedStack;
           
            var entityArray = stack.GetReversedArray();

            foreach (var index in _uiFilter)
            {
                ref var itemUIRef = ref _uiFilter.Get1(index);                
                
                itemUIRef.View.ResetSprite();

                if (!entityArray[itemUIRef.Position].IsNull())
                {
                    ref var itemType = ref entityArray[itemUIRef.Position].Get<Item>().ItemType;
                    var itemData = _itemDatabase.MappedItems[itemType];
                    itemUIRef.View.SetSprite(itemData.Sprite);
                }
            }
        }        
    }
}
