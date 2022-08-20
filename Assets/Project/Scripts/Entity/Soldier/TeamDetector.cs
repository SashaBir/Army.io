using System;
using System.Collections.Generic;
using UnityEngine;

namespace Armyio.Entity
{
    [RequireComponent(typeof(Collider))]
    public class TeamDetector : MonoBehaviour
    {
        public event Action<IEnumerable<Soldier>> OnEnemyTeamDetected = delegate { }; 
        
        public event Action OnEnemyTeamUndetected = delegate { };

        public ICoreTeamMember CoreTeamMember { private get; set; } = null;

        public void Update()
        {
            if (CoreTeamMember is null)
                return;

            transform.position = CoreTeamMember.Team.PositionCoreTeamMember;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsCoreTeamMember(other.gameObject, out ICoreTeamMember coreTeamMember) == false)
                return;
            
            OnEnemyTeamDetected.Invoke(coreTeamMember.Team.Soldiers);
            Debug.Log("Team is detected!");
        }

        private void OnTriggerExit(Collider other)
        {
            if (IsCoreTeamMember(other.gameObject) == false)
                return;

            OnEnemyTeamUndetected.Invoke();
            Debug.Log("Team is undetected!");
        }

        private bool IsCoreTeamMember(GameObject go)
        {
            if (go.TryGetComponent(out ICoreTeamMember coreTeamMember) == false)
                return false;

            return CoreTeamMember != coreTeamMember;
        }
        
        private bool IsCoreTeamMember(GameObject go, out ICoreTeamMember member)
        {
            member = null;
            if (go.TryGetComponent(out ICoreTeamMember coreTeamMember) == false)
                return false;

            if (CoreTeamMember != coreTeamMember)
            {
                member = coreTeamMember;
                return true;
            }

            return false;
        }
    }
}