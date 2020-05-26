﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Saaloon.Context
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PortalEdu")]
	public partial class DBPortalEduDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    partial void InsertAlumno(Alumno instance);
    partial void UpdateAlumno(Alumno instance);
    partial void DeleteAlumno(Alumno instance);
    partial void InsertCursos(Cursos instance);
    partial void UpdateCursos(Cursos instance);
    partial void DeleteCursos(Cursos instance);
    #endregion
		
		public DBPortalEduDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["PortalEduConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBPortalEduDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBPortalEduDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBPortalEduDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBPortalEduDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Usuario> Usuario
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
		
		public System.Data.Linq.Table<Alumno> Alumno
		{
			get
			{
				return this.GetTable<Alumno>();
			}
		}
		
		public System.Data.Linq.Table<Cursos> Cursos
		{
			get
			{
				return this.GetTable<Cursos>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ModificaAlumno")]
		public ISingleResult<SP_ModificaAlumnoResult> SP_ModificaAlumno([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> idAlumno, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string nombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string apellido, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> fecha_n, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Char(1)")] System.Nullable<char> genero)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idAlumno, nombre, apellido, fecha_n, genero);
			return ((ISingleResult<SP_ModificaAlumnoResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdUsuario;
		
		private string _Usuario1;
		
		private string _correo;
		
		private string _contraseña;
		
		private System.Nullable<int> _tipo;
		
		private EntitySet<Alumno> _Alumno;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdUsuarioChanging(int value);
    partial void OnIdUsuarioChanged();
    partial void OnUsuario1Changing(string value);
    partial void OnUsuario1Changed();
    partial void OncorreoChanging(string value);
    partial void OncorreoChanged();
    partial void OncontraseñaChanging(string value);
    partial void OncontraseñaChanged();
    partial void OntipoChanging(System.Nullable<int> value);
    partial void OntipoChanged();
    #endregion
		
		public Usuario()
		{
			this._Alumno = new EntitySet<Alumno>(new Action<Alumno>(this.attach_Alumno), new Action<Alumno>(this.detach_Alumno));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUsuario", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdUsuario
		{
			get
			{
				return this._IdUsuario;
			}
			set
			{
				if ((this._IdUsuario != value))
				{
					this.OnIdUsuarioChanging(value);
					this.SendPropertyChanging();
					this._IdUsuario = value;
					this.SendPropertyChanged("IdUsuario");
					this.OnIdUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Usuario", Storage="_Usuario1", DbType="VarChar(60)")]
		public string Usuario1
		{
			get
			{
				return this._Usuario1;
			}
			set
			{
				if ((this._Usuario1 != value))
				{
					this.OnUsuario1Changing(value);
					this.SendPropertyChanging();
					this._Usuario1 = value;
					this.SendPropertyChanged("Usuario1");
					this.OnUsuario1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_correo", DbType="VarChar(60)")]
		public string correo
		{
			get
			{
				return this._correo;
			}
			set
			{
				if ((this._correo != value))
				{
					this.OncorreoChanging(value);
					this.SendPropertyChanging();
					this._correo = value;
					this.SendPropertyChanged("correo");
					this.OncorreoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contraseña", DbType="VarChar(30)")]
		public string contraseña
		{
			get
			{
				return this._contraseña;
			}
			set
			{
				if ((this._contraseña != value))
				{
					this.OncontraseñaChanging(value);
					this.SendPropertyChanging();
					this._contraseña = value;
					this.SendPropertyChanged("contraseña");
					this.OncontraseñaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tipo", DbType="Int")]
		public System.Nullable<int> tipo
		{
			get
			{
				return this._tipo;
			}
			set
			{
				if ((this._tipo != value))
				{
					this.OntipoChanging(value);
					this.SendPropertyChanging();
					this._tipo = value;
					this.SendPropertyChanged("tipo");
					this.OntipoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Alumno", Storage="_Alumno", ThisKey="IdUsuario", OtherKey="idUsuario")]
		public EntitySet<Alumno> Alumno
		{
			get
			{
				return this._Alumno;
			}
			set
			{
				this._Alumno.Assign(value);
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
		
		private void attach_Alumno(Alumno entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_Alumno(Alumno entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Alumno")]
	public partial class Alumno : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdAlumno;
		
		private string _nombre;
		
		private string _apellido;
		
		private System.Nullable<System.DateTime> _fecha_n;
		
		private System.Nullable<char> _genero;
		
		private System.Nullable<int> _idUsuario;
		
		private EntityRef<Usuario> _Usuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdAlumnoChanging(int value);
    partial void OnIdAlumnoChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OnapellidoChanging(string value);
    partial void OnapellidoChanged();
    partial void Onfecha_nChanging(System.Nullable<System.DateTime> value);
    partial void Onfecha_nChanged();
    partial void OngeneroChanging(System.Nullable<char> value);
    partial void OngeneroChanged();
    partial void OnidUsuarioChanging(System.Nullable<int> value);
    partial void OnidUsuarioChanged();
    #endregion
		
		public Alumno()
		{
			this._Usuario = default(EntityRef<Usuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdAlumno", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdAlumno
		{
			get
			{
				return this._IdAlumno;
			}
			set
			{
				if ((this._IdAlumno != value))
				{
					this.OnIdAlumnoChanging(value);
					this.SendPropertyChanging();
					this._IdAlumno = value;
					this.SendPropertyChanged("IdAlumno");
					this.OnIdAlumnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="VarChar(30)")]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apellido", DbType="VarChar(30)")]
		public string apellido
		{
			get
			{
				return this._apellido;
			}
			set
			{
				if ((this._apellido != value))
				{
					this.OnapellidoChanging(value);
					this.SendPropertyChanging();
					this._apellido = value;
					this.SendPropertyChanged("apellido");
					this.OnapellidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_n", DbType="DateTime")]
		public System.Nullable<System.DateTime> fecha_n
		{
			get
			{
				return this._fecha_n;
			}
			set
			{
				if ((this._fecha_n != value))
				{
					this.Onfecha_nChanging(value);
					this.SendPropertyChanging();
					this._fecha_n = value;
					this.SendPropertyChanged("fecha_n");
					this.Onfecha_nChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_genero", DbType="Char(1)")]
		public System.Nullable<char> genero
		{
			get
			{
				return this._genero;
			}
			set
			{
				if ((this._genero != value))
				{
					this.OngeneroChanging(value);
					this.SendPropertyChanging();
					this._genero = value;
					this.SendPropertyChanged("genero");
					this.OngeneroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idUsuario", DbType="Int")]
		public System.Nullable<int> idUsuario
		{
			get
			{
				return this._idUsuario;
			}
			set
			{
				if ((this._idUsuario != value))
				{
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidUsuarioChanging(value);
					this.SendPropertyChanging();
					this._idUsuario = value;
					this.SendPropertyChanged("idUsuario");
					this.OnidUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Alumno", Storage="_Usuario", ThisKey="idUsuario", OtherKey="IdUsuario", IsForeignKey=true)]
		public Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.Alumno.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.Alumno.Add(this);
						this._idUsuario = value.IdUsuario;
					}
					else
					{
						this._idUsuario = default(Nullable<int>);
					}
					this.SendPropertyChanged("Usuario");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cursos")]
	public partial class Cursos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdCurso;
		
		private string _Nombre;
		
		private string _Descripcion;
		
		private string _Recursos;
		
		private System.Nullable<decimal> _Costo;
		
		private System.Nullable<int> _idTemario;
		
		private System.Nullable<int> _idDocente;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdCursoChanging(int value);
    partial void OnIdCursoChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnDescripcionChanging(string value);
    partial void OnDescripcionChanged();
    partial void OnRecursosChanging(string value);
    partial void OnRecursosChanged();
    partial void OnCostoChanging(System.Nullable<decimal> value);
    partial void OnCostoChanged();
    partial void OnidTemarioChanging(System.Nullable<int> value);
    partial void OnidTemarioChanged();
    partial void OnidDocenteChanging(System.Nullable<int> value);
    partial void OnidDocenteChanged();
    #endregion
		
		public Cursos()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdCurso", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdCurso
		{
			get
			{
				return this._IdCurso;
			}
			set
			{
				if ((this._IdCurso != value))
				{
					this.OnIdCursoChanging(value);
					this.SendPropertyChanging();
					this._IdCurso = value;
					this.SendPropertyChanged("IdCurso");
					this.OnIdCursoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(30)")]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="VarChar(200)")]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this.OnDescripcionChanging(value);
					this.SendPropertyChanging();
					this._Descripcion = value;
					this.SendPropertyChanged("Descripcion");
					this.OnDescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Recursos", DbType="VarChar(30)")]
		public string Recursos
		{
			get
			{
				return this._Recursos;
			}
			set
			{
				if ((this._Recursos != value))
				{
					this.OnRecursosChanging(value);
					this.SendPropertyChanging();
					this._Recursos = value;
					this.SendPropertyChanged("Recursos");
					this.OnRecursosChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Costo", DbType="Money")]
		public System.Nullable<decimal> Costo
		{
			get
			{
				return this._Costo;
			}
			set
			{
				if ((this._Costo != value))
				{
					this.OnCostoChanging(value);
					this.SendPropertyChanging();
					this._Costo = value;
					this.SendPropertyChanged("Costo");
					this.OnCostoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idTemario", DbType="Int")]
		public System.Nullable<int> idTemario
		{
			get
			{
				return this._idTemario;
			}
			set
			{
				if ((this._idTemario != value))
				{
					this.OnidTemarioChanging(value);
					this.SendPropertyChanging();
					this._idTemario = value;
					this.SendPropertyChanged("idTemario");
					this.OnidTemarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idDocente", DbType="Int")]
		public System.Nullable<int> idDocente
		{
			get
			{
				return this._idDocente;
			}
			set
			{
				if ((this._idDocente != value))
				{
					this.OnidDocenteChanging(value);
					this.SendPropertyChanging();
					this._idDocente = value;
					this.SendPropertyChanged("idDocente");
					this.OnidDocenteChanged();
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
	
	public partial class SP_ModificaAlumnoResult
	{
		
		private string _Mensaje;
		
		public SP_ModificaAlumnoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mensaje", DbType="VarChar(31) NOT NULL", CanBeNull=false)]
		public string Mensaje
		{
			get
			{
				return this._Mensaje;
			}
			set
			{
				if ((this._Mensaje != value))
				{
					this._Mensaje = value;
				}
			}
		}
	}
}
#pragma warning restore 1591