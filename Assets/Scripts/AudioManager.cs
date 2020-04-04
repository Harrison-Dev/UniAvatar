using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace UniAvatar
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        [SerializeField] private AudioClip m_defaultBGM;
        private AudioSource m_soundEffectSource;
        private AudioSource m_bgmSource;

        private void Start()
        {
            var seObj = new GameObject();
            seObj.transform.SetParent(this.transform);
            m_soundEffectSource = seObj.AddComponent<AudioSource>();

            var bgmObj = new GameObject();
            bgmObj.transform.SetParent(this.transform);
            m_bgmSource = bgmObj.AddComponent<AudioSource>();

            if (m_defaultBGM)
            {
                PlayBGM(m_defaultBGM);
            }
        }

        public void PlaySE(AudioClip se)
        {
            m_soundEffectSource.PlayOneShot(se);
        }

        public void PlayBGM(AudioClip bgm)
        {
            // Fade out previous BGM & fade in next.
            if (m_bgmSource.isPlaying)
            {
                var sequence = DOTween.Sequence();
                sequence.Append(m_bgmSource.DOFade(0, 0.5f));
                sequence.AppendCallback(() => m_bgmSource.clip = bgm);
                sequence.Append(m_bgmSource.DOFade(1, 0.5f));
                sequence.Play();
            }
            else
            {
                m_bgmSource.clip = bgm;
                m_bgmSource.Play();
            }
        }


    }
}