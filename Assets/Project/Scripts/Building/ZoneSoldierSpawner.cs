using System;
using System.Threading;
using Armyio.Entity;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Armyio.Building
{
    [RequireComponent(typeof(ZoneDetector))]
    public class ZoneSoldierSpawner : MonoBehaviour
    {
        [SerializeField] private SoldierSmartSpawner _soldierSmartSpawner;
        [SerializeField] [Min(0)] private float _delayAfterSpawning;

        private ZoneDetector _zoneDetector;
        private CancellationTokenSource _tokenSource;

        private void Awake() => _zoneDetector = GetComponent<ZoneDetector>();

        private void OnEnable()
        {
            _zoneDetector.OnStarted += StartSpawning;
            _zoneDetector.OnEnded += StopSpawning;
        }

        private void OnDisable()
        {
            _zoneDetector.OnStarted -= StartSpawning;
            _zoneDetector.OnEnded -= StopSpawning;
        }

        private void StartSpawning(ITeam team) => Spawn(team, (_tokenSource = new CancellationTokenSource()).Token).Forget();

        private void StopSpawning() => _tokenSource.Cancel();

        private async UniTaskVoid Spawn(ITeam team, CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
            {
                if (team is null)
                    return;

                Soldier soldier = _soldierSmartSpawner.Spawn(team.PositionCoreTeamMember);
                team.Add(soldier);

                await UniTask.Delay(TimeSpan.FromSeconds(_delayAfterSpawning), cancellationToken: token);
            }
        }
    }
}