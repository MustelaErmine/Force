using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Locale/String")]
public class LocaledString : ScriptableObject
{
    [Serializable]
    public struct LocalePair
    {
        public Locale locale;
        [TextArea]
        public string value;
        public LocalePair(Locale locale, string value)
        {
            this.locale = locale;
            this.value = value;
        }
    }
    [Serializable]
    public enum Locale
    {
        ru_RU, en_US
    }
    const Locale currentLocale = Locale.ru_RU;
    [SerializeField]
    public LocalePair[] strings;
    public string this[Locale locale] 
    {
        get {
            foreach (var item in strings) {
                if (item.locale == locale) return item.value;
            }
            return null;
        }
    }
    public string Current { get => this[currentLocale]; }
}