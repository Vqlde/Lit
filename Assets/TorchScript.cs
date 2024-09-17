using UnityEngine;

public class CircleViewMask : MonoBehaviour
{
    public Material circleMaskMaterial; // Drag the material here in the Inspector
    public float radius = 0.2f;         // Adjust the radius of the circle
    public Camera cam;
    private float Timer = 0;
    public float LightDecreaseTimer = 3;

    void Start()
    {

    }

    void Update()
        {
        if (Timer <= LightDecreaseTimer)
        {
            Timer = Timer + Time.deltaTime;
        }
        else
        {
            Timer = 0;
            if (radius <= 0)
            {
                Debug.Log("Du døde af lysmangel!");
            }
            else
            {
                radius = radius - 0.1f;
                radius = Mathf.Clamp(radius, 0, 1);
            }
        }




        
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            radius = radius + 0.025f;
            radius = Mathf.Clamp(radius, 0, 1);
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (circleMaskMaterial != null)
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
            Vector3 circleCenter = cam.ScreenToViewportPoint(screenCenter);

            // Set the circle center and radius in the shader
            circleMaskMaterial.SetVector("_CircleCenter", new Vector4(circleCenter.x, circleCenter.y, 0, 0));
            circleMaskMaterial.SetFloat("_Radius", radius);

            // Apply the material and render the final image
            Graphics.Blit(source, destination, circleMaskMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }



            
    }
}