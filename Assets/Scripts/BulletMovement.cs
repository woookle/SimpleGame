using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;
    public float shootForce;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 2f));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);
        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;
        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);
        currentBullet.transform.forward = dirWithoutSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithoutSpread.normalized * shootForce, ForceMode.Impulse);
    }
}
