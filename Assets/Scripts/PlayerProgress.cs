using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerProgress : MonoBehaviour
{
    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private int _levelValue = 1;

    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;

    public List<PlayerProgressLevel> levels;
    // Start is called before the first frame update
    void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }
    private void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel = levels[_levelValue - 1];
        _experienceTargetValue = currentLevel.experienceForTheNextLevel;
        GetComponent<BulletCast>().damage = currentLevel.fireballDamage;

        var grenadeCaster = GetComponent<GrenadeCaster>();
        grenadeCaster.damage = currentLevel.grenadeDamage;

        if (currentLevel.grenadeDamage < 0)
            grenadeCaster.enabled = false;
        else
            grenadeCaster.enabled = true;
    }
}
