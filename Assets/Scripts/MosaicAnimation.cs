using UnityEngine;
using UnityEngine.UI;

public sealed class MosaicAnimation : MonoBehaviour, IMaterialModifier
{
    float _param;
    bool _reveal;

    public void Toggle() => _reveal = !_reveal;

    void Update()
    {
        _param += Time.deltaTime * (_reveal ? 1 : -1);
        if (_param >= 0 && _param <=1) GetComponent<Image>().SetMaterialDirty();
        _param = Mathf.Clamp01(_param);
    }

    public Material GetModifiedMaterial(Material baseMaterial)
    {
        var res = Mathf.Lerp(8, 512, Mathf.Pow(_param, 4));
        baseMaterial.SetFloat("_Resolution", res);
        return baseMaterial;
    }
}
