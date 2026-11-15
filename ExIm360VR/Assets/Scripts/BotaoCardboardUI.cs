using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BotaoCardboardUI : MonoBehaviour
{
    [Header("Feedback Visual")]
    public Image imagemDoBotao;
    public Color corNormal = Color.white;
    public Color corAoOlhar = Color.cyan;
    private Vector3 escalaOriginal;
    private bool estaOlhando = false;
    private Button botaoUnity;
    //public InputActionAsset inputAction;
    private InputAction Select;
    public bool clikb = false;
    public AudioSource AudmanMusic;
    public AudioSource AudmanEffects;
    public AudioClip startaud;
    public AudioClip stopaud;
    public AudioClip MusicSpace;
    
    
    void Awake()
    {
        escalaOriginal = transform.localScale;
        botaoUnity = GetComponent<Button>();
        Select = InputSystem.actions.FindAction("Interact");

        AudmanMusic.loop = true;
        AudmanMusic.Play();

        if (imagemDoBotao == null)
            imagemDoBotao = GetComponent<Image>();

        if (imagemDoBotao != null)
            imagemDoBotao.color = corNormal;
    }

    void Update()
    {
        if (!estaOlhando) return;

        if(Select != null && Select.WasPressedThisFrame())
        {
            OnPointerClick();

            clikb = !clikb;
            AudmanMusic.clip = MusicSpace;
            
            if(clikb == true){
                AudmanEffects.PlayOneShot(startaud);
                AudmanMusic.Play();
            }
            else{
                AudmanEffects.PlayOneShot(stopaud);
                AudmanMusic.Stop();
            }
        }
    }

    public void OnPointerEnter()
    {
        estaOlhando = true;
        transform.localScale = escalaOriginal * 1.1f;
        if (imagemDoBotao != null)
            imagemDoBotao.color = corAoOlhar;
    }

    public void OnPointerExit()
    {
        estaOlhando = false;
        transform.localScale = escalaOriginal;
        if (imagemDoBotao != null)
            imagemDoBotao.color = corNormal;
    }

    public void OnPointerClick()
    {
        if (botaoUnity != null)
        {
            botaoUnity.onClick.Invoke();
        }
    }
}