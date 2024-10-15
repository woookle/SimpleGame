using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float onscreenDelay = 1f;
    private void Start()
    {
        Destroy(gameObject, onscreenDelay);
    }
}
