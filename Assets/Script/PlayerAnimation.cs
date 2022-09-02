using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator[] _anims;
    [SerializeField] private SpriteRenderer[] _sprites;
    public void OnMove(InputValue value)
    {
        Vector2 velocity = value.Get<Vector2>();
        foreach (Animator anim in _anims)
            anim.SetBool("Walk", velocity != Vector2.zero);
        if (velocity.x < 0)
        {
            foreach (SpriteRenderer spr in _sprites)
                spr.flipX = true;
        }
        else if (velocity.x > 0)
        {
            foreach (SpriteRenderer spr in _sprites)
                spr.flipX = false;
        }
    }

    public void ChangeShirt(AnimatorOverrideController anim)
    {
        _anims[2].runtimeAnimatorController = anim;
    }
}
