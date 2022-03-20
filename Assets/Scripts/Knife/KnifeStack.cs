
using System.Collections.Generic;
using UnityEngine;

public class KnifeStack : MonoBehaviour
{
    public UsedKnife CurrentCnife => _currentKnife;

    private UsedKnife _currentKnife;

    public int KnifeCount => _knifeList.Count;
    public int MaxKnifes => _maxKnifes;

    public int CurrentKnifeCount => _currentKnifeCount;

    private UsedKnife _usedKnife;

    private int _currentKnifeCount;


    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private UsedKnife _knifePrefub;

    [SerializeField] private List<UsedKnife> _knifeList;

    [Header("Set stack size")]
    [SerializeField] private int _maxKnifes;

    [Header("UI")]
    // if game will be lose or win
    [SerializeField] private LoseUI _loseCanvas;
    [SerializeField] private WinUI _winCanvas;

    private void Start()
    {
        _knifeList = new List<UsedKnife>(_maxKnifes);
        _usedKnife = _knifePrefub.GetComponent<UsedKnife>();
        AddKnifes();
        Respawn(_spawnPoint);
    }

    private void Update()
    {
        CheckStack();
    }

    private void CheckStack()
    {
        if (_knifeList.Count == 0 && _usedKnife.KnifeHitKnife == false)
            _winCanvas.gameObject.SetActive(true);
    }

    public void OnKnifeHit()
    {
        _loseCanvas.gameObject.SetActive(true);
    }

    private void Respawn(Transform throwPoint)
    {
        UsedKnife item;

        _knifeList.RemoveAt(_knifeList.Count - 1);

        if (_knifeList.Count >= 0 && _knifeList.Count - 1 <= _maxKnifes)
        {
            if (_knifeList.Count - 1 >= 0)
            {
                item = _knifeList[_knifeList.Count - 1];
                _currentKnife = Instantiate(item, throwPoint.position, Quaternion.identity);
            }
        }
    }

    private void AddKnifes()
    {
        for (int i = 0; i <= _maxKnifes; i++)
            _knifeList.Add(_knifePrefub);
    }

    public void RemoveKnifeFromStack()
    {
        if (_currentKnifeCount < _maxKnifes)
        {
            _currentKnifeCount++;
            Respawn(_spawnPoint);
        }
    }
}
