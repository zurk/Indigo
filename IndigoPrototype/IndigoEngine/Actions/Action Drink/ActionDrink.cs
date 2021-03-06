﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndigoEngine.Agents;
using NLog;

namespace IndigoEngine.Actions
{
    /// <summary>
    /// Action to drink
    /// </summary>
    [Serializable]
	[ActionInfo(
					new Type[]
					{
						typeof(AgentLivingIndigo),
					},
					new Type[]
					{
						typeof(AgentPuddle),
					},
					IsConflict = true,
					RequiresObject = true
				)]
    class ActionDrink : ActionAbstract
    {
		private static Logger logger = LogManager.GetCurrentClassLogger();

        #region Constructors

		public ActionDrink(Agent argSubj, Agent argObj)
			: base(argSubj, argObj)
        {
        }

        #endregion

        /// <summary>
        /// ITypicalAction
        /// </summary>
        public override void CalculateFeedbacks()
        {
            base.CalculateFeedbacks();

            Object.CurrentActionFeedback += new ActionFeedback(() =>
            {
                Object.CurrentState.Health.CurrentUnitValue--;
            });

            Subject.CurrentActionFeedback += new ActionFeedback(() =>
            {
                (Subject as AgentLiving).CurrentState.WaterSatiety.CurrentPercentValue = 100;
            });

        }

		/// <summary>
		/// Override Action.CompareTo
		/// </summary>
		public override int CompareTo(ActionAbstract argActionToCompare)
		{
			if(Object == (argActionToCompare as ActionDrink).Object)
			{
				return 0;
			}
			return 1;
		}
    }
}
