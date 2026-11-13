using UnityEngine;
public class SkyboxManager : MonoBehaviour
{
    public Material videoMaterial;
    public GameObject [] objetosParaEsconder;
    private Material DefaultSkybox;
    private bool IsSBDefault = false;
    public ParticleSystem particle;

    void Start(){
        DefaultSkybox = RenderSettings.skybox;
    }

    public void AlternaSkybox(){
        particle.Play();
        if(IsSBDefault){
            ConfigSB(videoMaterial, false);
        }else{
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
