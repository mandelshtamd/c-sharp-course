using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allergies
{
    class AllergiesScoreTable
    {
        private Dictionary<string, int>  _scoreTable = new Dictionary<string, int>();
        private Dictionary<int, string> _reverseScoreTable = new Dictionary<int, string>();

        public AllergiesScoreTable() 
        {
            _scoreTable.Add("Eggs", 1);
            _scoreTable.Add("Peanuts", 2);
            _scoreTable.Add("Molluscs", 4);
            _scoreTable.Add("Strawberries", 8);
            _scoreTable.Add("Tomatoes", 16);
            _scoreTable.Add("Chocolate", 32);
            _scoreTable.Add("Dust", 64);
            _scoreTable.Add("Cats", 128);

            foreach(var el in _scoreTable)
            {
                _reverseScoreTable.Add(el.Value, el.Key);
            }
        }

        public List<Tuple<string, int>> getAllergiesByScore(int score)
        {
            var ans = new List<Tuple<string, int>>();
            if (score > 255)
            {
                throw new ArgumentOutOfRangeException("score is too high");
            }

            var currPower = 7;
            while (currPower >= 0)
            {
                if (score >= Math.Pow(2, currPower))
                {
                    var currAllergenScore = (int)Math.Pow(2, currPower);
                    score -= currAllergenScore;
                    ans.Add(new Tuple<string, int>(_reverseScoreTable[currAllergenScore], currAllergenScore));
                }
                currPower--;
            }

            ans.Reverse();

            return ans;
        }

        
        public int getScoreByAllergies(List<string> allergies)
        {
            int score = 0;
            foreach(var allergen in allergies)
            {
                score += _scoreTable[allergen];
            }

            return score;
        }

        public int getAllergyScore(string allergen)
        {
            return _scoreTable[allergen];
        }
    }
}
