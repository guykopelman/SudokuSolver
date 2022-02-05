using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class OptionalSudokuCell : IOptionalCell
    {
        private Location location;
        private List<int> options;
        private int currentOptionIndex;

        public OptionalSudokuCell(Location location, List<int> options)
        {
            this.location = location;
            this.options = options;
            this.currentOptionIndex = 0;
        }
        public Location GetLocation()
        {
            return this.location;
        }
        public void SetLocation(Location location)
        {
            this.location = location;
        }

        public void Reset()
        {
            this.currentOptionIndex = 0;
        }

        public bool IsFirstOption()
        {
            return this.currentOptionIndex == 0;
        }

        public bool IsLastOption()
        {
            return this.currentOptionIndex == this.options.Count - 1;
        }

        public void NextOption()
        {
            this.currentOptionIndex = (this.currentOptionIndex + 1) % this.options.Count;
        }

        public void PrevOption()
        {
            this.currentOptionIndex = (this.currentOptionIndex - 1) % this.options.Count;
        }

        public int GetCurrentOption()
        {
            return this.options[this.currentOptionIndex];
        }
        public int OptionsAmount()
        {
            return this.options.Count;
        }
        public bool Contains(int num){
            return this.options.Contains(num);
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < this.options.Count; i++)
            {
                if (i == this.currentOptionIndex)
                {
                    str += $",({this.options[i]})";
                }
                else
                {
                    str += $",{this.options[i]}";
                }
            }
            return $"[{str.Substring(1)}]";
        }
    }
}
