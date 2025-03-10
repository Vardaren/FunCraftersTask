using FunCraftersTask.Data;
using Zenject;

public class HelpersInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<DataLoaderHelper>().AsSingle();
    }
}