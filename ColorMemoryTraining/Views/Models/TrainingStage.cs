using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorMemoryTraining.Business;

namespace ColorMemoryTraining.Views.Models
{
    public class TrainingStageSetting
    {
        public TrainingStage TrainingStage { get; set; }
        public int ClickMaxLimit { get; set; }
    }
    public enum TrainingStage
    {
        /// <summary>
        /// 学习
        /// </summary>
        Learning,
        /// <summary>
        /// 顺序测试
        /// </summary>
        SequentialTesting,
        /// <summary>
        /// 位置测试
        /// </summary>
        LocationTesting,
    }
}
