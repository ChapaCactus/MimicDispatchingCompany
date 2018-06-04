using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class CharacterData
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharacterData(CharaName name, Level level, Health health, Power power, Defense defense)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.power = power;
            this.defense = defense;
        }

        public class CharaName
        {
            public CharaName(string charaName, string title)
            {
                this.charaName = charaName;
                this.title = title;
            }

            // 名前
            public string charaName { get; private set; }
            // 肩書き
            public string title { get; private set; }
        }

        public class Level
        {
            public Level(int level, int exp, int next)
            {
                this.level = level;
                this.exp = exp;
                this.next = next;
            }

            // Lv
            public int level { get; private set; }
            // 経験値
            public int exp { get; private set; }
            // 次のレベルまで
            public int next { get; private set; }
        }

        public class Health
        {
            public Health(int health, int maxHealth)
            {
                this.health = health;
                this.maxHealth = maxHealth;

                Assert.IsTrue(health <= maxHealth);
            }

            // HP
            public int health { get; private set; }
            // 最大HP
            public int maxHealth { get; private set; }

            // 死亡しているか
            public bool IsDead { get { return health <= 0; } }

            public void Damage(int damage)
            {
                health -= Mathf.Abs(damage);

                if (health < 0)
                    health = 0;
            }

            public void Cure(int cure)
            {
                health += Mathf.Abs(cure);
                if (health > maxHealth)
                    health = maxHealth;
            }

            public void FullCure()
            {
                Cure(maxHealth);
            }
        }

        public class Power
        {
            public Power(int basePower)
            {
                this.basePower = basePower;
            }

            public int basePower { get; private set; }

            public int GetTotalPower()
            {
                return basePower;
            }
        }

        public class Defense
        {
            public Defense(int baseDefense)
            {
                this.baseDefense = baseDefense;
            }

            public int baseDefense { get; private set; }

            public int GetTotalDefense()
            {
                return baseDefense;
            }
        }

        public CharaName name { get; private set; }
        public Level level { get; private set; }
        public Health health { get; private set; }

        public Power power { get; private set; }
        public Defense defense { get; private set; }

        public static CharacterData CreateDummyData()
        {
            var name = new CharaName("名前", "二つ名");
            var level = new Level(1, 0, 0);
            var health = new Health(100, 100);
            var power = new Power(4);
            var defense = new Defense(1);
            return new CharacterData(name, level, health, power, defense);
        }

        public static CharacterData CreateEnemyDummyData()
        {
            var name = new CharaName("敵", "二つ名");
            var level = new Level(1, 0, 0);
            var health = new Health(5, 5);
            var power = new Power(3);
            var defense = new Defense(1);
            return new CharacterData(name, level, health, power, defense);
        }
    }
}