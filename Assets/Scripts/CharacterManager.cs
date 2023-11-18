using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] GameObject[] _modelPrefabs;

    [SerializeField] Transform _characterPoint;

    [Header("Animation")]
    [SerializeField] float _animSpeed = 0.5f;

    GameObject _character;

    void Start()
    {
        SwitchCharacter(0);
    }

    public void SwitchCharacter(int modelIndex)
    {
        if (_character != null)
            Destroy(_character);

        _character = Instantiate(_modelPrefabs[modelIndex], _characterPoint);
        _character.transform.localRotation = Quaternion.identity;
        _character.transform.localScale /= 2;
    }

    public void Rotate()
    {
        var trgRot = _characterPoint.transform.rotation.eulerAngles + (Vector3.up * 90);
        _characterPoint.DORotate(trgRot, _animSpeed);
    }

    public void Scale()
    {
        // toggles between random scale and normal scale (so u can reset it)
        var rndScale = _characterPoint.localScale == Vector3.one ? Random.Range(0.1f, 2) : 1;
        _characterPoint.DOScale(rndScale, _animSpeed);
    }

    public void ChangeColor()
    {
        _character.GetComponentInChildren<SkinnedMeshRenderer>().materials.LastOrDefault().color = Random.ColorHSV();
    }

    public void PlayAnimation(int animIndex)
    {
        _character.GetComponent<Character>().Animate(animIndex);
    }
}
