using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialVkr
{
    public class Equipment
    {
        public double Failures { get; set; }
        public double Downtime { get; set; }
        public double AdditiveCriterion { get; set; }
    }

    public class AdditiveCriterionAnalyzis
    {
        public List<Equipment> Calculate(List<Equipment> equipmentList)
        {
            double[] failures = equipmentList.Select(e => e.Failures).ToArray();
            double[] downtimes = equipmentList.Select(e => e.Downtime).ToArray();

            double[] normalizedFailures = Normalize(failures);
            double[] normalizedDowntimes = Normalize(downtimes);

            double failureWeight = 0.7;
            double downtimeWeight = 0.3;

            for (int i = 0; i < equipmentList.Count; i++)
            {
                equipmentList[i].AdditiveCriterion =
                    normalizedFailures[i] * failureWeight +
                    normalizedDowntimes[i] * downtimeWeight;
            }

            return equipmentList;
        }

        private static double[] Normalize(double[] values)
        {
            double min = values.Min();
            double max = values.Max();
            return values.Select(v => (v - min) / (max - min)).ToArray();
        }
    }
}
