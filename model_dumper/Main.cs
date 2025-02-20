﻿using MelonLoader;
using Harmony;

using Assets.Scripts.Unity.UI_New.InGame.Races;
using Assets.Scripts.Simulation.Towers.Weapons;

using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;

using Assets.Scripts.Unity.UI_New.Main;

using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Models.Towers;

using Assets.Scripts.Unity;



using Assets.Scripts.Simulation.Towers;


using Assets.Scripts.Utils;


using Il2CppSystem.Collections;

using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Models;
using TMPro;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using System;
using Assets.Scripts.Simulation.Towers.Behaviors;
using UnityEngine;
using Assets.Scripts.Unity.Display;
using System.Linq;
using System.IO;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper.Extensions;

namespace model_dumper
{
    public class Main : MelonMod
    {



        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            Console.WriteLine("model_dumper loaded");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();




            if (Input.GetKeyDown(KeyCode.F1))
            {
                //Console.WriteLine("getting player");
                //var playerInstance = Game.instance.GetBtd6Player();
                //Console.WriteLine("saving player data");
                //FileIOUtil.SaveObject("Model\\playerdata.json", playerInstance.Data);

                Console.WriteLine("saving towers");
                foreach (TowerModel towerModel in Game.instance.model.towers)
                {
                    if (towerModel.name.Contains("Alchemist"))
                    {
                        foreach (var at in towerModel.GetBehaviors<AttackModel>())
                        {
                            try
                            {
                                //at.weapons[0].projectile.GetBehavior<AddAcidicMixtureToProjectileModel>().mutator = null;
                                at.weapons[0].projectile.RemoveBehavior<AddAcidicMixtureToProjectileModel>();
                                //Console.WriteLine("removed");
                            }
                            catch
                            {

                            }

                        }
                        try
                        {
                            towerModel.GetBehavior<LoadAlchemistBrewInfoModel>().addAcidicMixtureToProjectileModel = null;
                        }
                        catch
                        {

                        }
                        //FileIOUtil.SaveObject("Model\\Towers\\" + towerModel.baseId + "\\" + towerModel.name + ".json", towerModel);
                    }
                    try
                    {
                        FileIOUtil.SaveObject("Model\\Towers\\" + towerModel.baseId + "\\" + towerModel.name + ".json", towerModel);
                    }
                    catch { Console.WriteLine("failed to save " + towerModel.name); }
                }
                var towers = Game.instance.model.towers;

                for (int i = 0; i < towers.Count; i++)
                {
                    towers[i] = null;

                }
                Console.WriteLine("saving entire model");
                FileIOUtil.SaveObject("Model\\entiremodel.json", Game.instance.model);
            }









        }

    }

}