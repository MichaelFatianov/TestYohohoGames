using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace YohohoTest
{
    public class PlayerView : EntityView
    {

        [SerializeField] private GameObject _mesh;
        [SerializeField] private int _maxStackCapacity;
        [SerializeField] private Transform _itemsPosition;

        public GameObject Mesh => _mesh; 

        protected override void Initialize(EcsEntity entity)
        {
            entity
                .Replace(new Player())
                .Replace(new PlayerViewRef
                {
                    View = this
                })
                .Replace(new ItemStack
                {
                    Stack = new Stack<EcsEntity>(),
                    ItemPlace = _itemsPosition,
                    MaxCapacity = _maxStackCapacity
                });
         
        }       
    }
}
