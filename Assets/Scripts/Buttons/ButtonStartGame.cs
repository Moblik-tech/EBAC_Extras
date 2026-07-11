using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public ParticleSystem buttonParticleSystem;

    private void OnValidate()
    {
        buttonParticleSystem = FindAnyObjectByType<ParticleSystem>().GetComponent<ParticleSystem>();
    }

    public void OnClick(Transform buttonPosition)
    {
        //if (buttonParticleSystem.isPlaying) return;

        buttonParticleSystem.transform.localPosition = buttonPosition.position;
        buttonParticleSystem.Play();
    }
}