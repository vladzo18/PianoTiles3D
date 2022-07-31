using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI 
{
    public class InfoBar : MonoBehaviour 
    {
        [SerializeField] private List<InfoItem> _infoItems = default;

        public void AddPoints(InfoItemType infoItemType, int value) 
        {
            InfoItem item = _infoItems.Find(i => i.InfoItemType == infoItemType);
            item.Value = value;
        }

        public int GetValueOf(InfoItemType infoItemType) 
        {
            InfoItem item = _infoItems.Find(i => i.InfoItemType == infoItemType);
            return item.Value;
        }
        
        
        [Serializable]
        private class InfoItem 
        {
            public InfoItemType InfoItemType = InfoItemType.None;
            public TMP_Text TextField = default;

            public int Value 
            {
                get => int.Parse(TextField.text);
                set => TextField.text = value.ToString();
            }
        }
    }

    public enum InfoItemType 
    {
        None,
        Health,
        MelodyPoint,
        Diamond
    }
}