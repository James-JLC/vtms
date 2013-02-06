/*

insert license info here

*/

using System;
using System.Collections;
using System.Collections.Generic;


namespace VTMS.Model.Entities
{
	/// <summary>
	/// Generated by MyGeneration using the NHibernate Object Mapping 1.3.1 by Grimaldi Giuseppe (giuseppe.grimaldi@infracom.it)
	/// </summary>
	[Serializable]
	public class Alter 
	{
		#region Private Members
		
		// Variabili di stato
		private bool _isChanged;
		private bool _isDeleted;

		// Primary Key(s) 
		private string _serial; 
		
		// Properties 
		private string _category; 
		private string _license; 
		private string _ownername; 
		private string _purpose; 
		private string _owner; 
		private string _newaddress; 
		private string _postaddress; 
		private string _postcode; 
		private string _email; 
		private string _phone; 
		private string _mobile; 
		private string _province; 
		private string _department; 
		private bool _engine;
        private bool _body;
        private bool _color;
        private bool _whole;
        private bool _enginecode;
        private bool _vin;
        private bool _idcode; 
		private string _information; 
		private string _agentname; 
		private string _agentaddress; 
		private string _agentpostcode; 
		private string _agentphone; 
		private string _agentemail; 
		private string _handlername; 
		private string _handlerphone; 
		private string _saver; 
		private DateTime _save_date; 
		private string _printer; 
		private DateTime _print_date; 		

