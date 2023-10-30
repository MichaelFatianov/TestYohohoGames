using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using YohohoTest;

public class MoneyUI : EntityView
{
    [SerializeField] private TextMeshProUGUI _counter;

    protected override void Initialize(EcsEntity entity)
    {
        entity.Replace(new MoneyUIRef { View = this});
    }

    public void SetCounter(int value)
    {
        _counter.text = value.ToString();
    }
}
