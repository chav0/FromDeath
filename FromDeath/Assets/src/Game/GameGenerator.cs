using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject _prefabBlock;
    [SerializeField]
    private Transform _camera;

    private List<Block> _blocks;

    private float _baseLevelComplexity = 10f; 

    private float _deltaYBot = -5.37f;
    private float _deltaYTop = 9f;
    private float _deltaXRight = 3f;
    private float _deltaXLeft = -3f;

    private Sequence _mainSequence;
    private float _deltaTime = 0.15f;
    private float _duration = 0.3f;

    private float _heightBlock = 0.6f;
    private int levels;

    private void Awake()
    {
        _blocks = new List<Block>(); 

        _mainSequence = DOTween.Sequence(); 
        levels = (int) Mathf.Round(Mathf.Abs(_deltaYBot - _deltaYTop) / _heightBlock); 

        for (int i = 0; i < levels; i++)
        {
            var sprite = AddBlock(i).GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, 0f); 

            _mainSequence.Insert(_deltaTime * i, sprite.DOFade(1f, _duration)); 
        }

        _mainSequence.Play(); 
    }

    private GameObject AddBlock(int i)
    {
        var goBlock = Instantiate(_prefabBlock, transform);
        var level = _deltaYBot + i * _heightBlock;
        var block = goBlock.GetComponent<Block>();
        block.SetComplexity (_baseLevelComplexity * (2 / Mathf.Exp(i / 10f) + 1)); 
        block.transform.position = new Vector3(_deltaXLeft + Random.value * Mathf.Abs(_deltaXRight - _deltaXLeft), level, 0f);
        _blocks.Add(block);

        return goBlock; 
    }

    private void DeleteBlock(int i)
    {
        Destroy(_blocks[i].gameObject); 
    }

    void Update () {
        if ((_camera.position.y + _deltaYTop) > _blocks.Count * _heightBlock)
        {
            var sprite = AddBlock(_blocks.Count).GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, 0f);           
            DOTween.Play(sprite.DOFade(1, _duration));
            if (_blocks.Count - levels> 0)
            {
                DeleteBlock(_blocks.Count - levels);
            }
        }
	}
}