		#endregion

		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Serial
		{
			get { return _serial; }
			set	
			{
				if ( value != null )
					if( value.Length > 15)
						throw new ArgumentOutOfRangeException("Invalid value for Serial", value, value.ToString());
				
				_isChanged |= (_serial != value); _serial = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Category
		{
			get { return _category; }
			set	
			{
				if ( value != null )
					if( value.Length > 20)
						throw new ArgumentOutOfRangeException("Invalid value for Category", value, value.ToString());
				
				_isChanged |= (_category != value); _category = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string License
		{
			get { return _license; }
			set	
			{
				if ( value != null )
					if( value.Length > 10)
						throw new ArgumentOutOfRangeException("Invalid value for License", value, value.ToString());
				
				_isChanged |= (_license != value); _license = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string OwnerName
		{
			get { return _ownername; }
			set	
			{
				if ( value != null )
					if( value.Length > 100)
						throw new ArgumentOutOfRangeException("Invalid value for OwnerName", value, value.ToString());
				
				_isChanged |= (_ownername != value); _ownername = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Purpose
		{
			get { return _purpose; }
			set	
			{
				if ( value != null )
					if( value.Length > 20)
						throw new ArgumentOutOfRangeException("Invalid value for Purpose", value, value.ToString());
				
				_isChanged |= (_purpose != value); _purpose = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Owner
		{
			get { return _owner; }
			set	
			{
				if ( value != null )
					if( value.Length > 100)
						throw new ArgumentOutOfRangeException("Invalid value for Owner", value, value.ToString());
				
				_isChanged |= (_owner != value); _owner = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string NewAddress
		{
			get { return _newaddress; }
			set	
			{
				if ( value != null )
					if( value.Length > 100)
						throw new ArgumentOutOfRangeException("Invalid value for NewAddress", value, value.ToString());
				
				_isChanged |= (_newaddress != value); _newaddress = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string PostAddress
		{
			get { return _postaddress; }
			set	
			{
				if ( value != null )
					if( value.Length > 100)
						throw new ArgumentOutOfRangeException("Invalid value for PostAddress", value, value.ToString());
				
				_isChanged |= (_postaddress != value); _postaddress = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Postcode
		{
			get { return _postcode; }
			set	
			{
				if ( value != null )
					if( value.Length > 10)
						throw new ArgumentOutOfRangeException("Invalid value for Postcode", value, value.ToString());
				
				_isChanged |= (_postcode != value); _postcode = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Email
		{
			get { return _email; }
			set	
			{
				if ( value != null )
					if( value.Length > 100)
						throw new ArgumentOutOfRangeException("Invalid value for Email", value, value.ToString());
				
				_isChanged |= (_email != value); _email = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Phone
		{
			get { return _phone; }
			set	
			{
				if ( value != null )
					if( value.Length > 20)
						throw new ArgumentOutOfRangeException("Invalid value for Phone", value, value.ToString());
				
				_isChanged |= (_phone != value); _phone = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Mobile
		{
			get { return _mobile; }
			set	
			{
				if ( value != null )
					if( value.Length > 20)
						throw new ArgumentOutOfRangeException("Invalid value for Mobile", value, value.ToString());
				
				_isChanged |= (_mobile != value); _mobile = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Province
		{
			get { return _province; }
			set	
			{
				if ( value != null )
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for Province", value, value.ToString());
				
				_isChanged |= (_province != value); _province = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Department
		{
			get { return _department; }
			set	
			{
				if ( value != null )
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for Department", value, value.ToString());
				
				_isChanged |= (_department != value); _department = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual bool Engine
		{
			get { return _engine; }
			set { _isChanged |= (_engine != value); _engine = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual bool Body
		{
			get { return _body; }
			set { _isChanged |= (_body != value); _body = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual bool Color
		{
			get { return _color; }
			set { _isChanged |= (_color != value); _color = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual bool Whole
		{
			get { return _whole; }
			set { _isChanged |= (_whole != value); _whole = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual bool EngineCode
		{
			get { return _enginecode; }
			set { _isChanged |= (_enginecode != value); _enginecode = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual bool Vin
		{
			get { return _vin; }
			set { _isChanged |= (_vin != value); _vin = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual bool IdCode
		{
			get { return _idcode; }
			set { _isChanged |= (_idcode != value); _idcode = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Information
		{
			get { return _information; }
			set	
			{
				if ( value != null )
					if( value.Length > 150)
						throw new ArgumentOutOfRangeException("Invalid value for Information", value, value.ToString());
				
				_isChanged |= (_information != value); _information = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string AgentName
		{
			get { return _agentname; }
			set	
			{
				if ( value != null )
					if( value.Length > 100)
						throw new ArgumentOutOfRangeException("Invalid value for AgentName", value, value.ToString());
				
				_isChanged |= (_agentname != value); _agentname = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string AgentAddress
		{
			get { return _agentaddress; }
			set	
			{
				if ( value != null )
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for AgentAddress", value, value.ToString());
				
				_isChanged |= (_agentaddress != value); _agentaddress = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string AgentPostcode
		{
			get { return _agentpostcode; }
			set	
			{
				if ( value != null )
					if( value.Length > 10)
						throw new ArgumentOutOfRangeException("Invalid value for AgentPostcode", value, value.ToString());
				
				_isChanged |= (_agentpostcode != value); _agentpostcode = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string AgentPhone
		{
			get { return _agentphone; }
			set	
			{
				if ( value != null )
					if( value.Length > 20)
						throw new ArgumentOutOfRangeException("Invalid value for AgentPhone", value, value.ToString());
				
				_isChanged |= (_agentphone != value); _agentphone = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string AgentEmail
		{
			get { return _agentemail; }
			set	
			{
				if ( value != null )
					if( value.Length > 100)
						throw new ArgumentOutOfRangeException("Invalid value for AgentEmail", value, value.ToString());
				
				_isChanged |= (_agentemail != value); _agentemail = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string HandlerName
		{
			get { return _handlername; }
			set	
			{
				if ( value != null )
					if( value.Length > 100)
						throw new ArgumentOutOfRangeException("Invalid value for HandlerName", value, value.ToString());
				
				_isChanged |= (_handlername != value); _handlername = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string HandlerPhone
		{
			get { return _handlerphone; }
			set	
			{
				if ( value != null )
					if( value.Length > 20)
						throw new ArgumentOutOfRangeException("Invalid value for HandlerPhone", value, value.ToString());
				
				_isChanged |= (_handlerphone != value); _handlerphone = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Saver
		{
			get { return _saver; }
			set	
			{
				if ( value != null )
					if( value.Length > 15)
						throw new ArgumentOutOfRangeException("Invalid value for Saver", value, value.ToString());
				
				_isChanged |= (_saver != value); _saver = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual DateTime SaveDate
		{
			get { return _save_date; }
			set { _isChanged |= (_save_date != value); _save_date = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual string Printer
		{
			get { return _printer; }
			set	
			{
				if ( value != null )
					if( value.Length > 10)
						throw new ArgumentOutOfRangeException("Invalid value for Printer", value, value.ToString());
				
				_isChanged |= (_printer != value); _printer = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual DateTime PrintDate
		{
			get { return _print_date; }
			set { _isChanged |= (_print_date != value); _print_date = value; }
		} 
	  
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public virtual bool IsChanged
		{
			get { return _isChanged; }
		}
		
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public virtual bool IsDeleted
		{
			get { return _isDeleted; }
		}
		
		#endregion 
		
		#region Public Functions

		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public virtual void MarkAsDeleted()
		{
			_isDeleted = true;
			_isChanged = true;
		}
		
		#endregion
		
		#region Equals And HashCode Overrides
		
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			Alter castObj = (Alter)obj; 
			return ( castObj != null ) &&
				( this._serial == castObj.Serial );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{ 
			int hash = 57; 
			hash = 27 * hash * this._serial.GetHashCode();
					
			return hash;		
			
		}
		
		#endregion
		
	}
}