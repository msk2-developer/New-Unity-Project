using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour {

	public class DeviceOrientationDetector: MonoBehaviour {

		// 直前のディスプレイ向き
		DeviceOrientation PrevOrientation;


		// 端末の向きを取得するメソッド
		DeviceOrientation getOrientation() {

			DeviceOrientation result = Input.deviceOrientation;

			// Unkownならピクセル数から判断
			if (result == DeviceOrientation.Unknown)
			{
				if (Screen.width < Screen.height)
				{
					result = DeviceOrientation.Portrait;
				}
				else
				{
					result = DeviceOrientation.LandscapeLeft;
				}
			}

			return result;
		}

		void Start () {
			PrevOrientation = getOrientation();
		}

		void Update () {


			DeviceOrientation currentOrientation = getOrientation();
			if (PrevOrientation != currentOrientation)
			{
				// 画面の向きが変わった場合の処理


				PrevOrientation = currentOrientation;
			}
		} 
	}
}
