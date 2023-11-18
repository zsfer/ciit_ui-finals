using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Animate(int animIndex)
    {
        StartCoroutine(_Animate());
        IEnumerator _Animate()
        {
            _anim.SetInteger("Anim", animIndex);
            yield return new WaitForSeconds(1);
            _anim.SetInteger("Anim", 0);
        }
    }
}
