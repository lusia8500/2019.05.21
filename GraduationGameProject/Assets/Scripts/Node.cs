using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;
    //public Quaternion rotationOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManger buildManger;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManger = BuildManger.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManger.CanBulild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Can't build there! - TODO: DIsplay on screen.");
            return;
        }

        buildManger.BuildTurretOn(this);

        //Build a turret
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManger.CanBulild)
        {
            return;
        }

        if(buildManger.HasMoney)
        {
            rend.material.color = hoverColor;
        }

        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
