using UnityEngine;

namespace Armyio.Entity
{
    /*
     * Test class
     */
    public class SoldierSpawner : MonoBehaviour
    {
        [SerializeField] private Team _team;
        [SerializeField] private Soldier _soldier;

        private void Awake()
        {
            //_team.Add(_soldier);
        }
    }
}