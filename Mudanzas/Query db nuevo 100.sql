/*USE [master];

DECLARE @kill varchar(8000) = '';  
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('ProyWeb')

EXEC(@kill);


drop database ProyWeb

*/
go
Create database ProyWeb
go
use ProyWeb

go

create table Sede(
id int identity,
alias varchar(5) not null,
ciudad varchar(50) ,
estado varchar(50) ,
latitud float,
longitud float,
tipoSede char(1),
pertenece int
)
go

create table DistanciaSede(
	idSedeOrigen int not null,
	idSedeDestino int not null,
	distancia numeric(12,2) not null, --Distancia en KM,
	tiempo numeric(12,2) not null
)

create table DetalleCamion(
idCamion varchar(7) not null,
idSede int not null
)
go

create table Camion(
id varchar(7)  not null,
kilometraje numeric (12,2),
kilometrajeUltimoServicio numeric(12,2),
capacidadPeso numeric(12,2),
tipoCamion varchar(10),
tipoCombustible varchar(10),
volumen numeric (12,2),
placas varchar(10)
)
go

create table Trace(
idCamion varchar(7)  not null,
movimiento int not null,
estatus char(1),
fecha date,
sedeOrigen varchar(20),
sedeDestino varchar(20),
fechaDisponible date
)
go

create table DetalleReservacion(
idCamion varchar(7)  not null,
folioReservacion int not null,
idChofer varchar(20) not null
)
go

create table Usuario(
id varchar(20) not null,
nombre varchar(50) not null,
primerApellido varchar(50),
segundoApellido varchar(50),
contrasena varchar(64),
telefono varchar(10),
correoElectronico varchar(50) not null,
token varchar(64)  
)

go

--Tabla para cambiar la contrase�a del usuario
create table UsuarioToken(
id int identity,
idUsuario varchar(20) not null,
token varchar(256) not null,
fechaCreacion timestamp
)
go

create table Chofer(
idUsuario varchar(20) not null,
)
go

create table Cliente(
idUsuario varchar(20) not null,
direccion varchar(100)
)
go

create table Administrador(
idUsuario varchar(20) not null  ,
tipoAdministrador varchar(10)
)
go
create table SedeAdministrador(
idSede int not null,
idUsuario varchar(20) not null
)
go



create table Reservacion(
folio int not null,
sedeOrigen varchar(20),
sedeDestino varchar(20),
fechaReservacion date,
tipoCamion varchar(10),
idCliente varchar(20) not null
)
go

create table Pago(
id int not null,
folio int not null,
monto numeric (12,2),
terminacionTarjeta int,
estatus varchar(20),
fecha date
)
go
create table Costos(
id int not null,
concepto varchar(50),
costo numeric (12,2)
)
go

create table Prospecto(
id int identity ,
nombre varchar(50),
primerApellido varchar(50),
segundoApellido varchar(50),
telefono varchar(10),
direccion varchar(1000) not null,
correoElectronico varchar(50),
codigoVerificacion varchar(8)
)
go

create table AltaUsuarios(
tipoUsuario varchar(20) not null,
cantidadUsuarios int not null,
)
go

create table AltaCamiones(
tipoCamion varchar(3) not null,
cantidadCamion int not null
)
go

create table AltaReservacion(
folio int not null
)

----------------------------------------------------------------------------------

alter table sede 
add constraint PK_sede primary key (id)
go
alter table DistanciaSede
add constraint PK_DistanciaSede primary key (idSedeOrigen, idSedeDestino)
go
alter table DetalleCamion 
add constraint PK_detallecamion primary key(idSede, idCamion)
go
alter table Camion
add constraint PK_camion primary key (id)
go
alter table Trace
add constraint PK_trace primary key (idCamion,movimiento)
go
alter table DetalleReservacion
add constraint PK_detallereservacion primary key (folioReservacion)
go
alter table Chofer
add constraint PK_chofer primary key (idUsuario)
go
alter table Cliente
add constraint PK_cliente primary key (idUsuario)
go
alter table Administrador
add constraint PK_administrador primary key (idUsuario)
go
alter table SedeAdministrador
add constraint PK_SEDEADMIN primary key (idSede, idUsuario)
alter table Reservacion
add constraint PK_reservacion primary key (folio)
go
alter table Pago
add constraint PK_pago primary key (id)
go
alter table Costos
add constraint PK_costos primary key (id)
go
alter table Prospecto
add constraint PK_prospecto primary key (id)
go
alter table AltaUsuarios
add constraint PK_altausuario primary key (tipoUsuario)
go
alter table AltaCamiones
add constraint PK_altacamiones primary key (tipoCamion)
go
alter table AltaReservacion
add constraint PK_altareservacion primary key (Folio)

