using Factories;
using Interfaces;
using UnityEngine;

namespace SpaceShip
{
    public class ShootingController: IExecutable
    {
        private ObjectPooler _objectPooler;
        private Player _player;

        public ShootingController(ObjectPooler objectPooler)
        {
            _objectPooler = objectPooler;
            _player = GameObject.FindObjectOfType<Player>();
        }

        public void Shoot()
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                var rotationPoint = _player.transform.rotation;
                var spawnPoint = _player.transform.position;
                _objectPooler.SpawnFromPool("Bullet", spawnPoint, rotationPoint);
            }
        }
        public void Execute()
        {
            Shoot();
        }
    }
}