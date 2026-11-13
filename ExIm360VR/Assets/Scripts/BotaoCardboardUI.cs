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

    void Start()
    {
        escalaOriginal = transform.localScale;
        botaoUnity = GetComponent<Button>();

        if (imagemDoBotao == null)
            imagemDoBotao = GetComponent<Image>();

        if (imagemDoBotao != null)
            imagemDoBotao.color = corNormal;
    }

    void Update()
    {
        if (!estaOlhando) return;

        // Verifica clique do botão esquerdo do mouse (Editor / PC)
        bool clicouMouse = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        // Verifica toque na tela (Celular Android / iOS)
        bool tocouTela = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        if (clicouMouse || tocouTela)
        {
            OnPointerClick();
        }
    }

    // Chamado automaticamente pelo CardboardReticlePointer quando o retículo entra
    public void OnPointerEnter()
    {
        estaOlhando = true;
        transform.localScale = escalaOriginal * 1.1f;
        if (imagemDoBotao != null)
            imagemDoBotao.color = corAoOlhar;
    }

    // Chamado automaticamente pelo CardboardReticlePointer quando o retículo sai
    public void OnPointerExit()
    {
        estaOlhando = false;
        transform.localScale = escalaOriginal;
        if (imagemDoBotao != null)
            imagemDoBotao.color = corNormal;
    }

    // Chamado pelo Cardboard no celular ou pelo clique do mouse no Update acima
    public void OnPointerClick()
    {
        Debug.Log("Botão clicado: " + gameObject.name);

        // Executa o que estiver configurado no "On Click ()" do componente Button!
        if (botaoUnity != null)
        {
            botaoUnity.onClick.Invoke();
        }
    }
}