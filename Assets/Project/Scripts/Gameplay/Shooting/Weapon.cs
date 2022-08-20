using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armyio.Entity;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Armyio.Gameplay
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] [Min(0)] private float _shootingDelay;

        private CancellationTokenSource _tokenSource;
        
        public void StartShooting(IEnumerable<Soldier> soldiers) => 
            Shoot(soldiers, (_tokenSource = new CancellationTokenSource()).Token);

        public void StopShooting() => _tokenSource.Cancel();

        private async UniTaskVoid Shoot(IEnumerable<Soldier> soldiers, CancellationToken token)
        {
            while (soldiers is not null)
            {
                Transform soldier = soldiers.First(i => i is not  null).transform;
                while (soldier is not  null)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    print("Shoot");
                }
            }
        }
    }
}