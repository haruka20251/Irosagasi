using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    //�ȉ��J�����̐U���ݒ�
    public float kWalkHorizontalBob = 0.33f; // ���s���̉��h��
    public float kStopHorizontalBob = 0.1f;  // ��~���̉��h��
    public float kWalkverticalBob = 0.33f;  // ���s���̏c�h��
    public float kStopverticalBob = 0.1f;   // ��~���̏c�h��

    public AnimationCurve bobCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f),
                                                      new Keyframe(1f, 0f), new Keyframe(1.5f, -1f),
                                                      new Keyframe(2f, 0f));//�h���
    public float verticaltoHorizontalRatio = 1f;//�c�h��E���h��̔䗦

    private float m_CyclePositionX;
    private float m_CyclePositionY;
    private float m_BobBaseInterval;
    private Vector3 m_OriginalPosition;
    private float m_Time;
    public void Setup(Camera camera, float bobBaseInterval)
    {
        m_BobBaseInterval = bobBaseInterval;
        m_OriginalPosition = camera.transform.localPosition;
        m_Time = bobCurve[bobCurve.length - 1].time;
    }

    public Vector3 DoHeadBob(float speed,bool isWalk)
    {
        
        float horizontalBob = isWalk ? kWalkHorizontalBob : kStopHorizontalBob;
        float verticalBob= isWalk ? kWalkverticalBob : kStopverticalBob;
        float xPos = m_OriginalPosition.x+(bobCurve.Evaluate(m_CyclePositionX)*horizontalBob);
        float yPos = m_OriginalPosition.y+(bobCurve.Evaluate(m_CyclePositionY)*verticalBob);

        m_CyclePositionX += (speed * Time.deltaTime) / m_BobBaseInterval;
        m_CyclePositionY+= ((speed * Time.deltaTime) / m_BobBaseInterval) * verticaltoHorizontalRatio;

        if(m_CyclePositionX > m_Time)
        {
            m_CyclePositionX = m_CyclePositionX - m_Time;

        }
        if(m_CyclePositionY > m_Time)
        {
            m_CyclePositionY= m_CyclePositionY - m_Time;
        }
        return new Vector3(xPos,yPos,0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
