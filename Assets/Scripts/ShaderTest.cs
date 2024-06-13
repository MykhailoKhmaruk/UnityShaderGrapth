using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer))]
public class ShaderTest : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private MaterialPropertyBlock _materialPropertyBlock;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();
        
        StartCoroutine(ChangeParams());
    }

    private IEnumerator ChangeParams()
    {
        while (true)
        {
            _materialPropertyBlock.SetFloat("_Edge", Random.Range(0, 2f));
            _meshRenderer.SetPropertyBlock(_materialPropertyBlock);

            yield return new WaitForSeconds(0.5f);
        }
    }
}