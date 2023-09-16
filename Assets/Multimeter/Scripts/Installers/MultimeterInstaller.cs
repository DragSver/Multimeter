using Multimeter.Scripts.Models;
using Zenject;

namespace Multimeter.Scripts.Installers
{
    public class MultimeterInstaller : MonoInstaller
    {
        private MultimeterModel _multimeter;
        public override void InstallBindings()
        {
            _multimeter = new MultimeterModel();
            Container.Bind<MultimeterModel>().FromInstance(_multimeter).AsSingle().NonLazy();
        
            _multimeter.Resistance = 1000;
            _multimeter.Power = 400;
        }
    }
}