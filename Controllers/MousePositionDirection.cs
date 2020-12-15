using Interfaces;
using UnityEngine;

namespace SpaceShip
{
    public class MousePositionDirection
    {
        private Vector3 _targetPos;
        private Vector3 _lookDirection;
        private Camera _camera;
        
        public MousePositionDirection()
        {
            _camera = Camera.main;
        }

        public Vector3 CalculateLookDirection(Vector3 lookingAt, Transform positionsAt)
        {
            _targetPos = _camera.ScreenToWorldPoint(lookingAt);
            _lookDirection = _targetPos - positionsAt.position;
            return _lookDirection;
        }

    }
}