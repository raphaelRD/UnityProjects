using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTileScript : MonoBehaviour
{
    private Crop curCrop;
    public GameObject cropPrefab;

    public SpriteRenderer sr;
    private bool tilled;
    private bool busy;

    [Header("Sprites")]
    public Sprite grassSprite;
    public Sprite tilledSprite;
    public Sprite wateredTilledSprite;


    void Start()
    {
        //Define o sprite default como sendo do tipo grama
        sr.sprite = grassSprite;
    }

    public void Interact()
    {
        if(!tilled && busy == false)
        {
            Till();
         
        }
        else if (!hasCrop() && GameManager.instance.canPlantCrop() && busy == false)
        {
            PlantNewCrop(GameManager.instance.selectedCropToPlant);
        }
        else if(hasCrop() && curCrop.CanHarvest())
        {
            curCrop.Harvest();
        }
        else
        {
            Water();
        }
    }

    public void Build(GameObject build)
    {
        Instantiate(build,transform);
    }

    void OnEnable()
    {
        GameManager.instance.onNewDay += OnNewDay;
    }

    void OnDisable()
    {
        GameManager.instance.onNewDay -= OnNewDay;
    }
    void PlantNewCrop(CropData crop)
    {
        if(!tilled || busy) 
            return;
        curCrop = Instantiate(cropPrefab,transform).GetComponent<Crop>();
        curCrop.Plant(crop);

        GameManager.instance.onNewDay+= OnNewDay;   
    }

    void Till()
    {
        if(busy == false){
            tilled = true;
            sr.sprite = tilledSprite;
        }
        
    }

    void Water()
    {
        
        if(hasCrop())
        {
            sr.sprite = wateredTilledSprite;
            curCrop.Water();
        }
    }

    void OnNewDay()
    {
        if(curCrop == null)
          {  tilled = false;
            sr.sprite = grassSprite;
            GameManager.instance.onNewDay -= OnNewDay;
    }
        else if(curCrop!= null)
        {
            sr.sprite = tilledSprite;
            curCrop.NewDayCheck();
        }
    }
    bool hasCrop()
    {
        return curCrop != null;
    }
}
