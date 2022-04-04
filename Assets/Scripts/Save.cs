using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
     public Player player;
     public int scene;
     public Vector3 position;
     public Vector3 rotation;
     public bool[] activeCoins;
     private const int NUMBER_OF_COINS = 12;

     public Save(int scene)
     {
          player = new Player();
          position = new Vector3(0, 2, 0);
          rotation = new Vector3(0, 0, 0);
          this.scene = scene;
          
          activeCoins = new bool[NUMBER_OF_COINS];
          for (int i = 0; i < NUMBER_OF_COINS; i++)
          {
               activeCoins[i] = true;
          }
     }
}