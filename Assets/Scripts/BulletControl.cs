using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float onscreenDelay = 3f;
    private void Start()
    {
        Destroy(gameObject, onscreenDelay);
    }
}
