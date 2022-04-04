using System;

[Serializable]
public class Player
{
      public int health;
      public int level;
      public int coins;

      public Player()
      {
            health = 3;
            level = 1;
            coins = 0;
      }

      public void Damaged()
      {
            health--;
      }

      public void AddCoin()
      {
            coins++;
            if (coins % 5 == 0)
            {
                  IncreaseLevel();
            }
      }

      private void IncreaseLevel()
      {
            level++;
      }

      public bool IsAlive()
      {
            return health > 0;
      }
}