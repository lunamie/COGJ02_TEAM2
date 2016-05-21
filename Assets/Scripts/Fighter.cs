using UnityEngine;using System.Collections;using Leap;public class Fighter : MonoBehaviour {    Controller controller = new Controller();   public int FingerCount;  //public GameObject[] FingerObjects;  public Vector handAngle;   void Start()  {  }   void Update()  {    Frame frame = controller.Frame();    Hand hand = frame.Hands.Rightmost;

    //右手がLeap上に存在する
    if (hand.IsValid && hand.IsRight)    {
        handAngle = hand.Direction;
        //transform.LookAt(ToVector3(handAngle));
        //transform.position += transform.forward * -0.01f;
        transform.forward = ToVector3(handAngle).normalized;
    }

    transform.position += transform.forward * -1.0f;

}   void SetVisible( GameObject obj, bool visible )  {    foreach( Renderer component in obj.GetComponents<Renderer>() ) {      component.enabled = visible;    }  }   Vector3 ToVector3( Vector v )  {    return new UnityEngine.Vector3( v.x, -v.y, -v.z );  }}