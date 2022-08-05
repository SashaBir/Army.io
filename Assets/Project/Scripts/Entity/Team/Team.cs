﻿using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Armyio.Entity
{
    public abstract class Team : MonoBehaviour
    {
        private readonly IList<Soldier> _soldiers = new List<Soldier>();

        private CoreTeamMember _coreTeamMember;
        
        public void Add(Soldier soldier)
        {
            _soldiers.Add(soldier);
            
            if (_coreTeamMember is null)
                RecalculateCoreTeamMember();
        }

        protected void Move(Vector3 direction)
        {
            foreach (var soldier in _soldiers)
                soldier.Movement.Move(direction);
        }

        private void RecalculateCoreTeamMember()
        {
            if (_soldiers.Count == 1)
            {
                _coreTeamMember = _soldiers[0].AddComponent<CoreTeamMember>();
                return;
            }
        }
    }
}