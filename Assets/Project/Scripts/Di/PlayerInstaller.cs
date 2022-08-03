using System.Collections;
using Armyio.Physics;
using UnityEngine;
using Zenject;

namespace Armyio.Di
{
    public class PlayerInstaller : MonoInstaller
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