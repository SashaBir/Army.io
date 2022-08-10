using UnityEngine;

namespace Armyio.Entity
{
    public interface ITeam
    {
        Transform Container { get; }
        
        void Add(Soldier soldier);
    }
}