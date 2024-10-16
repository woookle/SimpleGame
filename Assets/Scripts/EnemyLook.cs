using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    public GameObject _player;
    public float EnemySpeed = 3f;
    public GameObject _healthBarCube;
    public Material[] healthList;
    private int _health = 5;

    public PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(_player.transform.position, transform.position);
        if(dist < 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, EnemySpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health--;

            if (_health <= 0)
            {
                playerHealth.killFunction();
                Destroy(gameObject);

            } else if (_health <= 1)
            {
                _healthBarCube.GetComponent<MeshRenderer>().material = healthList[1];
            } else if (_health <= 3)
            {
                _healthBarCube.GetComponent<MeshRenderer>().material = healthList[0];
            }

            Destroy(collision.gameObject);
        }
    }
}
