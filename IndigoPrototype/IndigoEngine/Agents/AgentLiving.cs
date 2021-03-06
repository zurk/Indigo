﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace IndigoEngine.Agents
{	
	/// <summary>
	/// Basic class for alive agents
	/// </summary>
    [Serializable]
	public abstract class AgentLiving : Agent
	{		
		private static Logger logger = LogManager.GetCurrentClassLogger();

		#region Constructors

			public AgentLiving()
				:base()
			{
				CurrentState = new StateLiving();
				SkillsList = new List<Skill>();	
			}

		#endregion

        #region Properties

			/// <summary>
			/// Current state of the agent, override property from Agent to return StateLiving, instead of State
			/// </summary>	
			public new StateLiving CurrentState  
			{
				get
				{
					return base.CurrentState as StateLiving;
				}
				set
				{
					base.CurrentState = value;
				} 
			} 
        
        #endregion

		public override void StateRecompute()
        {
            if (CurrentState.FoodSatiety.CurrentUnitValue-- == CurrentState.FoodSatiety.MinValue) 
            {
                CurrentState.Health.CurrentUnitValue--;
            }
            if (CurrentState.WaterSatiety.CurrentUnitValue-- == CurrentState.WaterSatiety.MinValue)
            {
                CurrentState.Health.CurrentUnitValue--;
            }
            base.StateRecompute();
        }
	}
}
