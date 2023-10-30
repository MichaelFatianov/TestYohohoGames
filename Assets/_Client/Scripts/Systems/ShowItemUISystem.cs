using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using UnityEngine;
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

            var entityArray = new EcsEntity[_uiFilter.GetEntitiesCount()];

            stack.Stack.CopyTo(entityArray, 0);

            DebugArray(entityArray);

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

    public void DebugArray(EcsEntity[] array)
    {
        Debug.Log("Array l: " + array.Length);

        foreach(var i in array)
        {
            if(!i.IsNull()) Debug.Log(i.Get<Item>().ItemType);
        }
    }

    //public List<T> MapStack<T>(Stack<T> stack, int capacity)
    //{
    //    var array = new List<T>(capacity);
    //    Stack<T> stackCopy;
    //    stack.CopyTo(stackCopy, 0);
    //    for (var i = 0; i< stack.Count; i++)
    //    {
    //        var element = stack.Pop();
    //        reserveStack.Push(element);
    //        array.Insert(0, element); 
    //    }

    //    return
    //}
}
