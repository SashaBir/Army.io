using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Armyio.Entity
{
    public class Team : MonoBehaviour
    {
        private readonly IList<Soldier> _soldiers = new List<Soldier>();

        protected CoreTeamMember coreTeamMember;

        public void Add(Soldier soldier)
        {
            _soldiers.Add(soldier);
            soldier.transform.SetParent(transform);
            
            if (coreTeamMember is null)
                RecalculateCoreTeamMember();
        }

        protected void Move(Vector3 direction)
        {
            if (_soldiers.Count == 0)
                return;
            
            foreach (var soldier in _soldiers)
                soldier.Movement.Move(direction);
        }

        protected virtual void RecalculateCoreTeamMember()
        {
            Soldier soldier = FindCentreSoldier();   
            coreTeamMember = soldier.gameObject.AddComponent<CoreTeamMember>();
            coreTeamMember.MovementMode = soldier.Movement;
        }

        private Soldier FindCentreSoldier()
        {
            if (_soldiers.Count == 1)
                return _soldiers[0];

            return null;
        }
    }
}