using UnityEngine;

class SoundSource : MonoBehaviour
{
    private AudioSource audioSource;

    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance)
    {
        // 첫 쓸때는 널이 되어있을때 사용
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        CancelInvoke();
        audioSource.clip = clip;
        audioSource.volume = soundEffectVolume;
        audioSource.Play();
        audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);

        Invoke("Disable", clip.length + 2);
    }

    public void Disable()
    {
        audioSource.Stop();
        gameObject.SetActive(false);
    }
}