using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
  [SerializeField] private Rigidbody2D msl_rb2d;
  [SerializeField] private Rigidbody2D tgt_rb2d;
  [SerializeField] private Transform destination;

  private float speed = 1f;
  
  private Vector2 msl;
  private Vector2 msl_previous;
  private Vector2 tgt;
  private Vector2 tgt_previous;

  private Vector2 los;
  private Vector2 los_previous;
  public float los_delta;
  void Start()
  {
    msl_rb2d.velocity = msl_rb2d.transform.right * speed;
    tgt_rb2d.velocity = tgt_rb2d.transform.right * speed;

    los = tgt_rb2d.position - msl_rb2d.position;
    los_previous = los;
    los_delta = 0f;
  }

  void Update()
  {
    DrawDebugLines();
  }

  void FixedUpdate()
  {
    tgt = tgt_rb2d.position;
    msl = msl_rb2d.position; 

    los = tgt - msl;
    los_previous = tgt_previous - msl_previous;

    los_delta = Vector2.SignedAngle(los_previous, los);

    los_previous = los;
    tgt_previous = tgt;
    msl_previous = msl;
  }

  private void DrawDebugLines()
  {
   
  }
}
