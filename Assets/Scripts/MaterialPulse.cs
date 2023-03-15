using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPulse : MonoBehaviour
{
    [Header("Opacity Parameters")]
    public float maxOpacity;
    public float minOpacity;
    public float opacityStep;

    [Header("Renderer and material references")]
    public MeshRenderer objectRenderer;
    public Material objectMaterial;

    private Color tempColor;
    // Start is called before the first frame update
    void Start()
    {
        // Get a refence to the mesh renderer attached to this object
        objectRenderer = gameObject.GetComponent<MeshRenderer>();
        objectMaterial = objectRenderer.material;

        tempColor = new Color(objectMaterial.color.r, objectMaterial.color.g, objectMaterial.color.b, objectMaterial.color.a);
    }

    // Update is called once per frame
    void Update()
    {
        //if opactiyy has reached bounds then reverse opactiy step
        if(tempColor.a <= minOpacity || tempColor.a >= maxOpacity) {
            opacityStep *= -1.0f;
        }
        
        // add opactiy to our tempColor
        tempColor.a += opacityStep;
        objectMaterial.SetColor("_Color", tempColor);
        
    }
}
