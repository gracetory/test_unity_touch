using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateManager;

public class ChipManager : MonoBehaviour {
	GameObject[] _chip = new GameObject[3];
	TouchManager _touch_manager;

	/**
	 * 初期化
	 *
	 * @access private
	 */
	void Start() {
		// タッチ管理マネージャ生成
		this._touch_manager = new TouchManager();

		// チップ生成
		create();
	}

	/**
	 * 更新
	 *
	 * @access private
	 */
	void Update() {
		// タッチ状態更新
		this._touch_manager.update();

		// タッチ取得
		TouchManager touch_state = this._touch_manager.getTouch();

		// タッチされていたら処理
		if (touch_state._touch_flag) {
			// 座標系変換
			Vector2 world_point = Camera.main.ScreenToWorldPoint(touch_state._touch_position);

			// 離した瞬間　か　押しっぱなし
			if (touch_state._touch_phase == TouchPhase.Ended) {
				Debug.Log("world_point x= " + world_point.x + " world_point y=" + world_point.y);
				RaycastHit2D hit = Physics2D.Raycast(world_point, Vector2.zero);
				// チップ切り替え
				if (hit) {
					Debug.Log("オブジェクトにタッチしたよ");
					// タッチ時の処理を行う
					hit.collider.GetComponent<Chip>().touch();
				} else {
					Debug.Log("そこにオブジェクトは無いよ");
				}
			}
		}
	}

	/**
	 * チップ生成
	 *
	 * @access private
	 */
	void create() {
		// プレハブ取得
		GameObject chip = (GameObject)Resources.Load("Prefabs/chip");

		// 座標
		Vector2 pos;

		// 各チップのインスタンス化
		pos.x = 0.0f;
		pos.y = 150.0f;
		_chip[0] = Instantiate(chip, pos, Quaternion.identity);
		_chip[0].GetComponent<Chip>().init();

		pos.x = 0.0f;
		pos.y = 0.0f;
		_chip[1] = Instantiate(chip, pos, Quaternion.identity);
		_chip[1].GetComponent<Chip>().init();

		pos.x = 0.0f;
		pos.y = -150.0f;
		_chip[2] = Instantiate(chip, pos, Quaternion.identity);
		_chip[2].GetComponent<Chip>().init();
	}
}
