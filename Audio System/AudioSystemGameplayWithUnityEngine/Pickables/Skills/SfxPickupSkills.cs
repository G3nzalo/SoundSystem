using System;
using UnityEngine;
using static SkillAbility;

public class SfxPickupSkills : SfxPickUp
{
    [SerializeField] AudioSource _source;
    [SerializeField] MultiAudioFiles _pickupSfxSkills;

    protected override void Play(SKILL_TYPE type)
    {
        _source.clip = SelectedType(type);
        var randomPitch = UnityEngine.Random.Range(0.9f, 1.1f);
        _source.pitch = randomPitch;
        _source.Play();
    }

    private AudioClip SelectedType(SKILL_TYPE type)
    {
        // After you should change values in array position
        // for diferent type of sfx skills
        switch (type)
        {
            case SKILL_TYPE.offense: return _pickupSfxSkills.AudioFile[0];
            case SKILL_TYPE.defense: return _pickupSfxSkills.AudioFile[0];
            case SKILL_TYPE.strategy: return _pickupSfxSkills.AudioFile[0];
            case SKILL_TYPE.ultimate: return _pickupSfxSkills.AudioFile[0];
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}