go
alter table Usuario
add constraint PK_usuario primary key (id)
go
alter table UsuarioToken
add constraint PK_usuariotoken primary key (id)
----------------------------------------------------------------------------------

alter table DistanciaSede
add foreign key (idSedeOrigen) references Sede(id)
go
alter table DistanciaSede
add foreign key (idSedeDestino) references Sede(id)
go
alter table DetalleCamion 
add foreign key (idCamion) references Camion(id)
go
alter table DetalleCamion 
add foreign key (idSede) references Sede(id)
go
alter table Trace 
add foreign key (idCamion) references Camion(id)
go
alter table DetalleReservacion
add foreign key (idCamion) references Camion(id)
go
alter table DetalleReservacion
add foreign key (folioReservacion) references Reservacion(folio)
go
alter table DetalleReservacion
add foreign key (idChofer) references Chofer(idUsuario)
go
alter table Reservacion
add foreign key (idCliente) references Cliente(idUsuario)
go
alter table Pago
add foreign key (folio) references Reservacion(folio)
go
alter table Chofer
add foreign key (idUsuario) references Usuario(id)
go
alter table Cliente
add foreign key (idUsuario) references Usuario(id)
go
alter table Administrador
add foreign key (idUsuario) references Usuario(id)
alter table SedeAdministrador
add foreign key (idSede) references Sede(id)
alter table SedeAdministrador
add foreign key (idUsuario) references Administrador(idUsuario)
go
alter table Sede
add constraint sedes_pertenecefk foreign key (pertenece) references sede(id)
go
alter table UsuarioToken
add foreign key (idUsuario) references Usuario(id)

/*

SPs
**/
--Alta camiones
go
create PROCEDURE SP_ALTACAMIONES
@COD CHAR(3), --COD = tipo de camion
@kilometraje numeric(12,2),
@capacidadPeso numeric(12,2),
@tipoCombustible varchar(10),
@volumen numeric(12,2),
@placas varchar(10)
AS
BEGIN
	BEGIN TRAN
	DECLARE
		@MATRICULA CHAR(7),
		@NUMERO CHAR(4)
		SET @NUMERO = (SELECT cantidadCamion FROM AltaCamiones WITH (UPDLOCK) WHERE tipoCamion = @COD ) +1;
		SET @MATRICULA = (@COD + REPLICATE('0',(4 - LEN(@NUMERO)))+ @NUMERO );
		UPDATE  AltaCamiones SET cantidadCamion = @NUMERO FROM AltaCamiones WHERE tipoCamion = @COD 
		--Insertamos camion en la tabla camiones
		insert into Camion  values (@MATRICULA, @kilometraje, 0, @capacidadPeso, @COD, @tipoCombustible, @volumen, @placas)
		COMMIT TRAN 
END
go
INSERT INTO AltaCamiones VALUES('CHI', 0);
INSERT INTO AltaCamiones VALUES('MED', 0);
INSERT INTO Altacamiones VALUES('GDE', 0);

-- EXEC SP_ALTACAMIONES 'GDE',0, 1500, 'DIESEL',1000, 'VILM8795'  

go
--Folio de reservacion
create PROCEDURE SP_FOLIORESERVACION(
@folioOut numeric(12,2) output
)AS
BEGIN
	BEGIN TRAN
		SET @folioOut = (SELECT folio FROM altareservacion WITH (UPDLOCK)) +1;
		UPDATE  altareservacion  SET folio = @folioOut
		-- Regresamos el folio
		COMMIT TRAN
END
insert into AltaReservacion values (100000000)
go

--- Procedure de crear usuario Empleado (chofer y admin)


create PROCEDURE registraUsuarios--'MARIO','FONSECA','MARTINEZ','112345678','6671538020','JESUS@URIASHOT.COM','ASDASDASDASDASDASAASAS12SA32S1D3AS','AD','LOCAL','MI CASA'
 
 @nombre varchar(50), 
 @primerApellido varchar(50),
 @segundoApellido varchar(50),
 @contrasena varchar(16),
 @telefono varchar(10),
 @correoElectronico varchar(50),
 @tipo varchar(3)
 
