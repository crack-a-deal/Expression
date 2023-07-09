using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [Header("Colors")]
    public Image victoryStripe1;
    public Image victoryStripe2;
    public Image victoryStripe3;
    public Image victoryStripe4;
    public Image victoryStripe5;

    [Space][SerializeField] private AudioClip clip;
    private Animator _animator;
    private LevelColors levelColors;
    private AudioSource _source;

    private void Start()
    {
        _source.PlayOneShot(clip);
    }
    private void Awake()
    {
        levelColors = FindObjectOfType<LevelColors>();
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
    }

    public void NextLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LevelById(int id)
    {
        StartCoroutine(LoadScene(id));
    }
    private IEnumerator LoadScene(int index)
    {
        Debug.Log("END LEVEL");
        setColors();
        _animator.SetTrigger("fade");
        _source.PlayOneShot(clip);

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(index);
    }
    public void setColors()
    {
        victoryStripe1.color = levelColors.color1;
        victoryStripe2.color = levelColors.color2;
        victoryStripe3.color = levelColors.color3;
        victoryStripe4.color = levelColors.color4;
        victoryStripe5.color = levelColors.color5;
    }
}
