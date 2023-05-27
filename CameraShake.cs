using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsedTime = 0.0f;
        GameObject.FindObjectOfType<Shake>().GetComponent<Shake>().Shake1(2, 0.5f);

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-1f, 1f) * magnitude;
            float yOffset = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x + xOffset, originalPos.y + yOffset, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
