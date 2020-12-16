using System;
using Interfaces;
using UnityEngine;

namespace SpaceShip
{
    public class Player: MonoBehaviour, IMoveable, IRotating, IExecutable, IShooting
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _moveSpeed = 5f;
        private Transform _transform;
        private MousePositionDirection _mousePositionDirection;
        private void Start()
        {
            _transform = gameObject.transform;
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _sprite;
            _mousePositionDirection = new MousePositionDirection(); //хранит в себе камеру и вычисляет текущую позицию и направление
        }

        public void Move(float x, float y)
        {
            var moveVector = new Vector2(x, y) * (_moveSpeed * Time.deltaTime);
            _transform.Translate(moveVector);
        }

        public void Execute()
        {
           var lookDirection = _mousePositionDirection.CalculateLookDirection(Input.mousePosition, _transform);
           Rotate(lookDirection);
        }
        
        public void Rotate(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}