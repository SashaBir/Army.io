using System;
using System.Collections.Generic;
using UnityEngine;

namespace Armyio.Entity
{
    public abstract class Team : MonoBehaviour
    {
        private readonly IList<ISoldier> _soldiers = new List<ISoldier>();

        public abstract bool IsStanding { get; }
        
        public void Add(ISoldier soldier) => _soldiers.Add(soldier);

        protected void Move(Vector3 direction)
        {
            foreach (var soldier in _soldiers)
                soldier.Movement.Move(direction);
        }
    }
}