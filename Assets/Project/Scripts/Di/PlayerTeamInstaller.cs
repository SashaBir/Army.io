using Armyio.Entity;
using Armyio.InputSystem;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Armyio.Di
{
    public class PlayerTeamInstaller : MonoInstaller
    {
        [Header("Spawner for first player's unit")]
        [SerializeField] private PlayerTeam _playerTeam;
        [SerializeField] private Transform _spawnpoint;
        [SerializeField] private Soldier _soldier;

        [Header("Input System")]
        [SerializeField] private Joystick _joystick;

        [Header("Camera")]
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public override void InstallBindings()
        {
            BindCinemachineVirtualCamera();
            BindDirection();
            
            SpawnPlayerTeamAndPlayer();
        }

        private void SpawnPlayerTeamAndPlayer()
        {
            PlayerTeam playerTeam = Container.InstantiatePrefabForComponent<PlayerTeam>(_playerTeam, _spawnpoint);
            Soldier soldier = Instantiate(_soldier, _spawnpoint.position, Quaternion.identity);
            playerTeam.Add(soldier);
        }

        private void BindCinemachineVirtualCamera()
        {
            Container
                .Bind<CinemachineVirtualCamera>()
                .FromInstance(_cinemachineVirtualCamera)
                .AsSingle()
                .NonLazy();
        }

        private void BindDirection()
        {
            Container
                .Bind<IDirection>()
                .FromInstance(_joystick)
                .AsSingle()
                .NonLazy();
        }
    }
}