using UnityEngine;

namespace Armyio.Entity
{
    [RequireComponent(typeof(AiTeam))]
    public class AiTeamStarter : MonoBehaviour
    {
        [SerializeField] private Soldier _soldier;

        private AiTeam _team;
        
        private void Awake()
        {
            Soldier soldier = Instantiate(_soldier, transform.position, Quaternion.identity);
            _team = GetComponent<AiTeam>();
            _team.Add(soldier);
        }
    }
}