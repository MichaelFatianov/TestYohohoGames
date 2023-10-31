using Leopotam.Ecs;
using UnityEngine;

public class TradeSystem : IEcsRunSystem
{

    private EcsFilter<TradeOperation> _filter;
    private EcsFilter<PlayerAccount> _accountFilter;

    public void Run()
    {
        ref var playerAccount = ref _accountFilter.Get1(0);

        foreach(var index in _filter)
        {
            ref var tradeOperation = ref _filter.Get1(index);
            playerAccount.MoneyValue += tradeOperation.Value;
        }
    }
}
