using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialVkr
{
    public class Equipment
    {
        public int FailureCount { get; set; }
        public int DowntimeDays { get; set; }
        public double NormalizedFailureCount { get; set; }
        public double NormalizedDowntimeDays { get; set; }
        public double AdditiveCriterion { get; set; }
    }

    public class AdditiveCriterionAnalyzis
    {
        public List<Equipment> Calculate(List<Equipment> equipmentList)
        {
            NormalizeAndCalculateCriteria(equipmentList);

            return equipmentList;
        }

        static void NormalizeAndCalculateCriteria(List<Equipment> equipmentList)
        {
            int maxFailureCount = equipmentList.Max(e => e.FailureCount);
            int maxDowntimeDays = equipmentList.Max(e => e.DowntimeDays);

            foreach (var equipment in equipmentList)
            {
                equipment.NormalizedFailureCount = Normalize(equipment.FailureCount, maxFailureCount);
                equipment.NormalizedDowntimeDays = Normalize(equipment.DowntimeDays, maxDowntimeDays);
                equipment.AdditiveCriterion = Math.Round(equipment.NormalizedFailureCount + equipment.NormalizedDowntimeDays, 1);
            }
        }

        static double Normalize(int value, int maxValue)
        {
            if (maxValue == 0)
            {
                return 0;
            }
            return (double)value / maxValue;
        }
    }
}
