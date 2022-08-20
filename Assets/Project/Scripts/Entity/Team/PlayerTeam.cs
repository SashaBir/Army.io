using Armyio.InputSystem;
using Cinemachine;
using Zenject;

namespace Armyio.Entity
{
    public class PlayerTeam : Team
    {
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        private IDirection _direction;
        
        [Inject]
        private void Construct(CinemachineVirtualCamera cinemachineVirtualCamera, IDirection direction)
        {
            _cinemachineVirtualCamera = cinemachineVirtualCamera;
            _direction = direction;
        }

        private void Update()
        {
            /*
            Vector3 direction = _direction.Direction;
            if (direction == Vector3.zero)
                return;
            */
            
            Move(_direction.Direction);
        }

        protected override void RecalculateCoreTeamMember()
        {
            base.RecalculateCoreTeamMember();
            AimCamera();
        }

        private void AimCamera()
        {
            _cinemachineVirtualCamera.Follow = coreTeamMember.transform;
            _cinemachineVirtualCamera.LookAt = coreTeamMember.transform;
        }
    }
}