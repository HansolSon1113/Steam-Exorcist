using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] GameObject heartBackground;
    [SerializeField] GameObject[] heartPiecePrefabs;  // �� ��Ʈ ������ ������ �迭 (���� ����)
    [SerializeField] GameObject[] heartPieceGrayPrefabs;  // �� ��Ʈ ������ ȸ�� ������ �迭

    public List<GameObject> heartsBackground = new List<GameObject>();
    public List<List<GameObject>> heartPiecesList = new List<List<GameObject>>();  // �� ��Ʈ�� �� ������ ��� ����Ʈ
    public List<List<GameObject>> heartPiecesGrayList = new List<List<GameObject>>();  // �� ��Ʈ�� ȸ�� ������ ��� ����Ʈ

    private void Start()
    {
        for (int i = 0; i < PlayerController.player.health.maxHealth; i++)
        {
            // ��Ʈ ��� ����
            GameObject heartBg = Instantiate(heartBackground, new Vector3(transform.position.x - 1.2f * i, transform.position.y, transform.position.z), Quaternion.identity);
            heartsBackground.Add(heartBg);
            heartBg.transform.SetParent(this.transform);

            // ���� ������ ��Ʈ ���� ����
            List<GameObject> pieces = new List<GameObject>();
            for (int j = 0; j < heartPiecePrefabs.Length; j++)
            {
                GameObject piece = Instantiate(heartPiecePrefabs[j], heartBg.transform.position, Quaternion.identity);
                piece.transform.SetParent(heartBg.transform);
                pieces.Add(piece);
            }
            heartPiecesList.Add(pieces);

            // ȸ�� ������ ��Ʈ ���� ���� (�ʱ⿣ ��Ȱ��ȭ ����)
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

        // ��Ʈ ���� ������Ʈ
        for (int i = 0; i < heartsBackground.Count; i++)
        {
            if (i < currentHealth)
            {
                // ���� ������ ���� Ȱ��ȭ, ȸ�� ���� ��Ȱ��ȭ
                for (int j = 0; j < heartPiecesList[i].Count; j++)
                {
                    heartPiecesList[i][j].SetActive(true);
                    heartPiecesGrayList[i][j].SetActive(false);
                }
            }
            else
            {
                // ���� ������ ���� ��Ȱ��ȭ, ȸ�� ���� Ȱ��ȭ
                for (int j = 0; j < heartPiecesList[i].Count; j++)
                {
                    heartPiecesList[i][j].SetActive(false);
                    heartPiecesGrayList[i][j].SetActive(true);
                }
            }
        }
    }

}
