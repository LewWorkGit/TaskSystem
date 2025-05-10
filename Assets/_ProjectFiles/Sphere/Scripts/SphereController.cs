using System;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public event Action OnAnySphereDestroy;
    public event Action OnRedSphereDestroy;
    public event Action OnBlueSphereDestroy;

    public void SphereDestroy()
    {
        OnAnySphereDestroy?.Invoke();
    }

    public void RedSphereDestroy()
    {
        OnRedSphereDestroy?.Invoke();
    }

    public void BlueSphereDestroy()
    {
        OnBlueSphereDestroy?.Invoke();
    }
}
