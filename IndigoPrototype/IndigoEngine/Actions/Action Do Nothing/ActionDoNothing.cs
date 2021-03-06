﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndigoEngine.Agents;
using NLog;

namespace IndigoEngine.Actions
{
	/// <summary>
	/// Action for agent to do nothing at this iteration. Indigo gets +1 to aggressivnes
	/// </summary>
    [Serializable]
	[ActionInfo(
					new Type[]
					{
						typeof(AgentLivingIndigo),
						typeof(AgentManMadeShelterCamp),
						typeof(AgentItemFoodFruit),
						typeof(AgentItemResLog),
						typeof(AgentPuddle),
						typeof(AgentTree)
					},
					new Type[]
					{
					},
					IsConflict = false,
					RequiresObject = false
				)]
	class ActionDoNothing : ActionAbstract
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		#region Constructors

			public ActionDoNothing(Agent argSubj)
			: base(argSubj, null)
			{
			}

		#endregion		

		public override void CalculateFeedbacks()
		{
			base.CalculateFeedbacks();
			if(Subject is AgentLivingIndigo)
			{
				(Subject as AgentLivingIndigo).CurrentState.Stamina.CurrentUnitValue++;
				(Subject as AgentLivingIndigo).CurrentState.Strenght.CurrentUnitValue++;
				(Subject as AgentLiving).CurrentState.Peacefulness.CurrentUnitValue--;  //They are becoming more aggressive. Spike for attackig each other
			}
		}

		public override int CompareTo(ActionAbstract argActionToCompare)
		{
			return 1; //Action isn't conflict
		}
	}
}
