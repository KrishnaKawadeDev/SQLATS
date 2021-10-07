using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    public class Table : DTIRecord
    {
        private List<Index> _indexes;
        private List<Index> _stats;

        public List<Index> Indexes
        {
            get { return _indexes; }
        }
        public List<Index> Stats
        {
            get { return _stats; }
        }
       
        public int NumberIndexes
        {
            get { return _indexes.Count; }
        }
        public int NumberStats
        {
            get { return _stats.Count; }
        }
        private Selectivity _selectivity = new Selectivity();

        public int NumberCriticalIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if(!i.IsFiltered && i.AverageFragLevel >= ProductConstants.CriticalPercent_Fragmentation && i.AverageFragLevel <= 1.0) 
                        count++;
                }
                return count;
            }            
        }

        public int NumberCautionIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if (!i.IsFiltered && i.AverageFragLevel > ProductConstants.AccpetablePercent_Fragmentation && i.AverageFragLevel < ProductConstants.CriticalPercent_Fragmentation)
                        count++;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if (!i.IsFiltered && i.AverageFragLevel <= ProductConstants.AccpetablePercent_Fragmentation && i.AverageFragLevel >= 0.0)
                        count++;
                }
                return count;
            }
        }
        public int NumberCriticalSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if (!i.IsFiltered && i.UsefulnessSummary == IndexUsefulness.Low)
                        count++;
                }
                return count;
            }
        }
        public int NumberCautionSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if (!i.IsFiltered && i.UsefulnessSummary == IndexUsefulness.Medium)
                        count++;
                }
                return count;
            }
        }
        public int NumberAcceptableSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if (!i.IsFiltered && i.UsefulnessSummary == IndexUsefulness.High)
                        count++;
                }
                return count;
            }
        }

        public int NumberCriticalIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if (!i.IsFiltered && (_selectivity.calculate_selectivity(i.AverageDensity,i.Rows)) <= ProductConstants.CriticalPercent_Selectivity && (_selectivity.calculate_selectivity(i.AverageDensity,i.Rows)) >= 0.0)
                        count++;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if (!i.IsFiltered && (_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) < ProductConstants.AccpetablePercent_Selectivity && (_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) > ProductConstants.CriticalPercent_Selectivity)
                        count++;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    if (!i.IsFiltered && (_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) >= ProductConstants.AccpetablePercent_Selectivity && (_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) < 1.1)
                        count++;
                }
                return count;
            }
        }

        public int NumberCriticalIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    double ratio = i.Rows == 0 ? -1.0 : i.ModifiedRows > i.Rows ? 1.0 : (double) i.ModifiedRows/i.Rows;
                    if (!i.IsFiltered && ratio >= ProductConstants.CriticalPercent_Modified && ratio <= 1.0)
                        count++;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    double ratio = (i.Rows == 0 ? -1.0 : i.ModifiedRows > i.Rows ? 1.0 : (double) i.ModifiedRows/i.Rows);
                    if (!i.IsFiltered && ratio > ProductConstants.AccpetablePercent_Modified && ratio < ProductConstants.CriticalPercent_Modified)
                        count++;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    double ratio = i.Rows == 0 ? -1.0 : i.ModifiedRows > i.Rows ? 1.0 : (double) i.ModifiedRows/i.Rows;
                    if (!i.IsFiltered && ratio <= ProductConstants.AccpetablePercent_Modified && ratio >= 0.0)
                        count++;
                }
                return count;
            }
        }

        public int NumberCriticalIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    double ratio = i.TotalAccess == 0 ? 0 : (double) i.Updates/i.TotalAccess;
                    if (!i.IsFiltered && ratio >= ProductConstants.CriticalPercent_Usage && ratio <= 1.0)
                        count++;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    double ratio = i.TotalAccess == 0 ? 0 : (double) i.Updates/i.TotalAccess;
                    if (!i.IsFiltered && ratio > ProductConstants.AccpetablePercent_Usage && ratio < ProductConstants.CriticalPercent_Usage)
                        count++;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Index i in _indexes)
                {
                    double ratio = i.TotalAccess == 0 ? 0 : (double) i.Updates/i.TotalAccess;
                    if (!i.IsFiltered && ratio <= ProductConstants.AccpetablePercent_Usage && ratio >= 0.0)
                        count++;
                }
                return count;
            }
        }


        public int NumberCriticalStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Index i in _stats)
                {
                    if ((_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) <= ProductConstants.CriticalPercent_Selectivity && (_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) >= 0.0)
                        count++;
                }
                return count;
            }
        }
        public int NumberCautionStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Index i in _stats)
                {
                    if ((_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) < ProductConstants.AccpetablePercent_Selectivity && (_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) > ProductConstants.CriticalPercent_Selectivity)
                        count++;
                }
                return count;
            }
        }
        public int NumberAcceptableStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Index i in _stats)
                {
                    if ((_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) >= ProductConstants.AccpetablePercent_Selectivity && (_selectivity.calculate_selectivity(i.AverageDensity, i.Rows)) < 2)
                        count++;
                }
                return count;
            }
        }



        public Table()
        {
            _indexes = new List<Index>();
            _stats = new List<Index>();
        }
    }
}
