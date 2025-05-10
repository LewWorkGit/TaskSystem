using UnityEngine;
using Zenject;

public class RedSphere : MonoBehaviour
{

    [Inject] SphereController sphereController;
    private void OnDestroy()
    {
        sphereController.SphereDestroy();
        sphereController.RedSphereDestroy();

    }
}
