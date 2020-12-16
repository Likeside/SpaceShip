using UnityEngine;

namespace Factories
{
    [CreateAssetMenu(menuName = "Pool SO", fileName = "New Pool SO")]
    public class PoolScriptableObject: ScriptableObject
    {
        public string tag;
        public GameObject gameObjPrefab;
        public int size;
    }
}