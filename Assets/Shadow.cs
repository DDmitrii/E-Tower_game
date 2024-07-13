using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shadow : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Image image = GetComponent<Image>();
        Color color = image.color;

        while(color.a < 1f) {
            color.a += speed * Time.deltaTime;
            image.color = color;
            yield return null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
