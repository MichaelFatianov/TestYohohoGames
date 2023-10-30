using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;
using YohohoTest;

public class ItemUI : EntityView
{
    [SerializeField] private Image _itemImage;

    [SerializeField] private int _position;

    protected override void Initialize(EcsEntity entity)
    {
        entity.Replace(new ItemUIRef 
        { 
            View = this,
            Position = _position,
        });
    }

    public void SetSprite(Sprite sprite)
    {
        _itemImage.sprite = sprite;
        _itemImage.color = Color.white;
    }

    public void ResetSprite()
    {
        _itemImage.sprite = null;
        _itemImage.color = Color.clear;
    }
}
