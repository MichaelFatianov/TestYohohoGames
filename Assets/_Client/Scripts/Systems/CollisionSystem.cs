
using Leopotam.Ecs;
using UnityEngine;

namespace YohohoTest
{
    public class CollisionSystem : IEcsRunSystem
    {
        private EcsFilter<Collision> _filter;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                ref var collision = ref _filter.Get1(index);
            }
        }
    }
}
