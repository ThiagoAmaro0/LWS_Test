using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _baseAnim;
    [SerializeField] private Animator _hairAnim;
    [SerializeField] private Animator _hatAnim;
    [SerializeField] private Animator _shirtAnim;
    [SerializeField] private Animator _pantsAnim;
    [SerializeField] private Animator _shoesAnim;
    [SerializeField] private SpriteRenderer[] _sprites;
    private Animator[] _anims;

    private void Start()
    {
        _anims = new Animator[]{
            _baseAnim,_hairAnim,_hatAnim,_shirtAnim,_pantsAnim,_shoesAnim
        };
        PlayerInventory.instance.updateOutfitAction?.Invoke();
    }

    private void OnEnable()
    {
        PlayerInventory.instance.updateOutfitAction += UpdateOutfit;
    }
    private void OnDisable()
    {
        PlayerInventory.instance.updateOutfitAction -= UpdateOutfit;
    }

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

    public void UpdateOutfit()
    {
        if (PlayerInventory.instance.GetHat() != null)
        {
            _hatAnim.gameObject.SetActive(true);
            _hatAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(PlayerInventory.instance.GetHat().name);
        }
        else
        {
            _hatAnim.gameObject.SetActive(false);
        }

        _hairAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(PlayerInventory.instance.GetHair().name);
        _shirtAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(PlayerInventory.instance.GetShirt().name);
        _pantsAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(PlayerInventory.instance.GetPants().name);
        _shoesAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(PlayerInventory.instance.GetShoes().name);
    }
}
