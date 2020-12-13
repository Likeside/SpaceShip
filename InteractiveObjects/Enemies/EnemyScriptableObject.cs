using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractiveObjects.Enemies
{
    [CreateAssetMenu(menuName = "Enemy SO", fileName = "New Enemy SO")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public Sprite sprite;
        public float moveSpeed;
        public int healthPoints;
        public int collisionDamage;
    }

}
