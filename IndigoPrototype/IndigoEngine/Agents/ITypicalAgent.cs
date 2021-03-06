﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IndigoEngine.Agents
{
	interface ITypicalAgent
	{
		
		/// <summary>
		/// Operations with health characteristic
		/// </summary>
		State CurrentState { get; set; }

		/// <summary>
		/// Operations with agent location in the world grid
		/// </summary>
		Location CurrentLocation { get; set; }

		/// <summary>
		/// Operations with agent inventory
		/// </summary>
		ItemStorage Inventory { get; set; }
		
		/// <summary>
		/// Operations with action feeeback
		/// </summary>
		ActionFeedback CurrentActionFeedback { get; set; }

		/// <summary>
		/// Operations with agent's world
		/// </summary>
        IWorldToAgent HomeWorld{ get; set; }

		/// <summary>
		/// Operations with agent's field of view
		/// </summary>
		Vision CurrentVision { get; set; }  

		/// <summary>
		/// Operations with agent's memory
		/// </summary>
		Memory CurrentMemory { get; set; }

		/// <summary>
		/// Operations with list of skills that are available to agent
		/// </summary>
		List<Skill> SkillsList { get; set; } 

		/// <summary>
		/// Operations with agent's range of view
		/// </summary>
		int AgentsRangeOfView { get; set; }

		/// <summary>
		/// Killing the agent
		/// </summary>
		void CommitSuicide();

		/// <summary>
		/// Making a decision about action in the current phase
		/// </summary>
		void Decide();	
		
        /// <summary>
        /// Modify it's charecterictics each turn.
        /// </summary>
        void StateRecompute();
	}
}
