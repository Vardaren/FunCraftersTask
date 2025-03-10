using DG.Tweening;
using UnityEngine;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class Loader : MonoBehaviour {
    [SerializeField] RectTransform loaderIcon;

    TweenerCore<Quaternion, Vector3, QuaternionOptions> loaderTweener;

    const float DURATION = 1f;

    void Start() {
        loaderTweener = loaderIcon.DOLocalRotate(new Vector3(0, 0, 360), DURATION, RotateMode.FastBeyond360)
            .SetRelative(true)
            .SetEase(Ease.Linear)
            .SetLoops(-1)
            .SetAutoKill(false);
    }

    public void Show() {
        gameObject.SetActive(true);
        loaderTweener.Restart();
    }

    public void Hide() {
        gameObject.SetActive(false);
        loaderTweener.Pause();
    }
}
