using System.Collections.Generic;
using UnityEngine;

namespace Armyio.Entity
{
    public interface ITeam
    {
        IEnumerable<Soldier> Soldiers { get; }
        
        Vector3 PositionCoreTeamMember { get; }
        
        void Add(Soldier soldier);
    }
}