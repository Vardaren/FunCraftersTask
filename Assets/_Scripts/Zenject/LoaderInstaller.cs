using FunCraftersTask.Data;
using UnityEngine;
using Zenject;

public class LoaderInstaller : MonoInstaller {
    [SerializeField] DataLoader dataLoader;
    public override void InstallBindings() {
        Container.BindInstance(dataLoader).AsSingle();
    }
}