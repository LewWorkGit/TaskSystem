using UnityEngine;
using Zenject;

public class BlueSphere : MonoBehaviour
{
    [Inject] SphereController sphereController;
    private void OnDestroy()
    {
        sphereController.SphereDestroy();
        sphereController.BlueSphereDestroy();

    }
}
