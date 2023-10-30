using Leopotam.Ecs;
using UnityEngine;

namespace YohohoTest
{
    public class PlayerView : EntityView
    {

        [SerializeField] private GameObject _mesh;
        [SerializeField] private int _maxCapacity;
        [SerializeField] private Transform _itemsPosition;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Animator _animator;


        public GameObject Mesh => _mesh;

        public CharacterController Controller => _controller;

        public Animator Animator => _animator;

        protected override void Initialize(EcsEntity entity)
        {
            entity
                .Replace(new Player())
                .Replace(new PlayerViewRef
                {
                    View = this
                })
                .Replace(new ItemStorage
                {
                    BoundedStack = new BoundedStack<EcsEntity>("Player", _maxCapacity),
                    ItemPlace = _itemsPosition
                });
         
        }       
    }
}
