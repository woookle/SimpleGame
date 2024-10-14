using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int _playerHealth = 5;
    private int _score = 0;
    public Text _healthBar;
    public Text _bottomText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Point"))
        {
            if (_score == 4)
            {
                _bottomText.text = "Вы выиграли!";
                _bottomText.fontStyle = FontStyle.Bold;
                Destroy(other.gameObject);
                Time.timeScale = 0;
            }
            else
            {
                _score++;
                _bottomText.text = "Счет: " + _score;
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
                _bottomText.text = "Вы проиграли!";
                _healthBar.text = "";
                Time.timeScale = 0;
            } else
            {
                _healthBar.text = "Жизнь: " + _playerHealth;
            }
        }
    }
}
