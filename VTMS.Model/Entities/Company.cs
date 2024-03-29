using System;
using System.Collections;
using System.Collections.Generic;


namespace VTMS.Model.Entities
{
	/// <summary>
	/// Generated by MyGeneration using the NHibernate Object Mapping 1.3.1 by Grimaldi Giuseppe (giuseppe.grimaldi@infracom.it)
	/// </summary>
	[Serializable]
	public class Company 
	{
		#region Private Members
	
		// Primary Key(s) 
		private string _id; 
		
		// Properties 
		private string _name; 
		private int _priority; 
		private bool _isactive; 		

		#endregion
		
		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Id
		{
			get { return _id; }
			set	
			{
				_id = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Name
		{
			get { return _name; }
			set	
			{
				_name = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual int Priority
		{
			get { return _priority; }
            set
            {
                _priority = value;
            }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual bool Isactive
		{
			get { return _isactive; }
            set
            {
                _isactive = value;
            }
		} 
		#endregion
	}
}