using DG.Tweening;
using UnityEngine;

public class SphereAnimations : MonoBehaviour
{
    private Transform sphere;
    private Tween idleAnimation;
    private Tween destroyAnimation;

    [SerializeField] GameObject destroyParticle;

    private void Awake()
    {
        sphere = transform;


        idleAnimation = sphere.transform.DOScale(Vector3.one * 1.2f, Random.Range(0.5f, 2)).SetLoops(-1, LoopType.Yoyo);//анимация сферы в покое
    }

    private void OnMouseDown()
    {
        DestroySphere();
    }

    private void DestroySphere()//анимация лопания сферы
    {
        idleAnimation.Kill();
        destroyAnimation = sphere.transform.DOScale(Vector3.one * 1.7f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            destroyAnimation.Kill();
            Destroy(Instantiate(destroyParticle, sphere.position, Quaternion.identity), 2);
            Destroy(gameObject);
        });
    }

}
