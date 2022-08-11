using System;
using UnityEngine;

namespace Armyio.Entity
{
    [Serializable]
    public class SoldierSpawner
    {
        [SerializeField] protected Soldier soldier;

        public virtual Soldier Spawn(Vector3 position) => UnityEngine.Object.Instantiate(soldier, position, Quaternion.identity);
    }
}