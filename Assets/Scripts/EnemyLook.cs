using UnityEngine;
using UnityEngine.UI;

public class EnemyLook : MonoBehaviour
{
    public GameObject _player;
    public float EnemySpeed = 3f;
    private int count = 0;
    private int _health = 5;
    public Text _textLose;
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
        if(collision.gameObject.CompareTag("Bullet"))
        {
            _health--;
            if(_health <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            if(count == 5)
            {
                _textLose.text = "Вы проиграли!";
                Time.timeScale = 0;
            }else
            {
                count++;
            }
            
        }
    }
}
