using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    [SerializeField] private string _name;
    [SerializeField] private ItemType _type;
    [SerializeField] private ItemView _view;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _sprite;

    public ItemType Type => _type;
    public ItemView View => _view;
    public int Cost => _cost;

    public Sprite Sprite => _sprite;
}