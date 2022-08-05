using System.Collections;
using Armyio.Entity;
using Armyio.InputSystem;
using UnityEngine;
using Zenject;

namespace Armyio.Di
{
    public class PlayerTeamInstaller : MonoInstaller
    {
        [Header("Input System")]
        [SerializeField] private Joystick _joystick;

        public override void InstallBindings()
        {
            BindDirection();
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