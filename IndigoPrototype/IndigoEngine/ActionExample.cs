﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndigoEngine.Agents;

namespace IndigoEngine
{
	/// <summary>
	/// Example of action. Delete it after you invent some actual actions
	/// </summary>
    public class ActionAttack : Action
    {
        int hitPointsToTakeOff;

		#region Constructors

		public ActionAttack(Agent argObj, Agent argSubj, int argHitPointsToTakeOff) 
			: base(argObj, argSubj)
        {
            HitPointsToTakeOff = argHitPointsToTakeOff;
            MayBeConflict = true;
        }

		#endregion

		#region Properties

		public int HitPointsToTakeOff
		{
			get { return hitPointsToTakeOff; }
			set { hitPointsToTakeOff = value; }
		}

		#endregion

		/// <summary>
		/// ITypicalAction
		/// </summary>
        public override void Perform()
        {
            if (Object.Health.CurrentPercentValue > 60)
            {
                Object.CurrentActionFeedback = new ActionFeedback(() => 
				{
					Object.Health.CurrentUnitValue -= HitPointsToTakeOff; 
					if(Object is AgentLiving)
					{
						((AgentLiving)Object).AgentsShortMemory.StoreAction(Subject, this);
					}
				});

                Subject.CurrentActionFeedback = new ActionFeedback(() => 
				{
					if(Subject.Health.CurrentUnitValue + HitPointsToTakeOff <= Subject.Health.MaxValue) 
					{
						Subject.Health.CurrentUnitValue += HitPointsToTakeOff; 
					}
				});
            }
        }

		/// <summary>
		/// ITypicalAction
		/// </summary>
		public override NameableObject CharacteristicsOfSubject()
		{
			if(Object is AgentLivingIndigo && Subject is AgentLivingIndigo)
			{
				return ((AgentLivingIndigo)Subject).Aggressiveness; 
			}

			return base.CharacteristicsOfSubject();
		}

		public override string ToString()
		{
			return "Action: attack; hp: " + HitPointsToTakeOff.ToString();
		}
    }
}
