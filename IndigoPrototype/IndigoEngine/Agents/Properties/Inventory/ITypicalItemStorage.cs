﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndigoEngine.Agents
{
	public interface ITypicalItemStorage
	{
		/// <summary>
		/// Operations with item storage content
		/// </summary>
		List<Agent> ItemList { get; set; }

		/// <summary>
		/// Operations with storage size
		/// </summary>
		int StorageSize { get; set; }

		/// <summary>
		/// Operations with pwner of the current item storage
		/// </summary>
		Agent Owner { get; set; }

		/// <summary>
		/// Dropping all items from the storage on the owner coords
		/// </summary>
		void DropAll();

		/// <summary>
		/// Adding a new agent into storage
		/// </summary>
		/// <param name="argAgent">Agent to add</param>
		/// <returns>Success state</returns>
		bool AddAgentToStorage(Agent argAgent);

        /// <summary>
        ///  If ItemList consists Agent with type agentType, it will be removed from list
        /// </summary>
        /// <param name="agentType">type of agent</param>
        void DeleteAgentsByType(Type agentType, int argCountToDelete);

        /// <summary>
        /// If ItemList consists Agent with type agentType, it will not be removed from list
         /// </summary>
        /// <param name="agentType">type of agent</param>
        /// <returns> agent with type agentType</returns>
        Agent GetAgentByType(Type agentType);

		/// <summary>
		/// Getting the specified agent from the storage
		/// </summary>
		/// <param name="argAgent">Specifier for agent</param>
		/// <returns>Agent, that matches and no more in storage</returns>
		Agent PopAgent(Agent argAgent);

		/// <summary>
		/// Getting the agent, that matches the type, from the storage
		/// </summary>
		/// <param name="argType">Type of the agent to find</param>
		/// <returns>Agent, that matches and no more in storage</returns>
		Agent PopAgentByType(Type argType);
				
		/// <summary>
		/// Shows, if the agent of type argType exists in the ItemStorage
		/// </summary>
		/// <param name="argType">type wich is searching</param>
		/// <returns>true - if agent exists, false - vice versa</returns>
        bool ExistsAgentByType(Type argType);

		/// <summary>
		/// Counting number of agents, that match the type argType
		/// </summary>
		/// <param name="argType">type wich is searching</param>
		/// <returns>Number of matching agents</returns>
		int NumberOfAgentsByType(Type argType);
	}
}
