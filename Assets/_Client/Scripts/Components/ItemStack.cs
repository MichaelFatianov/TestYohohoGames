using Leopotam.Ecs;
using UnityEngine;

namespace YohohoTest
{
    public struct ItemStorage
    {
        public BoundedStack<EcsEntity> BoundedStack;
        public Transform ItemPlace;
    }
}
