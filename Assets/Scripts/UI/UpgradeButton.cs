using Game.Data;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private Upgrade.Type type;
        [SerializeField] private TMP_Text lvlText;

        private int _maxLevelUpgradeLimit = 3;
        private int _curLevelUpgrades = 1;

        public void OnClick()
        {
            if (_curLevelUpgrades < _maxLevelUpgradeLimit)
            {
                PlayerData.I.UpgradeLvlUp(type);
                UpdateText();
                
                _curLevelUpgrades++;
            }
        }

        private void UpdateText()
        {
            switch (type)
            {
                case Upgrade.Type.TotalDame:
                    lvlText.text = PlayerData.I.TotalDamageLvl.ToString();
                    break; 
                case Upgrade.Type.AttackSpeed:
                    lvlText.text = PlayerData.I.AttackSpeedLvl.ToString();
                    break;
                case Upgrade.Type.AttackDistance:
                    lvlText.text = PlayerData.I.AttackDistanceLvl.ToString();
                    break;
            }
        }
    }
}
