using UnityEngine;
public class SkyboxManager : MonoBehaviour
{
    public Material videoMaterial;
    public GameObject [] objetosParaEsconder;
    private Material DefaultSkybox;
    [SerializeField] private bool IsSBDefault = true;
    public ParticleSystem particle;

    void Start(){
        DefaultSkybox = RenderSettings.skybox;
    }

    public void AlternaSkybox(){
        if(IsSBDefault){
            particle.Play();
            ConfigSB(videoMaterial, false);
        }else{
            particle.Play();
            ConfigSB(DefaultSkybox, true);
        }
        IsSBDefault = !IsSBDefault;
    }

    private void ConfigSB(Material material, bool isActive){
        RenderSettings.skybox = material;
        foreach(GameObject item in objetosParaEsconder){
            item.SetActive(isActive);
        }
    }
}
