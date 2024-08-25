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
                GameObject piece = Instantiate(heartPiecePrefabs[j], heartBg.transform);
                piece.transform.localPosition = Vector3.zero;
                pieces.Add(piece);  // 리스트에 추가
            }
            heartPiecesList.Add(pieces);

            // 회색 상태의 하트 조각 생성 (초기엔 비활성화 상태)
            List<GameObject> piecesGray = new List<GameObject>();
            for (int j = 0; j < heartPieceGrayPrefabs.Length; j++)
            {
                GameObject pieceGray = Instantiate(heartPieceGrayPrefabs[j], heartBg.transform);
                pieceGray.transform.localPosition = Vector3.zero;
                pieceGray.SetActive(false);  // 회색 조각은 초기 상태에서는 비활성화
                piecesGray.Add(pieceGray);  // 리스트에 추가
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
            int heartIndex = heartsBackground.Count - 1 - i; // 인덱스를 반대로 변경

            if (i < currentHealth)
            {
                // 정상 상태의 조각 활성화, 회색 조각 비활성화
                for (int j = 0; j < heartPiecesList[heartIndex].Count; j++)
                {
                    heartPiecesList[heartIndex][j].SetActive(true);
                    heartPiecesGrayList[heartIndex][j].SetActive(false);
                }
            }
            else
            {
                // 정상 상태의 조각 비활성화, 회색 조각 활성화
                for (int j = 0; j < heartPiecesList[heartIndex].Count; j++)
                {
                    heartPiecesList[heartIndex][j].SetActive(false);
                    heartPiecesGrayList[heartIndex][j].SetActive(true);
                }
            }
        }
    }

        public static HealthIndicator Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        // 체력 업데이트
        public void UpdateHealthIndicator()
        {
            int currentHealth = (int)PlayerController.player.health.health;

            for (int i = 0; i < heartsBackground.Count; i++)
            {
                int heartIndex = heartsBackground.Count - 1 - i;

                if (i < currentHealth)
                {
                    SetHeartActive(heartIndex, true);
                }
                else
                {
                    SetHeartActive(heartIndex, false);
                }
            }
        }

        // 하트 조각 활성화/비활성화
        private void SetHeartActive(int index, bool isActive)
        {
            for (int j = 0; j < heartPiecesList[index].Count; j++)
            {
                heartPiecesList[index][j].SetActive(isActive);
                heartPiecesGrayList[index][j].SetActive(!isActive);
            }
        }

}
