using Events.Base;
using Events.Systems;
using UnityEngine;

namespace Game.Data
{
    public class PlayerData : MonoBehaviour
    {
        public static PlayerData I { get; set; }

        private int _totalDamageLvl = 1;
        private int _attackSpeedLvl = 1;
        private int _attackDistanceLvl = 1;
        
        public int TotalDamageLvl => _totalDamageLvl;
        public int AttackSpeedLvl => _attackSpeedLvl;
        public int AttackDistanceLvl => _attackDistanceLvl;

        private void Awake()
        {
            I = this;
        }

        private void OnEnable()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Game.Restarted, OnGameRestarted);
        }

        private void OnGameRestarted(GameEventArgs arg)
        {
            ResetLvlData();
        }

        public void UpgradeLvlUp(Upgrade.Type type)
        {
            switch (type)
            {
                case Upgrade.Type.TotalDame:
                    _totalDamageLvl += 1;
                    break;
                case Upgrade.Type.AttackSpeed:
                    _attackSpeedLvl += 1;
                    break;
                case Upgrade.Type.AttackDistance:
                    _attackDistanceLvl += 1;
                    break;
            }
        }

        private void ResetLvlData()
        {
            _totalDamageLvl = 1;
            _attackSpeedLvl = 1;
            _attackDistanceLvl = 1;
        }
        
        private void OnDisable()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Game.Restarted, OnGameRestarted);
        }
    }
}