using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManger : MonoBehaviour {

    public static BuildManger instance;

    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    /*public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;*/

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBulild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition()+ new Vector3(.0f,0.5f,.0f), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left:" + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
