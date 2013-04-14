﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using IndigoEngine.Actions;

namespace IndigoEngine.Agents
{
    [Serializable]
    public class Vision : ITypicalFieldOfView
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region Constructors

        public Vision()
        {
            RangeOfView = 0;
            CurrentView = new List<NameableObject>();
        }

        #endregion

        #region Properties

        public int RangeOfView { get; set; } //Range of view of the agent (in cells around agent, apparently)		

        public List<NameableObject> CurrentView { get; set; } 	//Current field ov view. Includes all agents & actions, that current agent can see		

        /// <summary>
        /// ITypicalFieldOfView
        /// </summary>
        public List<Agent> CurrentViewAgents
        {
            get
            {
				List<Agent> result = new List<Agent>();
				foreach(Agent ag in CurrentView.Where(val => { return val is Agent; }))
				{
					result.Add(ag);
				}
                return result;
            }
        }

        /// <summary>
        /// ITypicalFieldOfView
        /// </summary>
        public List<ActionAbstract> CurrentViewActions
        {
            get
            {
				List<ActionAbstract> result = new List<ActionAbstract>();
				foreach(ActionAbstract act in CurrentView.Where(val => { return val is ActionAbstract; }))
				{
					result.Add(act);
				}
                return result;
            }
        }


        #endregion

        #region ObjectMethodsOverride

        #endregion
    }
}
