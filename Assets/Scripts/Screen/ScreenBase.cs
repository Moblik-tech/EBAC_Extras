using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using NaughtyAttributes;

namespace Screens
{
    public enum ScreenType
    {
        MainPanel,
        FacebookPanel,
        MissionPanel,
        MessagesPanel,
        RankingPanel,
        ProfilePanel,
        ShopPanel,
        SettingsPanel
    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listOfObjects;
        public Image uIBackground;
        public bool startHided = false;

        [Space(15)]

        public List<Typer> listOfPhrases;

        [Header("Animation")]
        public float animationDuration = 0.3f;
        public float delayBetweenObjects = 0.05f;

        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }

        [Button]
        public virtual void Show()
        {
            if (!UnityEditor.EditorApplication.isPlaying) return;
            Debug.Log("Show");
            ShowObjects();
        }

        [Button]
        public virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");
        }

        private void ShowObjects()
        {
            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);

            for (int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            uIBackground.enabled = true;
        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartTyping();
            }
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
            uIBackground.enabled = true;
        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
            uIBackground.enabled = false;
        }
    }
}