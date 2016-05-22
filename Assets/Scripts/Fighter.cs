using UnityEngine;using System.Collections;using Leap;public class Fighter : MonoBehaviour {    public Controller controller = new Controller();    public GameObject FighterObject;    public Quaternion basisRotation;    public Vector3 speed = new Vector3( 0.0f, 0.0f, 0.0f );    public float test = 0.0f;    void Start()    {        //basisRotation = FighterObject.transform.rotation;    }    void Update()    {        Frame frame = controller.Frame();        HandList hands = frame.Hands;        Hand hand = hands.Rightmost;        InteractionBox interactionBox = frame.InteractionBox;
        //右手がLeap上に存在する
        if (hand.IsValid && hand.IsRight)        {            speed = ToVector3(hand.Direction);
            //speed += transform.up = ToVector3(hand.PalmNormal * -1.0f);
            transform.up = ToVector3(hand.PalmNormal * -1.0f);        }

        transform.position += speed * 0.1f;


    }   void SetVisible( GameObject obj, bool visible )  {    foreach( Renderer component in obj.GetComponents<Renderer>() ) {      component.enabled = visible;    }  }   Vector3 ToVector3( Vector v )  {    return new UnityEngine.Vector3( -1.0f * v.x, v.y, v.z );  }}