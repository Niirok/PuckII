using UnityEngine;

/// <summary>
/// Parallax scrolling
/// </summary>
public class ScrollingScriptF2_1 : MonoBehaviour
{

public static ScrollingScriptF2_1 instance;

  /// <summary>
  /// Vitesse du défilement
  /// </summary>
  public Vector2 speed = new Vector2(2, 2);

  /// <summary>
  /// Direction du défilement
  /// </summary>
  public Vector2 direction = new Vector2(-1, 0);

  /// <summary>
  /// Appliquer le mouvement de scrolling à la caméra ?
  /// </summary>
  public bool isLinkedToCamera = false;

  void Start() {
	instance = this;
  }

  public void Move(float horizontal_input)
  {
    // Mouvement
    Vector3 movement = new Vector3(
      speed.x * direction.x,
      speed.y * direction.y,
      0);

    movement *= Time.deltaTime;
    transform.Translate(movement * horizontal_input);


    /*// Déplacement caméra
    if (isLinkedToCamera)
    {
      Camera.main.transform.Translate(movement);
    }*/
  }
}
