using UnityEngine;using System.Collections;using Leap;public class Fighter : MonoBehaviour {

    public Controller controller = new Controller();
    public GameObject FighterObject;
    public Quaternion basisRotation;

    void Start()
    {
        basisRotation = FighterObject.transform.rotation;
    }

    void Update()    {
        Frame frame = controller.Frame();
        HandList hands = frame.Hands;
        Hand hand = hands.Rightmost;
        InteractionBox interactionBox = frame.InteractionBox;

        //右手がLeap上に存在する
        if (hand.IsValid && hand.IsRight)        {
            Vector3 cross1 = Vector3.Cross( transform.up, ToVector3(hand.PalmNormal).normalized * -1.0f);
            float f = Vector3.Angle( transform.up, ToVector3(hand.PalmNormal).normalized * -1.0f );
            transform.Rotate( cross1, f );
       
            Vector3 cross2 = Vector3.Cross( transform.forward, ToVector3(hand.Direction).normalized);
            float f2 = Vector3.Angle( transform.forward, ToVector3(hand.Direction).normalized);
            transform.Rotate(cross2, f2);

            Vector3 cross3 = Vector3.Cross( ToVector3(hand.Direction).normalized, ToVector3(hand.PalmNormal).normalized );

            Vector3 cross4 = Vector3.Cross( transform.right, cross3);
            float f3 = Vector3.Angle( transform.right, cross3 );
            transform.Rotate(cross4, f3);
        }

        transform.position += transform.forward * -0.2f;    }   void SetVisible( GameObject obj, bool visible )  {    foreach( Renderer component in obj.GetComponents<Renderer>() ) {      component.enabled = visible;    }  }   Vector3 ToVector3( Vector v )  {    return new UnityEngine.Vector3(-1.0f * v.x, v.y, v.z );  }}