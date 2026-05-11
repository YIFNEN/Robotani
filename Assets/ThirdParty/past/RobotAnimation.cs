using UnityEngine;

public class RobotAnimation : MonoBehaviour
{
    
     public Animator characterAnimator;

    void Update()
    {
        if (characterAnimator == null)
        {
            Debug.LogError("Animator가 할당되지 않았습니다!");
            return;
        }

        // 좌 방향키 → doHead
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            characterAnimator.SetTrigger("doHead");
        }

        // 우 방향키 → doArm
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            characterAnimator.SetTrigger("doArm");
        }

        // 스페이스바 → doBody
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterAnimator.SetTrigger("doBody");
        }



        /* 
         // 버튼에 연결할 메서드
         public void PlayHeadAni() => SetTrigger("doHead");
         public void PlayArmAni() => SetTrigger("doArm");
         public void PlayBodyAni() => SetTrigger("doBody");

         private void SetTrigger(string name)
         {
             if (characterAnimator == null)
             {
                 Debug.LogError("Animator가 할당되지 않았습니다!");
                 return;
             }
             characterAnimator.SetTrigger(name);
        */
    }
}
