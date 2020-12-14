using UnityEngine;

namespace InteractiveObjects.Enemies
{
    public class EnemyData
    {
        public Sprite _sprite;
        public float _moveSpeed;
        public int _healthPoints;
        public int _collisionDamage;


        public EnemyData(EnemyScriptableObject enemyScriptableObject)
        {
            _sprite = enemyScriptableObject.sprite;
            _moveSpeed = enemyScriptableObject.moveSpeed;
            _healthPoints = enemyScriptableObject.healthPoints;
            _collisionDamage = enemyScriptableObject.collisionDamage;
        }
        
        //На всякий случай конструктор без скриптабл обджекта
        public EnemyData(Sprite sprite, float moveSpeed, int healthPoints, int collisionDamage)
        {
            _sprite = sprite;
            _moveSpeed = moveSpeed;
            _healthPoints = healthPoints;
            _collisionDamage = collisionDamage;
        }
    }
}