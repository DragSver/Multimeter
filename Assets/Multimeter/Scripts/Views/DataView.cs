using System;
using Multimeter.Scripts.Enum;
using Multimeter.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;

namespace Multimeter.Scripts.Views
{
    public class DataView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _vText;
        [SerializeField] private TextMeshProUGUI _variableText;
        [SerializeField] private TextMeshProUGUI _resistanceText;
        [SerializeField] private TextMeshProUGUI _aText;
        
        [Inject] private MultimeterModel _multimeter;

        private void OnEnable()
        {
            _multimeter.SwitchPosition += SetDataText;
        }

        private void SetDataText()
        {
            ResetData();
            switch (_multimeter.PositionOfSwitch)
            {
                case Position.Default:
                    break;
                case Position.V:
                    _vText.text = $"{_multimeter.V:0.00}";
                    break;
                case Position.Variable:
                    _variableText.text = $"{_multimeter.Variable:0.00}";
                    break;
                case Position.A:
                    _aText.text = $"{_multimeter.A:0.00}";
                    break;
                case Position.Resistance:
                    _resistanceText.text = $"{_multimeter.Resistance:0.00}";
                    break;
            }
        }

        private void ResetData()
        {
            _variableText.text = $"{0:0.00}";
            _vText.text = $"{0:0.00}";
            _aText.text = $"{0:0.00}";
            _resistanceText.text = $"{0:0.00}";
        }
    }
}