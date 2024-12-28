﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartParkingSystem
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Car Reservation DB")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblAccount(tblAccount instance);
    partial void UpdatetblAccount(tblAccount instance);
    partial void DeletetblAccount(tblAccount instance);
    partial void InserttblSlot(tblSlot instance);
    partial void UpdatetblSlot(tblSlot instance);
    partial void DeletetblSlot(tblSlot instance);
    partial void InserttblArrival(tblArrival instance);
    partial void UpdatetblArrival(tblArrival instance);
    partial void DeletetblArrival(tblArrival instance);
    partial void InserttblDeparture(tblDeparture instance);
    partial void UpdatetblDeparture(tblDeparture instance);
    partial void DeletetblDeparture(tblDeparture instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::SmartParkingSystem.Properties.Settings.Default.Car_Reservation_DBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblAccount> tblAccounts
		{
			get
			{
				return this.GetTable<tblAccount>();
			}
		}
		
		public System.Data.Linq.Table<tblSlot> tblSlots
		{
			get
			{
				return this.GetTable<tblSlot>();
			}
		}
		
		public System.Data.Linq.Table<tblArrival> tblArrivals
		{
			get
			{
				return this.GetTable<tblArrival>();
			}
		}
		
		public System.Data.Linq.Table<tblDeparture> tblDepartures
		{
			get
			{
				return this.GetTable<tblDeparture>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblAccount")]
	public partial class tblAccount : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _UserName;
		
		private string _Password;
		
		private string _Email;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public tblAccount()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblSlots")]
	public partial class tblSlot : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Slot_No;
		
		private string _Location;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnSlot_NoChanging(string value);
    partial void OnSlot_NoChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    #endregion
		
		public tblSlot()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Slot_No", DbType="NVarChar(50)")]
		public string Slot_No
		{
			get
			{
				return this._Slot_No;
			}
			set
			{
				if ((this._Slot_No != value))
				{
					this.OnSlot_NoChanging(value);
					this.SendPropertyChanging();
					this._Slot_No = value;
					this.SendPropertyChanged("Slot_No");
					this.OnSlot_NoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NVarChar(50)")]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblArrival")]
	public partial class tblArrival : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Driver_Name;
		
		private string _Car_No;
		
		private string _Stay_Time;
		
		private string _Selected_Slot;
		
		private string _Category;
		
		private System.Nullable<System.DateTime> _Arrive_Time;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnDriver_NameChanging(string value);
    partial void OnDriver_NameChanged();
    partial void OnCar_NoChanging(string value);
    partial void OnCar_NoChanged();
    partial void OnStay_TimeChanging(string value);
    partial void OnStay_TimeChanged();
    partial void OnSelected_SlotChanging(string value);
    partial void OnSelected_SlotChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnArrive_TimeChanging(System.Nullable<System.DateTime> value);
    partial void OnArrive_TimeChanged();
    #endregion
		
		public tblArrival()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Driver_Name", DbType="NVarChar(50)")]
		public string Driver_Name
		{
			get
			{
				return this._Driver_Name;
			}
			set
			{
				if ((this._Driver_Name != value))
				{
					this.OnDriver_NameChanging(value);
					this.SendPropertyChanging();
					this._Driver_Name = value;
					this.SendPropertyChanged("Driver_Name");
					this.OnDriver_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Car_No", DbType="NVarChar(50)")]
		public string Car_No
		{
			get
			{
				return this._Car_No;
			}
			set
			{
				if ((this._Car_No != value))
				{
					this.OnCar_NoChanging(value);
					this.SendPropertyChanging();
					this._Car_No = value;
					this.SendPropertyChanged("Car_No");
					this.OnCar_NoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Stay_Time", DbType="NVarChar(50)")]
		public string Stay_Time
		{
			get
			{
				return this._Stay_Time;
			}
			set
			{
				if ((this._Stay_Time != value))
				{
					this.OnStay_TimeChanging(value);
					this.SendPropertyChanging();
					this._Stay_Time = value;
					this.SendPropertyChanged("Stay_Time");
					this.OnStay_TimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Selected_Slot", DbType="NVarChar(50)")]
		public string Selected_Slot
		{
			get
			{
				return this._Selected_Slot;
			}
			set
			{
				if ((this._Selected_Slot != value))
				{
					this.OnSelected_SlotChanging(value);
					this.SendPropertyChanging();
					this._Selected_Slot = value;
					this.SendPropertyChanged("Selected_Slot");
					this.OnSelected_SlotChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="NVarChar(50)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Arrive_Time", DbType="DateTime")]
		public System.Nullable<System.DateTime> Arrive_Time
		{
			get
			{
				return this._Arrive_Time;
			}
			set
			{
				if ((this._Arrive_Time != value))
				{
					this.OnArrive_TimeChanging(value);
					this.SendPropertyChanging();
					this._Arrive_Time = value;
					this.SendPropertyChanged("Arrive_Time");
					this.OnArrive_TimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblDeparture")]
	public partial class tblDeparture : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Car_No;
		
		private string _Driver;
		
		private string _Type;
		
		private string _Park_Time;
		
		private System.Nullable<decimal> _Amount;
		
		private System.Nullable<System.DateTime> _Departure_Time;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnCar_NoChanging(string value);
    partial void OnCar_NoChanged();
    partial void OnDriverChanging(string value);
    partial void OnDriverChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    partial void OnPark_TimeChanging(string value);
    partial void OnPark_TimeChanged();
    partial void OnAmountChanging(System.Nullable<decimal> value);
    partial void OnAmountChanged();
    partial void OnDeparture_TimeChanging(System.Nullable<System.DateTime> value);
    partial void OnDeparture_TimeChanged();
    #endregion
		
		public tblDeparture()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Car_No", DbType="NVarChar(50)")]
		public string Car_No
		{
			get
			{
				return this._Car_No;
			}
			set
			{
				if ((this._Car_No != value))
				{
					this.OnCar_NoChanging(value);
					this.SendPropertyChanging();
					this._Car_No = value;
					this.SendPropertyChanged("Car_No");
					this.OnCar_NoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Driver", DbType="NVarChar(50)")]
		public string Driver
		{
			get
			{
				return this._Driver;
			}
			set
			{
				if ((this._Driver != value))
				{
					this.OnDriverChanging(value);
					this.SendPropertyChanging();
					this._Driver = value;
					this.SendPropertyChanged("Driver");
					this.OnDriverChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(50)")]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Park_Time", DbType="NVarChar(50)")]
		public string Park_Time
		{
			get
			{
				return this._Park_Time;
			}
			set
			{
				if ((this._Park_Time != value))
				{
					this.OnPark_TimeChanging(value);
					this.SendPropertyChanging();
					this._Park_Time = value;
					this.SendPropertyChanged("Park_Time");
					this.OnPark_TimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Departure_Time", DbType="DateTime")]
		public System.Nullable<System.DateTime> Departure_Time
		{
			get
			{
				return this._Departure_Time;
			}
			set
			{
				if ((this._Departure_Time != value))
				{
					this.OnDeparture_TimeChanging(value);
					this.SendPropertyChanging();
					this._Departure_Time = value;
					this.SendPropertyChanged("Departure_Time");
					this.OnDeparture_TimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
