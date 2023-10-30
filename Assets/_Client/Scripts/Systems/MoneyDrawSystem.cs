using Leopotam.Ecs;
using YohohoTest;

public class MoneyDrawSystem : IEcsRunSystem
{

    private EcsFilter<PlayerAccount> _accoutFilter;
    private EcsFilter<MoneyUIRef> _moneyFilter;
    public void Run()
    {
        ref var moneyUI = ref _moneyFilter.Get1(0).View;
        ref var account = ref _accoutFilter.Get1(0);

        moneyUI.SetCounter(account.MoneyValue);
    }
}
