using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace project
{
    public class Wave
    {

        public List<String> enemyList { get; set; }
        public List<int> enemyHP { get; set; }
        public List<Vector2> enemyPos { get; set; }
        public List<int> enemyPattern { get; set; }
    }

    /*int id;
    public List<Enemy> enemyList;
    public List<int> enemyHP;
    public List<Vector2> enemyPos;
    public List<int> enemyPattern;
    */
    //public List<Enemy> bossList;

       /* public Wave(int id)
        {
            // hp pos attack
            this.id = id;
            this.enemyList = new List<Enemy>();
            this.enemyHP = new List<int>();
            this.enemyPos = new List<Vector2>();
            this.enemyPattern = new List<int>();
            this.bossList = new List<Enemy>();
            this.bossList = new List<Enemy>();
        }

        public void addEnemy(Enemy enemy)
        {
             this.enemyList.Add(enemy);
        }
        public void addEnemyHP(int hp)
        {
            this.enemyHP.Add(hp);
        }

        public void addEnemyPOS(Vector2 pos)
        {
            this.enemyPos.Add(pos);
        }
        public void addPattern(int pattern)
        {
            this.enemyPattern.Add(pattern);
        }*/

}
