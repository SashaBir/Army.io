using System;
using System.Collections.Generic;
using UnityEngine;

namespace Armyio.Entity
{
    public class Team : MonoBehaviour, ITeam
    {
        [SerializeField] private TeamDetector _teamDetector;
        
        private readonly List<Soldier> _soldiers = new List<Soldier>();

        protected CoreTeamMember coreTeamMember;

        public IEnumerable<Soldier> Soldiers => _soldiers;
        
        public Vector3 PositionCoreTeamMember => coreTeamMember.transform.position;

        private void OnEnable()
        {
            _teamDetector.OnEnemyTeamDetected += StartAttacking;
            _teamDetector.OnEnemyTeamUndetected += StopAttacking;
        }

        private void OnDisable()
        { 
            _teamDetector.OnEnemyTeamDetected -= StartAttacking;
            _teamDetector.OnEnemyTeamUndetected -= StopAttacking;
        }

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
            coreTeamMember.Team = this;

            _teamDetector.CoreTeamMember = coreTeamMember;
        }

        private Soldier FindCentreSoldier()
        {
            if (_soldiers.Count == 1)
                return _soldiers[0];

            return null;
        }

        private void StartAttacking(IEnumerable<Soldier> soldiers)
        {
            _soldiers.TrimExcess();
            foreach (var soldier in _soldiers)
                soldier.Weapon.StartShooting(soldiers);
        }
        
        private void StopAttacking()
        {
            _soldiers.TrimExcess();
            foreach (var soldier in _soldiers)
                soldier.Weapon.StopShooting();
        }
    }
}