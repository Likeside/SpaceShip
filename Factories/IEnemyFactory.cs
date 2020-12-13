using Interfaces;
using UnityEngine;

namespace Factories
{
    public interface IEnemyFactory
    {
        IEnemy GetEnemy();
    }
}