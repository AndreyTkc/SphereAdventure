using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLives : MonoBehaviour
{
    [SerializeField] private RawImage[] livesIcons;
    [SerializeField] private RawImage[] extraLivesIcons;
    [SerializeField] private RawImage[] inventoryIcons;
    [SerializeField] private RawImage[] extraHpIcon;
    [SerializeField] private Texture emptyLivesIcon;
    [SerializeField] private Texture crystalIcon;
    [SerializeField] private PlayerHealth playerHealth;
    
    private int _maxRegularLives;
    private int _maxInventoryIcons;
    
    private void Awake()
    {
        _maxRegularLives = livesIcons.Length;
        _maxInventoryIcons = inventoryIcons.Length;
        UpdatePlayerLives(playerHealth.health);
    }

    public void UpdatePlayerLives(int lives)
    {
        for (int i = 0; i < _maxRegularLives; i++)
        {
            if (i < lives)
            {
                livesIcons[i].texture = crystalIcon;
                livesIcons[i].enabled = true;
            }
            else
            {
                livesIcons[i].texture = emptyLivesIcon;
                livesIcons[i].enabled = true;
            }
        }
    }

    public void ChangeLivesInInventory(int lives)
    {
        if (lives > 0)
        {
            for (int i = 0; i < _maxInventoryIcons; i++)
            {
                if (i < lives)
                {
                    extraHpIcon[i].enabled = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < _maxInventoryIcons; i++)
            {
                extraHpIcon[i].enabled = false;
            }
        }
    }
}
