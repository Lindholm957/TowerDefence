using Data;
using Events.Base;
using Events.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private Upgrade.Type type;
        [SerializeField] private TMP_Text lvlText;

        private int _maxLevelUpgradeLimit = 3;
        private int _curLevelUpgrades = 1;
        
        private void OnEnable()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Game.Over, OnGameOver);
            GlobalEventSystem.I.Subscribe(EventNames.Game.Restarted, OnGameRestarted);
        }

        private void OnGameOver(GameEventArgs arg0)
        {
            GetComponent<Button>().interactable = false;
        }

        private void OnGameRestarted(GameEventArgs arg)
        {
            GetComponent<Button>().interactable = true;
            _curLevelUpgrades = 1;
            lvlText.text = "1";
        }

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
        
        private void OnDisable()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Game.Over, OnGameOver);
            GlobalEventSystem.I.Unsubscribe(EventNames.Game.Restarted, OnGameRestarted);
        }
    }
}