AS

BEGIN TRANSACTION;  
  
BEGIN TRY 
DECLARE @id varchar(20)
DECLARE  @cantidad int 
DECLARE @prefijo varchar(10)
   

	  IF @tipo='AD' 
     set @prefijo='ADMIN' 

	  IF @tipo='CH'
     set @prefijo='CHOF' 
	     
	set @cantidad=(select top(1) cantidadUsuarios+1 from AltaUsuarios WHERE tipoUsuario=@prefijo)
	 set @id = ( concat(@prefijo, right('0000'+ CAST(@cantidad as varchar),4)))
	 print @id
	insert into Usuario (id,nombre,primerApellido,segundoApellido,contrasena,telefono,correoElectronico,token) 
	values
	(@id,@nombre,@primerApellido,@segundoApellido,@contrasena,@telefono,@correoElectronico,'')



	
	
	IF @prefijo = 'ADMIN'
	insert into Administrador(idUsuario, tipoAdministrador) values (@id,'NACIONAL')
	update AltaUsuarios Set cantidadUsuarios = @cantidad where tipoUsuario = @prefijo

	IF @prefijo='CHOF'
	insert into Chofer(idUsuario) values (@id)
	update AltaUsuarios Set cantidadUsuarios = @cantidad where tipoUsuario = @prefijo
END TRY  
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  
  
    IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;  
END CATCH;  
  
IF @@TRANCOUNT > 0  
    COMMIT TRANSACTION;
  
 go

 
 insert into AltaUsuarios values ('CLI', 0)
 insert into AltaUsuarios values ('ADMIN', 0)
 insert into AltaUsuarios values ('CHOF', 0)


  -- SP Hacer al prospecto cliente
 go

 
create procedure altaClientes --9
@idProspecto int
as
declare @auxID int
begin transaction;

begin try
	update altaUsuarios set cantidadUsuarios = cantidadUsuarios + 1 where tipoUsuario = 'CLI'
	set @auxID=(select top(1) cantidadUsuarios+1 from AltaUsuarios WHERE tipoUsuario='CLI')
	
	insert into Usuario (id,nombre,primerApellido,segundoApellido,telefono,correoElectronico,token)
	select (concat('CLI', right('0000'+ CAST(@auxID as varchar),4))),nombre,primerApellido,segundoApellido,telefono,correoElectronico,codigoVerificacion from prospecto where id = @idProspecto;

	insert into Cliente (idUsuario,direccion)
	select  (concat('CLI', right('0000'+ CAST(@auxID as varchar),4))), direccion from Prospecto where id = @idProspecto
	
	delete from Prospecto where id = @idProspecto
end try
begin catch

SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  
  
    IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;  
END CATCH;  
  
IF @@TRANCOUNT > 0  
    COMMIT TRANSACTION;
	
	--CASO CLIENTE
	--SELECT * FROM USUARIO
	--SELECT * FROM Cliente
	--SELECT * FROM ALTAUSUARIOS

	--CASO ADMINISTRADOR
	--SELECT * FROM USUARIO
	--SELECT * FROM ADMINISTRADOR
	--SELECT * FROM ALTAUSUARIOS

	--CASO CHOFER

--SP DE ALTA SEDES
GO
CREATE PROCEDURE  SP_ALTASEDES
@alias varchar(5),
@ciudad varchar(50),
@estado varchar(50),
@latitud float,
@longitud float,
@pertenece int
AS
BEGIN
	BEGIN TRANSACTION;  
  
BEGIN TRY 
if (@pertenece =0)
	begin
	insert into Sede (alias,ciudad,estado,latitud,longitud,tipoSede) values(@alias,@ciudad,@estado,@latitud,@longitud,1)
	select @pertenece = @@IDENTITY
	update Sede set pertenece=@pertenece where id=@pertenece
	end
else
	begin
	insert into Sede (alias,ciudad,estado,latitud,longitud,tipoSede,pertenece) values(@alias,@ciudad,@estado,@latitud,@longitud,2,@pertenece)
	end
END TRY  
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  
  
    IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;  
END CATCH;  
  
IF @@TRANCOUNT > 0  
    COMMIT TRANSACTION;
  
END

