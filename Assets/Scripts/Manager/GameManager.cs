using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	ChipManager _chip_manager;

	/**
	 * エントリポイント
	 *
	 * @access private
	 */
	void Start () {
		// ゲームオブジェクトのコンポーネントを取得
		this._chip_manager = GetComponent<ChipManager>();	// チップ管理

	}
	
	/**
	 * 更新
	 *
	 * @access private
	 */
	void Update () {
	}
}
