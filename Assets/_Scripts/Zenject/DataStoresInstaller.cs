using FunCraftersTask.Data;
using Zenject;

public class DataStoresInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<DataLoaderDataStore>().AsSingle();
    }
}