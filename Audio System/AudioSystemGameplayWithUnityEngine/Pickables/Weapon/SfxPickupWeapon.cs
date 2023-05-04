using UnityEngine;
using static SkillAbility;

public class SfxPickupWeapon : SfxPickUp
{
    [SerializeField] AudioSource _source;
    [SerializeField] MultiAudioFiles _pickupSfxWeapon;

    protected override void Play(SKILL_TYPE type)
    {
        _source.clip = _pickupSfxWeapon.AudioFile[0];
        var randomPitch = Random.Range(0.95f, 1.1f);
        _source.pitch = randomPitch;
        _source.Play();
    }

}
