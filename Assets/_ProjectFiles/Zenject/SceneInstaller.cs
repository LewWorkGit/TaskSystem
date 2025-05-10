using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private SphereController sphereController;
    [SerializeField] private RedSphereTaskModel redSphereTaskModel;
    [SerializeField] private AnySphereTaskModel anySphereTaskModel;
    [SerializeField] private TimerTaskModel timerTaskModel;

    public override void InstallBindings()
    {
        Container.Bind<SphereController>()
            .FromInstance(sphereController)
            .AsSingle();

        Container.Bind<RedSphereTaskModel>()
           .FromInstance(redSphereTaskModel)
           .AsSingle();

        Container.Bind<AnySphereTaskModel>()
          .FromInstance(anySphereTaskModel)
          .AsSingle();

        Container.Bind<TimerTaskModel>()
        .FromInstance(timerTaskModel)
        .AsSingle();
    }

}
