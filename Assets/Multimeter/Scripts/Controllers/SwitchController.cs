using Multimeter.Scripts.Enum;
using Multimeter.Scripts.Models;
using UnityEngine;
using Zenject;

namespace Multimeter.Scripts.Controllers
{
    public class RegulatorController : Interactable
    {
        [Inject] private MultimeterModel _multimeter;

        private void Update()
        {
            if (_isFocus)
            {
                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    _multimeter.PreviousPosition = _multimeter.PositionOfSwitch;
                    if (Input.GetAxis("Mouse ScrollWheel") > 0)
                    {
                        if (_multimeter.PositionOfSwitch == Position.Resistance)
                            _multimeter.PositionOfSwitch = Position.Default;
                        else _multimeter.PositionOfSwitch++;
                    }
                    else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                    {
                        if (_multimeter.PositionOfSwitch == Position.Default)
                            _multimeter.PositionOfSwitch = Position.Resistance;
                        else _multimeter.PositionOfSwitch--;
                    }
                    _multimeter.SwitchPosition.Invoke();
                }
            }
        }
    }
}