using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLives : MonoBehaviour
{
    [SerializeField] private RawImage[] livesIcons;
    [SerializeField] private RawImage[] extraLivesIcons;
    [SerializeField] private Texture emptyLivesIcon;
    
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        UpdatePlayerLives(5);
    }

    public void UpdatePlayerLives(int lives)
    {
        //_text.text = "Lives: " + lives;
        
        for (int i = 0; i < livesIcons.Length; i++)
        {
            if (i < lives)
            {
                livesIcons[i].enabled = true;
            }
            else
            {
                livesIcons[i].texture = emptyLivesIcon;
            }
        }
    }
}
