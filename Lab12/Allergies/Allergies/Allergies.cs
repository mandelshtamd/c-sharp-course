using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allergies
{
    class Allergies
    {
        private string _personName;
        public string Name
        {
            get { return _personName; }
        }

        private List<Tuple<string, int>> _allergiesList = new List<Tuple<string, int>>();

        private int _score;
        public int Score
        {
            get { return _score; }
        }

        public Allergies(string personName, int score = 0) {
            var scoreTable = new AllergiesScoreTable();
            _personName = personName;
            _score = score;

            if (score != 0)
            {
                _allergiesList = scoreTable.getAllergiesByScore(score);
            }
        }

        public Allergies(string personName, string AllergensString) {
            var scoreTable = new AllergiesScoreTable();
            _personName = personName;

            if (AllergensString == "")
            {
                _score = 0;
            }
            else
            {
                List<string> allergies = new List<string>(AllergensString.Split(" "));

                var sumScore = 0;
                foreach(var allergen in allergies)
                {
                    var currAllergenScore = scoreTable.getAllergyScore(allergen);
                    sumScore += currAllergenScore;
                    _allergiesList.Add(new Tuple<string, int>(allergen, scoreTable.getAllergyScore(allergen)));
                }

                _allergiesList.Sort((x, y) => x.Item2.CompareTo(y.Item2));

                _score = sumScore;
            }
        }

        public override string ToString()
        {
            if (_allergiesList.Count == 0)
                return $"{Name} has no allergies";

            if (_allergiesList.Count == 1)
                return $"{Name} is allergic to {_allergiesList[0].ToPrettyString()}";

            if (_allergiesList.Count == 2)
                return $"{Name} is allergic to {_allergiesList[0].ToPrettyString()} and {_allergiesList[1].ToPrettyString()}";

            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} is allergic to ");

            for (int i = 0; i < _allergiesList.Count - 2; i++)
            {
                sb.Append(_allergiesList[i].ToPrettyString() + ", ");
            }
            sb.Append($"{_allergiesList[_allergiesList.Count - 2].ToPrettyString()} and {_allergiesList[_allergiesList.Count - 1].ToPrettyString()}");

            return sb.ToString();
        }

        public bool IsAllergicTo(string allergen)
        {
            return _allergiesList.Any(m => m.Item1 == allergen);
        }

        public bool IsAllergicTo(Allergen allergen)
        {
            return IsAllergicTo(allergen.ToString());
        }

        public void AddAlergy(string allergen)
        {
            if (IsAllergicTo(allergen))
                return;
            AllergiesScoreTable scoreTable = new AllergiesScoreTable();

            var allergenScore = scoreTable.getAllergyScore(allergen);
            _allergiesList.Add(new Tuple<string, int>(allergen, allergenScore));
            _allergiesList.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            _score += allergenScore;
        }

        public void AddAlergy(Allergen allergen)
        {
            var allergenString = allergen.ToString();
            AddAlergy(allergenString);
        }

        public void DeleteAllergy(string allergen)
        {
            if (!IsAllergicTo(allergen))
                return;

            AllergiesScoreTable scoreTable = new AllergiesScoreTable();
            var allergenScore = scoreTable.getAllergyScore(allergen);
            _score -= allergenScore;
            _allergiesList.Remove(new Tuple<string, int>(allergen, allergenScore));
        }

        public void DeleteAllergy(Allergen allergen)
        {
            var allergenString = allergen.ToString();
            DeleteAllergy(allergenString);
        }
    }
    // размещайте объявление энумов в начале файла
    // элементам энумов можно задавать численные значения и использовать их при вычислениях
    enum Allergen
    {
        Eggs, // =1 
        Peanuts, //=2
        Molluscs,
        Strawberries,
        Tomatoes,
        Chocolate,
        Dust, // =64
        Cats // =128
    }
}