GO
--Stored procedure para olvido pass (pimera parte
create procedure SP_OlvidoPass
@correoElectronico varchar(100),
@token varchar(256)
as
begin
	begin tran
	declare @idUsuario varchar(20)
	set @idUsuario = (select  top(1) id from Usuario where upper(correoElectronico)=upper(@correoElectronico))
	INSERT INTO USUARIOTOKEN (idUsuario, token) values(@idUsuario, @token)
	commit tran
end


go
--Stored procedure para olvido pass (segunda parte)

create procedure SP_ChangePass
@password varchar(256),
@token varchar(256)
as
begin
	begin tran
		declare @usuarioId varchar(10)
		set @usuarioId= (select top 1 idUsuario from usuariotoken where token=@token)
		update Usuario set contrasena = @password where id=@usuarioId
	commit tran
end



GO


	SELECT * FROM USUARIO
	SELECT * FROM CHOFER
	SELECT * FROM ALTAUSUARIOS



select * from Administrador
select * from Chofer
select * from Cliente
select * from Usuario
update administrador set tipoAdministrador='Global' , idUsuario=2
SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token, c.direccion FROM USUARIO u inner join cliente c on u.id = c.idUsuario where u.correoElectronico='manuelvillegasley@gmail.com' and u.contrasena='12345678'
--Stored procedures
exec [registraUsuarios] 'THEO','PRIETO','RODRIGUEZ','112345678','6671538020','JESUS@URIASHOT.COM','CH'

exec [registraUsuarios] 'Manuel El Admin', 'Villegas', 'Leyva', '12345678', '6674714557','manuelvillegasley@gmail.com','AD'
exec [registraUsuarios] 'Manuel El Chofer', 'Villegas', 'Leyva', '12345678', '6674714557','humbapumbamv@gmail.com','CH'





INSERT INTO prospecto (nombre, primerApellido, segundoApellido, telefono, correoElectronico, direccion, codigoVerificacion) values('Manuel El cliente', 'Villegas', 'Leyva',  '6674714557','manniel_96@hotmail.com','De la tundra #2416 Col prados del sol', '12345')
exec altaClientes 1


EXEC SP_ALTASEDES 'CLN', 'CULIACAN', 'SINALOA',24.801473, -107.403061,0
EXEC SP_ALTASEDES 'NAV', 'NAVOLATO', 'SINALOA',24.763675, -107.695508,0
EXEC SP_ALTASEDES 'GDL', 'GUADALAJARA', 'JALISCO',20.677953, -103.346746 ,0
EXEC SP_ALTASEDES 'MZT', 'MAZATLAN', 'SINALOA', 23.281249, -106.422562 ,0
EXEC SP_ALTASEDES 'ENS', 'ENSENADA', 'BAJA CALIFORNIA', 31.854850, -116.604966 ,0
EXEC SP_ALTASEDES 'XCO', 'XICO', 'VERACRUZ',19.424768, -97.007202 ,0

GO
EXEC SP_ALTACAMIONES 'GDE',0, 1500, 'DIESEL',1800, 'ASDFJ-23'  
EXEC SP_ALTACAMIONES 'GDE',0, 1500, 'DIESEL',8800, 'OEP-S239'  
EXEC SP_ALTACAMIONES 'CHI',0, 1500, 'DIESEL',1000, 'VHM-S239'  
  
EXEC SP_ALTACAMIONES 'MED',0, 1500, 'GASOLINA',1000, 'KJASK-0909'  
EXEC SP_ALTACAMIONES 'MED',0, 1500, 'DIESEL',1000, 'AKSW-8888'  
EXEC SP_ALTACAMIONES 'GDE',0, 1500, 'DIESEL',2000, 'VILM-516A'  
EXEC SP_ALTACAMIONES 'GDE',0, 1500, 'DIESEL',2000, 'VIFE-5892'  
EXEC SP_ALTACAMIONES 'GDE',0, 1500, 'DIESEL',6000, 'VIEX-6971'  
EXEC SP_ALTACAMIONES 'GDE',0, 1500, 'DIESEL',4500, 'KPEN-51WE'  
EXEC SP_ALTACAMIONES 'GDE',0, 1500, 'DIESEL',8000, '699S-D84S'  


select * from camion
select * from sede
select * from DetalleCamion
select * from Trace
exec asignaCamionSede 'MZT', 'GDE0002'

UPDATE  TRACE SET  fecha='2019-11-30', sedeOrigen='CLN', sedeDestino='CLN'WHERE FECHA IS NULL