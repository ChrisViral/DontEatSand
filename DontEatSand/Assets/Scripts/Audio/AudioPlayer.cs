using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DontEatSand.Base;


namespace DontEatSand
{

    /// <summary>
    /// Selections of all sound effects
    /// </summary>
    public enum SoundTrack
    {
        BUILDING_COLLAPSE_01,
        BUILDING_COLLAPSE_02,

        CONSTRUCTION_DEPLOY,
        CONSTRUCTING,

        FEMALE_TEACHER_DIE_01,
        FEMALE_TEACHER_DIE_02,

        HIT_ON_BUILDING_01,
        HIT_ON_BUILDING_02,

        HIT_ON_UNIT,
        
        MELEE_ATTACK,
        RANGE_ATTACK,

        UNIT_DIE_01,
        UNIT_DIE_02,
        UNIT_DIE_03,

    }


    public class AudioPlayer : Singleton<AudioPlayer>
    {

        #region Sound tracks field
        public AudioClip buildingCollapse01;
        public AudioClip buildingCollapse02;
        public AudioClip construction01;
        public AudioClip construction02;
        public AudioClip femaleTeacherDie01;
        public AudioClip femaleTeacherDie02;
        public AudioClip hitOnBuilding01;
        public AudioClip hitOnBuilding02;
        public AudioClip hitOnUnit;
        public AudioClip meleeAttack;
        public AudioClip shootSound;
        public AudioClip unitDie01;
        public AudioClip unitDie02;
        public AudioClip unitDie03;
        #endregion

        #region public methods
        /// <summary>
        /// play specific sound track once
        /// </summary>
        /// <param name="soundTrack"></param>
        /// <param name="position"></param>
        /// <param name="volume"></param>
        public void Play(SoundTrack soundTrack, Vector3 position, float volume)
        {
            AudioClip audioClip = Get(soundTrack);

            if(audioClip != null)
            {
                AudioSource.PlayClipAtPoint(audioClip, position, volume);
            }
        }

        /// <summary>
        /// play specific sound track once at 100% volume
        /// </summary>
        /// <param name="soundTrack"></param>
        /// <param name="position"></param>
        public void Play(SoundTrack soundTrack, Vector3 position)
        {
            play(soundTrack, position, 1.0f);
        }



        #endregion


        #region private/protected methods

        /// <summary>
        /// get specific sound track
        /// </summary>
        /// <param name="soundTrack"></param>
        /// <returns></returns>
        private AudioClip Get(SoundTrack soundTrack)
        {
            switch (soundTrack)
            {
                case SoundTrack.BUILDING_COLLAPSE_01:
                    {
                        return buildingCollapse01;
                    }

                case SoundTrack.BUILDING_COLLAPSE_02:
                    {
                        return buildingCollapse02;
                    }

                case SoundTrack.CONSTRUCTION_DEPLOY:
                    {
                        return construction01;
                    }

                case SoundTrack.CONSTRUCTING:
                    {
                        return construction02;
                    }

                case SoundTrack.FEMALE_TEACHER_DIE_01:
                    {
                        return femaleTeacherDie01;
                    }

                case SoundTrack.FEMALE_TEACHER_DIE_02:
                    {
                        return femaleTeacherDie02;
                    }

                case SoundTrack.HIT_ON_BUILDING_01:
                    {
                        return hitOnBuilding01;
                    }

                case SoundTrack.HIT_ON_BUILDING_02:
                    {
                        return hitOnBuilding02;
                    }

                case SoundTrack.HIT_ON_UNIT:
                    {
                        return hitOnUnit;
                    }

                case SoundTrack.MELEE_ATTACK:
                    {
                        return meleeAttack;
                    }

                case SoundTrack.RANGE_ATTACK:
                    {
                        return shootSound;
                    }

                case SoundTrack.UNIT_DIE_01:
                    {
                        return unitDie01;
                    }

                case SoundTrack.UNIT_DIE_02:
                    {
                        return unitDie02;
                    }

                case SoundTrack.UNIT_DIE_03:
                    {
                        return unitDie03;
                    }
                default:
                    return null;
            }

        }

        #endregion
    }

}
