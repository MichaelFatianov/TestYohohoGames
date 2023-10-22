using Leopotam.Ecs;
using System.Collections.Generic;
using YohohoTest;

public class StackSystem : IEcsRunSystem, IEcsInitSystem
{
    private EcsFilter<MoneyCase, Pickup> _filter;
    private Settings _settings;

    private Stack<MoneyCase> _stack;

    public void Init()
    {
       _stack = new Stack<MoneyCase>(_settings.StackCapacity);
    }

    public void Run()
    {
        if (!_filter.IsEmpty())
        {
            foreach (var index in _filter)
            {

            }
        }
    }
}
