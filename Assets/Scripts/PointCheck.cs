using UnityEngine;
using UnityEngine.UI;

public class PointCheck : MonoBehaviour
{
    private int _score;
    public Text _pointText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Point")
        {
            if(_score == 4)
            {
                _pointText.text = "Вы выиграли!";
                _pointText.fontStyle = FontStyle.Bold;
                Destroy(other.gameObject);
                Time.timeScale = 0;
            }
            else
            {
                _score++;
                _pointText.text = "Счет: " + _score;
                Destroy(other.gameObject);
            }
           
        }
    }
}
