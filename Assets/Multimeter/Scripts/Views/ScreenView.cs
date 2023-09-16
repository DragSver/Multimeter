using Multimeter.Scripts.Enum;
using Multimeter.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;

namespace Multimeter.Scripts.Views
{
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _screenText;

        [Inject] private MultimeterModel _multimeter;
        
        private void OnEnable()
        {
            _multimeter.SwitchPosition += SetScreenText;
        }

        private void SetScreenText()
        {
            switch (_multimeter.PositionOfSwitch)
            {
                case Position.Default:
                    _screenText.text = $"{0:0.00}";
                    break;
                case Position.V:
                    _screenText.text = $"{_multimeter.V:0.00}";
                    break;
                case Position.Variable:
                    _screenText.text = $"{_multimeter.Variable:0.00}";
                    break;
                case Position.A:
                    _screenText.text = $"{_multimeter.A:0.00}";
                    break;
                case Position.Resistance:
                    _screenText.text = $"{_multimeter.Resistance:0.00}";
                    break;
            }
        }
    }
}