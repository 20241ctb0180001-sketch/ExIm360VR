using UnityEngine;
public class objectMover : MonoBehaviour
{
    [Header("Música")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float strength = 10f;
    [SerializeField] private float smoothTime = 0.2f;

    [Header("Órbita")]
    [SerializeField] private Transform centro;
    [SerializeField] private float velocidade = 30f;

    private readonly float[] spectrum = new float[64];
    private float smoothLevel;
    private float smoothVelocity;
    private float angulo;
    private float raio;
    private float alturaInicial;

    private void Start()
    {
        if (centro == null)
        {
            Debug.LogError("Atribua o centro da órbita no Inspector.", this);
            return;
        }

        Vector3 offset = transform.position - centro.position;
        angulo = Mathf.Atan2(offset.z, offset.x);
        raio = Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z);
        alturaInicial = offset.y;
    }

    private void Update()
    {
        float target = 0f;

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Hanning);

            float level = 0f;
            foreach (float value in spectrum)
                level += value;

            target = level * strength;
        }

        smoothLevel = Mathf.SmoothDamp(
            smoothLevel,
            target,
            ref smoothVelocity,
            smoothTime
        );

        if (centro == null) return;

        angulo += velocidade * Mathf.Deg2Rad * Time.deltaTime;

        float x = Mathf.Cos(angulo) * raio;
        float z = Mathf.Sin(angulo) * raio;

        transform.position = new Vector3(
            centro.position.x + x,
            centro.position.y + alturaInicial + smoothLevel,
            centro.position.z + z
        );
    }
}
