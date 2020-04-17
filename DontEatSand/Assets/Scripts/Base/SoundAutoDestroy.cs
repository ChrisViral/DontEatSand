using System.Collections;
using DontEatSand.Utils;
using Photon.Pun;
using UnityEngine;

namespace DontEatSand.Base
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundAutoDestroy : MonoBehaviourPun
    {
        #region Functions
        private IEnumerator Start()
        {
            //Check clip length
            AudioClip clip = GetComponent<AudioSource>().clip;
            if (!clip)
            {
                PhotonUtils.Destroy(this);
                yield break;
            }

            //Delayed destruction
            yield return new WaitForSeconds(clip.length);
            PhotonUtils.Destroy(this);
        }
        #endregion
    }
}
