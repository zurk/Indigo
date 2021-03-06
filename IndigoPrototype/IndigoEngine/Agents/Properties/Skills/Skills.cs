﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace IndigoEngine.Agents
{
	/// <summary>
	/// Class of all avaliable skills
	/// </summary>
    [Serializable]
	public static class Skills
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static Skill GetSkillByName(string argName)
		{
			Skill result;	//Result of the function

			result = new Skill();
			result.Name = argName;
			return result;			
		}

		/// <summary>
		/// Default skill of woodcutting
		/// </summary>
		public static Skill Woodcutting	
		{
			get
			{
				Skill result;	//Result of the function

				result = new Skill();
				result.Name = "Woodcutting";
				return result;
			}
		}

		/// <summary>	
		/// Default skill of camp constructing
		/// </summary>
		public static Skill CampConstructing
		{
			get
			{
				Skill result;	//Result of the function
				
				result = new Skill();
				result.Name = "CampConstructing";
				return result;
			}
		}

		/// <summary>
		/// Default skill of camp gathering
		/// </summary>
		public static Skill Gathering
		{
			get
			{
				Skill result;	//Result of the function

				result = new Skill();
				result.Name = "Gathering";
				return result;
			}
		}

		/// <summary>
		/// Default skill of camp communicationing
		/// </summary>
		public static Skill Communicationing
		{
			get
			{
				Skill result;	//Result of the function

				result = new Skill();
				result.Name = "Communicationing";
				return result;
			}
		}
	}
}
