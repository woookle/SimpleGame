using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int _playerHealth = 5;
    private int _score = 0;
    private int _kills = 0;
    public Text _killCounter;
    public Text _healthBar;
    public Text _bottomText;

    public void killFunction()
    {
        _kills++;
        _killCounter.text = "”бийств: " + _kills;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Point"))
        {
            if (_score == 4)
            {
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(3);
            }
            else
            {
                _score++;
                _bottomText.text = "—чет: " + _score;
                Destroy(other.gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            _playerHealth--;
            if (_playerHealth <= 0)
            {
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(1);
            } else
            {
                _healthBar.text = "∆изнь: " + _playerHealth;
            }
        }
    }
}
