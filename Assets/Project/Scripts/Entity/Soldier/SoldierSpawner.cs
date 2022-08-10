using System;
using UnityEngine;

namespace Armyio.Entity
{
    [Serializable]
    public class SoldierSpawner
    {
        [SerializeField] private Soldier _soldier;

        public Soldier Spawn(Transform container) => UnityEngine.Object.Instantiate(_soldier, container.position + new Vector3(2, 0, 2), Quaternion.identity);
    }
}