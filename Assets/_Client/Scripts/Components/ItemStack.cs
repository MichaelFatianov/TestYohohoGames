using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace YohohoTest
{
    public struct ItemStack
    {
        public Stack<EcsEntity> Stack;
        public Transform ItemPlace;
        public int MaxCapacity;
        public int CurrentAmount;
    }
}
