using System;
using Interfaces;
using Unity.Mathematics;
using UnityEngine;

namespace SpaceShip
{
    public class Player: MonoBehaviour, IMoveable
    {
        [SerializeField] private Sprite _sprite;
        private Transform _transform;
        private float _moveSpeed = 5f;
        
        private void Start()
        {
            _transform = gameObject.transform;
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _sprite;
        }

        public void Move(float x, float y)
        {
           // var moveVector = transform.forward * y + Quaternion.AngleAxis(90.0f, Vector3.up) * transform.forward * x;
            var moveVector = new Vector2(x, y) * (_moveSpeed * Time.deltaTime);
            var angle = Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg;
            _transform.Rotate(0, 0, angle*Time.deltaTime);
           _transform.Translate(moveVector);
           
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}