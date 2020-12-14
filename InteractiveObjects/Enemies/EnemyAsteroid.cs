using System;
using System.Security.Cryptography;
using SpaceShip;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;


namespace InteractiveObjects.Enemies
{
    public class EnemyAsteroid : InteractiveObject, IEnemy, IExecutable, ICollisionDamage, IDestroyable, IMoveable
    {
        public EnemyScriptableObject enemyScriptableObject;
        private EnemyData _enemyData;
        private Transform _transform;
        private Transform _playerTransform;
        private Random _random = new Random();
        private float _x;
        private float _y;

        public event EventHandler OnDestroyed;
        
        public void Start () //Метод применяет данные из скриптбл обджекта к инстанту объекта, когда фабрика его спавнит. Скриптабл обджект берется рандомный из списка в геймконтроллере
        {
            _enemyData = new EnemyData(enemyScriptableObject);
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _enemyData._sprite;
            var player = FindObjectOfType<Player>();
            _playerTransform = player.transform;
            var spawnDistanceFromPlayer = new Vector3(Random.Range(-10,10), Random.Range(-10,10), 0f); //убрать хардкод
            _transform = gameObject.transform;
            _transform.position = _playerTransform.position + spawnDistanceFromPlayer; //рандомно вычисляется позиция, в которой спавнится астероид, относительно положения игрока
            _y = Random.Range(-10, 10);//убрать хардкод. Переменные отвечают за направление полета астероида
            _x = Random.Range(-10, 10);
        }


        public int ApplyDamageOnCollision()
        {
            return _enemyData._collisionDamage;
        }

       
        public void Execute()
        {
            Move(_x, _y);
        }

        public void Destroy()
        {
            if (_enemyData._healthPoints <= 0)
            {
                Destroy(gameObject);
                //OnDestroyed?.Invoke(this, EventArgs.Empty);
            }
        }

        public override void Interaction()
        {
            ApplyDamageOnCollision();
            _enemyData._healthPoints = 0;
            Destroy();
        }

        public void Move(float x, float y)
        {
           _transform.Translate(x*_enemyData._moveSpeed*Time.deltaTime, y*_enemyData._moveSpeed*Time.deltaTime, 0f);//Астероиды летят в рандомном направлении
        }
    }
}