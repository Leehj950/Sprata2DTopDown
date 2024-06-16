using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleControl : MonoBehaviour
{

    [SerializeField] private bool createDustOnWalk = true;
    [SerializeField] private ParticleSystem dustParticleSystem;
    
    public void CreateDustParticles()
    {
        if(createDustOnWalk) 
        {
            //기존에 있는 것을 멈추고 중복 위한 것을 
            dustParticleSystem.Stop();

            // 그리고 다시 시작한다.
            dustParticleSystem.Play();
        }
    }
}
