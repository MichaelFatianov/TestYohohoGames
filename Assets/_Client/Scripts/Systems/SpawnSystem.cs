using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class SpawnSystem : IEcsRunSystem
{
    private EcsFilter<ItemSpawn, ItemStorage, Timer> _spawnFilter;
    private ItemsDatabase _itemsDatabase;

    private Vector3 _defaultRotation = new Vector3(0f, 45f, 0f);
    private Vector3 _defaultDelta = new Vector3(0f, 0.25f, 0f);

    public void Run()
    {
        
        foreach(var index in _spawnFilter)
        {
            ref var timer = ref _spawnFilter.Get3(index);
            if(timer.CurrentTime >= timer.Threshold)
            {
                timer.CurrentTime = 0f;
                ref var spawn = ref _spawnFilter.Get1(index);
                ref var itemStorage = ref _spawnFilter.Get2(index);
                ref var spawnPoint = ref _spawnFilter.Get3(index);   

                if (itemStorage.BoundedStack.Count < itemStorage.BoundedStack.MaxCapacity)
                {
                    var prefab = _itemsDatabase.MappedItems[spawn.Type].View;
                    var deltaMultiplier = itemStorage.BoundedStack.Count;
                    var newItem = Object.Instantiate(prefab, itemStorage.ItemPlace.position + (_defaultDelta * deltaMultiplier), Quaternion.Euler(_defaultRotation));

                    newItem.PositionInStack = deltaMultiplier;

                    newItem.Entity.Replace(new Item 
                    {
                        ItemType = spawn.Type,
                        Cost = _itemsDatabase.MappedItems[spawn.Type].Cost
                    });

                    itemStorage.BoundedStack.Push(newItem.Entity);
                }
            }
        }       
    }
}
