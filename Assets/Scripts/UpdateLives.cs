using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLives : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        UpdatePlayerLives(5);
    }

    public void UpdatePlayerLives(int lives)
    {
        _text.text = "Lives: " + lives;
    }
}
