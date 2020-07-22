﻿using System;
using System.Collections.Generic;
using Actor.Player.Camera;
using Data.Values;
using GUI;
using UnityEngine;

namespace Actor.Player {
    public class PlayerData : ActorData {
        [Header("Values")]
        
        [SerializeField] private FloatValue maxArmor;
        [SerializeField] private FloatValue armor;

        private FloatValue MaxArmor => maxArmor;

        public FloatValue Armor { get => armor; set => armor = value; }

        public override void TakeDamage(float value) {
            Debug.Log("PlayerData.TakeDamage - START");
            
            if (Armor > 0) {
                Debug.Log("PlayerData.TakeDamage - SEES ARMOR SHIT");
                Health -= (float)Math.Round(value / Armor);
                Armor -= (float)Math.Round(value);
            } else {
                Health -= value;
            }

            ConvertToTotal();

            Ui_Player_Effects.PlayGuiHurtAnimation();

            if (!IsDead()) return;

            SetDeadStateForPlayer();
        }
        
        private void ConvertToTotal() {
            Health.value = ( Health.value < 0 ) ? 0f : Health.value;
            Armor.value = ( Armor.value < 0 ) ? 0f : Armor.value;
        }
        
        private void SetDeadStateForPlayer() {
            Debug.Log(this.GetType() + " - SetDeadStateForPlayer");

            if( GetComponent<PlayerCharacterController>() != null )
                GetComponent<PlayerCharacterController>().enabled = false;
            
            if( GetComponent<FpsCameraMouseLook>() != null )
                GetComponent<FpsCameraMouseLook>().enabled = false;
            
            if( GetComponent<FpsCameraPitchAngles>() != null )
                GetComponent<FpsCameraPitchAngles>().enabled = false;
            
            if( GetComponent<FpsCameraPitchMovement>() != null )
                GetComponent<FpsCameraPitchMovement>().enabled = false;
            
            if( GameObject.Find("Weapons-Point") != null )
                GameObject.Find("Weapons-Point").SetActive(false);

            if( GameObject.Find("Camera-Point") != null 
                && GameObject.Find("Camera-Point").GetComponent<Rigidbody>().isKinematic == true)
                GameObject.Find("Camera-Point").GetComponent<Rigidbody>().isKinematic = false;
        }

        public void IncreaseHealth(float v) => Health = (Health + v) > MaxHealth
            ? MaxHealth
            : Health + v;

        public void IncreaseArmor(float v) => Armor = (Armor + v) > MaxArmor
            ? MaxArmor
            : MaxArmor + v;
    }
}