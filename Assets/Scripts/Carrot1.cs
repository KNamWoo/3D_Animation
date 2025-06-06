using UnityEngine;

public class Carrot1 : MonoBehaviour
{
    public GameObject carrot;
    public Animator animator;
    public string animationStateName = "CarrotAction"; // 상태 이름
    //public GameObject targetToDeactivate;     // 끌 오브젝트
    public int targetFrame = 2;
    public int layer = 0;

    private bool deactivated = false;

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layer);

        if (stateInfo.IsName(animationStateName))
        {
            Debug.Log("작동");
            AnimationClip clip = GetClipByName(animationStateName);
            if (clip == null) return;

            Debug.Log("클립이 비어있지 않음");
            float frameRate = clip.frameRate;
            float currentTimeInSeconds = stateInfo.normalizedTime * clip.length;
            int currentFrame = Mathf.FloorToInt(currentTimeInSeconds * frameRate);

            if (!deactivated && currentFrame >= targetFrame)
            {
                carrot.SetActive(false);
                deactivated = true; // 한 번만 실행
            }
        }
    }

    AnimationClip GetClipByName(string name)
    {
        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == name)
                Debug.Log("일치");
                return clip;
        }
        return null;
    }
}
