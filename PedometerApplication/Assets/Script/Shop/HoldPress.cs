
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldPress: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	/// <summary>
	/// 押しっぱなし時に呼び出すイベント
	/// </summary>
	public UnityEvent onLongPress = new UnityEvent ();
	/// <summary>
	/// 押しっぱなし判定の間隔（この間隔毎にイベントが呼ばれる）
	/// </summary>
	public float intervalAction = 0.2f;
	// 押下開始時にもイベントを呼び出すフラグ
	public bool callEventFirstPress;

	// 次の押下判定時間
	float nextTime = 0f;

	/// <summary>
	/// 押下状態
	/// </summary>
	public bool pressed
	{
		get;
		private set;
	}

	void Update ()
	{
		Debug.Log (nextTime);
		if (pressed && nextTime < Time.realtimeSinceStartup) {
			onLongPress.Invoke ();
			nextTime = Time.time + intervalAction;
			if (nextTime > 10f) {
				Hold10sec ();
			}
		} else {
			nextTime = 0f;
		}
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		pressed = true;
		if (callEventFirstPress) {
			onLongPress.Invoke ();
		}
		nextTime = Time.realtimeSinceStartup + intervalAction;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		pressed = false;
	}

	void Hold10sec() {
		Debug.Log ("10秒以上おしっぱなし");
	}
}