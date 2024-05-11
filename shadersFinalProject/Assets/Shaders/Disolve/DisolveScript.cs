using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisolveScript : MonoBehaviour
{
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    private Material[] materials;
    private float NoiseStrength;
    private bool trobat = false;

    private bool desapareixTimer = true;
    private bool potDesapareixer = false;

    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        if (skinnedMeshRenderers != null && skinnedMeshRenderers.Length > 0)
        {
            materials = new Material[skinnedMeshRenderers.Length];
            for (int i = 0; i < skinnedMeshRenderers.Length; i++)
            {
                materials[i] = skinnedMeshRenderers[i].material;
            }
            NoiseStrength = materials[0].GetFloat("_NoiseStrength");
            trobat = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trobat)
        {
            if (!potDesapareixer && NoiseStrength < 5f)
            {
                NoiseStrength += (2f * Time.deltaTime);
                foreach (Material material in materials)
                {
                    material.SetFloat("_NoiseStrength", NoiseStrength);
                }
            }
            else
            {
                if (desapareixTimer)
                {
                    desapareixTimer = false;
                    StartCoroutine(waitDesapareixer());
                }


                if (potDesapareixer && NoiseStrength > -23f)
                {
                    NoiseStrength -= (2f * Time.deltaTime);
                    foreach (Material material in materials)
                    {
                        material.SetFloat("_NoiseStrength", NoiseStrength);
                    }
                }
            }
        }
    }

    IEnumerator waitDesapareixer()
    {
        yield return new WaitForSeconds(5f);
        potDesapareixer = true;
    }
}
