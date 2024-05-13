using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected TopDownController topDownController;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        topDownController = GetComponent<TopDownController>();
    }
}

