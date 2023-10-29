using Leopotam.Ecs;
using UnityEngine;

public class TimerSystem : IEcsRunSystem
{
    private EcsFilter<Timer> _filter;

    public void Run()
    {
        foreach(var index in _filter)
        {
            ref var timer = ref _filter.Get1(index);
            timer.CurrentTime += Time.deltaTime;
        }   
    }
}
