using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading_anim : MonoBehaviour
{
    [SerializeField] Image loadingBar;

    void UpdateLoadingProgress(float progress)
    {
        loadingBar.fillAmount = progress; // Update the fill amount of the loading bar
    }

    IEnumerator SimulateLoadingProgress()
    {
        float progress = 0f;
        while (progress < 1f)
        {
            progress += Time.deltaTime * 0.1f; // Adjust the speed here
            UpdateLoadingProgress(progress);
            yield return null;
        }
    }
}
