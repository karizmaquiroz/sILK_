using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CardsController : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransform;

    [SerializeField] Sprite[] sprites;

    [SerializeField] int numberOfPairsPerRound = 3; // You want 3 pairs → 6 cards

    private Card firstSelected;
    private Card secondSelected;
    private int currentRound = 0;
    private const int totalRounds = 3;
    private List<int> availablePairIndices = new(); // pool of all 9 pair indices
    private List<int> usedPairIndices = new(); // tracks already-used ones

    private List<Card> activeCards = new(); // Track current cards in scene

    private int matchesThisRound = 0;
    public GameObject starOne;
    public GameObject starTwo;
    public GameObject starThree;

    public GameObject cont;

    void Start()
    {
        if (sprites.Length % 2 != 0 || sprites.Length < numberOfPairsPerRound * 2)
        {
            Debug.LogError("Sprites must be even and enough to cover all rounds.");
            return;
        }

        // Initialize full pair pool [0..8] for 9 pairs
        availablePairIndices.Clear();
        for (int i = 0; i < sprites.Length / 2; i++)
            availablePairIndices.Add(i);

        StartNextRound();
    }
    void StartNextRound()
    {
        if (currentRound >= totalRounds)
        {
            Debug.Log("All rounds complete!");
            return;
        }

        Debug.Log($"Starting Round {currentRound + 1}");

        // Clear previous cards
        foreach (var card in activeCards)
            Destroy(card.gameObject);

        activeCards.Clear();

        // Select 3 unused pairs
        Shuffle(availablePairIndices);
        List<int> roundPairIndices = availablePairIndices.GetRange(0, numberOfPairsPerRound);

        // Remove them from available list and track used
        foreach (int idx in roundPairIndices)
        {
            availablePairIndices.Remove(idx);
            usedPairIndices.Add(idx);
        }

        // Create 6 card data entries
        List<(Sprite sprite, int pairID)> roundData = new();
        foreach (int pairIndex in roundPairIndices)
        {
            roundData.Add((sprites[pairIndex * 2], pairIndex));     // word
            roundData.Add((sprites[pairIndex * 2 + 1], pairIndex)); // definition
        }

        Shuffle(roundData);

        // Spawn cards
        foreach (var (sprite, pairID) in roundData)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(sprite);
            card.SetPairID(pairID);
            card.controller = this;
            activeCards.Add(card);
        }

        currentRound++;
    }


    void SpawnCardsForRound()
    {
        // Total available pairs
        int totalPairs = sprites.Length / 2;

        // Create a list of available pair indices: [0, 1, 2, ..., 8]
        List<int> availablePairIndices = new List<int>();
        for (int i = 0; i < totalPairs; i++)
        {
            availablePairIndices.Add(i);
        }

        // Shuffle available pair indices and pick N
        Shuffle(availablePairIndices);
        List<int> selectedPairIndices = availablePairIndices.GetRange(0, numberOfPairsPerRound);

        // Now collect the selected (sprite, pairID) tuples
        List<(Sprite sprite, int pairID)> roundData = new();

        foreach (int pairIndex in selectedPairIndices)
        {
            Sprite wordSprite = sprites[pairIndex * 2];
            Sprite defSprite = sprites[pairIndex * 2 + 1];

            roundData.Add((wordSprite, pairIndex));
            roundData.Add((defSprite, pairIndex));
        }

        // Shuffle the final 6-card list
        Shuffle(roundData);

        // Spawn cards
        foreach (var (sprite, pairID) in roundData)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(sprite);
            card.SetPairID(pairID);
            card.controller = this;
        }
    }

    public void SetSelected(Card card)
    {
        if (card.isSelected == false)
        {
            card.Show();

            if (firstSelected == null)
            {
                firstSelected = card;
                return;
            }

            if (secondSelected == null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(1f);

        if (a.pairID == b.pairID)
        {
            Debug.Log("Match!");
            matchesThisRound++;

            if (matchesThisRound >= numberOfPairsPerRound)
            {
                Debug.Log("All matches found for this round.");
                if (currentRound == 1)
                {
                    starOne.SetActive(true);
                }
                else if (currentRound == 2)
                {
                    starTwo.SetActive(true);
                }
                else if (currentRound == 3)
                {
                    starThree.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    cont.SetActive(true);
                }
                yield return new WaitForSeconds(1f);
                matchesThisRound = 0;
                StartNextRound(); // auto-advance
            }
        }
        else
        {
            a.Hide();
            b.Hide();
        }
    }


    void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }
}
