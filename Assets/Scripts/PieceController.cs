using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    [SerializeField] private AudioClip beep;
    public BoxSelection _box;
    public SpriteRenderer spRender;
    public Color winColor;
    public static bool mouseOver = false;

    private Animator _animator;
    private AudioSource _audio;

    private void Start()
    {
        _box = FindObjectOfType<BoxSelection>();
        _animator = GetComponentInParent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    public Color CurrentColor
    {
        get => spRender.color;
        private set => spRender.color = value;
    }
    public bool IsWinColor => winColor == CurrentColor;

    public void UpdateColor(Color newColor)
    {
        CurrentColor = newColor;
        _animator.SetTrigger("isHower");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "selector")
            return;
        Debug.Log("detection");    
        _box.AddToSelectedList(this);
        _animator.SetTrigger("isHower");
        _audio.PlayOneShot(beep);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "selector")
            return;
        Debug.Log("leave");
        _box.RemoveToSelectedList(this);
    }
    private void OnMouseDown()
    {
        mouseOver = true;
    }
    private void OnMouseUp()
    {
        mouseOver = false;
    }
}
