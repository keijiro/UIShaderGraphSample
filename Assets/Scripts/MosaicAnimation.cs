using UnityEngine;
using UnityEngine.UI;

public sealed class MosaicAnimation : MonoBehaviour
{
    Material _material;
    float _param;
    bool _reveal;

    public void Toggle() => _reveal = !_reveal;

    Image Target => GetComponent<Image>();

    void Start()
      => Target.material = _material = new Material(Target.material);

    void Update()
    {
        _param = Mathf.Clamp01(_param + Time.deltaTime * (_reveal ? 1 : -1));
        var res = Mathf.Lerp(8, 512, Mathf.Pow(_param, 4));
        _material.SetFloat("_Resolution", res);
    }
}
