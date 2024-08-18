using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] GameObject heartBackground;
    [SerializeField] GameObject[] heartPiecePrefabs;  // 각 하트 조각의 프리팹 배열 (정상 상태)
    [SerializeField] GameObject[] heartPieceGrayPrefabs;  // 각 하트 조각의 회색 프리팹 배열

    public List<GameObject> heartsBackground = new List<GameObject>();
    public List<List<GameObject>> heartPiecesList = new List<List<GameObject>>();  // 각 하트의 네 조각을 담는 리스트
    public List<List<GameObject>> heartPiecesGrayList = new List<List<GameObject>>();  // 각 하트의 회색 조각을 담는 리스트

    private void Start()
    {
        for (int i = 0; i < PlayerController.player.health.maxHealth; i++)
        {
            // 하트 배경 생성
            GameObject heartBg = Instantiate(heartBackground, new Vector3(transform.position.x - 1.2f * i, transform.position.y, transform.position.z), Quaternion.identity);
            heartsBackground.Add(heartBg);
            heartBg.transform.SetParent(this.transform);

            // 정상 상태의 하트 조각 생성
            List<GameObject> pieces = new List<GameObject>();
            for (int j = 0; j < heartPiecePrefabs.Length; j++)
            {
                GameObject piece = Instantiate(heartPiecePrefabs[j], heartBg.transform.position, Quaternion.identity);
                piece.transform.SetParent(heartBg.transform);
                pieces.Add(piece);
            }
            heartPiecesList.Add(pieces);

            // 회색 상태의 하트 조각 생성 (초기엔 비활성화 상태)
            List<GameObject> piecesGray = new List<GameObject>();
            for (int j = 0; j < heartPieceGrayPrefabs.Length; j++)
            {
                GameObject pieceGray = Instantiate(heartPieceGrayPrefabs[j], heartBg.transform.position, Quaternion.identity);
                pieceGray.transform.SetParent(heartBg.transform);
                pieceGray.SetActive(false);
                piecesGray.Add(pieceGray);
            }
            heartPiecesGrayList.Add(piecesGray);
        }
    }



    private void FixedUpdate()
    {
        int currentHealth = (int)PlayerController.player.health.health;

        // 하트 상태 업데이트
        for (int i = 0; i < heartsBackground.Count; i++)
        {
            if (i < currentHealth)
            {
                // 정상 상태의 조각 활성화, 회색 조각 비활성화
                for (int j = 0; j < heartPiecesList[i].Count; j++)
                {
                    heartPiecesList[i][j].SetActive(true);
                    heartPiecesGrayList[i][j].SetActive(false);
                }
            }
            else
            {
                // 정상 상태의 조각 비활성화, 회색 조각 활성화
                for (int j = 0; j < heartPiecesList[i].Count; j++)
                {
                    heartPiecesList[i][j].SetActive(false);
                    heartPiecesGrayList[i][j].SetActive(true);
                }
            }
        }
    }

}
