using Multimeter.Scripts.Enum;
using Multimeter.Scripts.Models;
using UnityEngine;
using Zenject;

namespace Multimeter.Scripts.Views
{
    public class SwitchView : MonoBehaviour
    {
        [SerializeField] private GameObject _switch;

        [Inject] private MultimeterModel _multimeter;
        
        private void OnEnable()
        {
            _multimeter.SwitchPosition += SwitchTransform;
        }

        private void SwitchTransform()
        {
            if ((_multimeter.PreviousPosition == Position.Resistance && 
                _multimeter.PositionOfSwitch == Position.Default) || 
                (_multimeter.PreviousPosition == Position.Default && 
                 _multimeter.PositionOfSwitch == Position.V))
                _switch.transform.Rotate(0, -45, 0);
            else if ((_multimeter.PreviousPosition == Position.Default && 
                     _multimeter.PositionOfSwitch == Position.Resistance) || 
                     (_multimeter.PreviousPosition == Position.V && 
                      _multimeter.PositionOfSwitch == Position.Default))
                _switch.transform.Rotate(0, 45, 0);
            else if (_multimeter.PreviousPosition < _multimeter.PositionOfSwitch)
                _switch.transform.Rotate(0, -90, 0);
            else _switch.transform.Rotate(0, 90, 0);
        }
    }
}