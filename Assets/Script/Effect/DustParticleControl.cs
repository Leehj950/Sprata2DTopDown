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
            //������ �ִ� ���� ���߰� �ߺ� ���� ���� 
            dustParticleSystem.Stop();

            // �׸��� �ٽ� �����Ѵ�.
            dustParticleSystem.Play();
        }
    }
}
