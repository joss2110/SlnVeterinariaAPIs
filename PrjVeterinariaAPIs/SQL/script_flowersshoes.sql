USE master
GO

DROP DATABASE IF EXISTS flowersshoes
GO

CREATE DATABASE flowersshoes
GO

USE flowersshoes
GO

CREATE TABLE tb_roles
(
idrol INT PRIMARY KEY identity(1,1),
nomRol VARCHAR(50)
);
GO

CREATE TABLE tb_trabajadores
(
idtra INT PRIMARY KEY identity(1,1),
nombres VARCHAR(100) NOT NULL,
tipoDocumento VARCHAR(50) NOT NULL,
nroDocumento VARCHAR(15) NOT NULL,
direccion VARCHAR(100) NOT NULL,
email VARCHAR(100) NOT NULL,
pass VARCHAR(100) NOT NULL,
idrol INT NOT NULL FOREIGN KEY REFERENCES tb_roles(idrol),
estado VARCHAR(20) NOT NULL
);
GO

CREATE TABLE tb_colores
(
idcolor INT PRIMARY KEY identity(1,1),
color VARCHAR(100) NOT NULL,
estado VARCHAR(20) NOT NULL
);
GO



CREATE TABLE tb_productos
(
idpro INT PRIMARY KEY identity(1,1),
codbar Varchar(100),
imagen VARCHAR(150),
nompro VARCHAR(100) NOT NULL,
precio DECIMAL(7,2) NOT NULL,
talla INT NOT NULL,
idcolor INT NOT NULL FOREIGN KEY REFERENCES tb_colores(idcolor),
categoria VARCHAR(100),
temporada VARCHAR(100),
descripcion VARCHAR(100),
estado VARCHAR(20) NOT NULL,
);
GO

CREATE TABLE tb_stocks
(
idstock INT PRIMARY KEY identity(1,1),
idpro INT NOT NULL FOREIGN KEY REFERENCES tb_productos(idpro),
cantidad INT NOT NULL
);
GO

CREATE TABLE tb_ingresos
(
idingre INT PRIMARY KEY identity(1,1),
fecha DATETIME NOT NULL,
descripcion VARCHAR(100),
idtra INT NOT NULL FOREIGN KEY REFERENCES tb_trabajadores(idtra),
estado VARCHAR(20) NOT NULL
);
GO

CREATE TABLE tb_detalle_ingresos
(
idingre INT NOT NULL FOREIGN KEY REFERENCES tb_ingresos(idingre),
idpro INT NOT NULL FOREIGN KEY REFERENCES tb_productos(idPro),
cantidad INT NOT NULL
);
GO

CREATE TABLE tb_clientes
(
idcli INT PRIMARY KEY identity(1,1),
nomcli VARCHAR(50) NOT NULL,
apellidos VARCHAR(50),
tipodocumento VARCHAR(50),
nrodocumento VARCHAR(15),
telefono VARCHAR(15),
direccion VARCHAR(100),
estado VARCHAR(20) NOT NULL
);
GO

CREATE TABLE tb_ventas
(
idventa INT PRIMARY KEY identity(1,1),
idtra INT NOT NULL FOREIGN KEY REFERENCES tb_trabajadores(idtra),
idcli INT NOT NULL FOREIGN KEY REFERENCES tb_clientes(idcli),
fecha DATETIME NOT NULL,
total DECIMAL NOT NULL,
estado VARCHAR(20) NOT NULL,
estadoComprobante VARCHAR(20) NOT NULL
);
GO

CREATE TABLE tb_detalle_ventas
(
idventa INT NOT NULL FOREIGN KEY REFERENCES tb_ventas(idventa),
idpro INT NOT NULL FOREIGN KEY REFERENCES tb_productos(idpro),
cantidad INT NOT NULL,
preciouni DECIMAL NOT NULL,
subtotal DECIMAL NOT NULL
);
GO




-- PROCEDIMIENTOS ALMACENADOS
 

--TB_PRODUCTO

--PA_GRABAR_PRODUCTOS

create or alter procedure PA_GRABAR_PRODUCTO
@nompro VARCHAR(100),
@precio DECIMAL(7,2),
@idcolor INT ,
@categoria VARCHAR(100),
@temporada VARCHAR(100),
@descripcion VARCHAR(100),
@message VARCHAR(100) OUTPUT
 AS
 BEGIN
	DECLARE @idpro INT;
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM tb_productos WHERE codbar = CONCAT(@nompro,35,@idcolor) OR codbar = CONCAT(@nompro,36,@idcolor) OR codbar = CONCAT(@nompro,37,@idcolor) OR codbar = CONCAT(@nompro,38,@idcolor) OR codbar = CONCAT(@nompro,39,@idcolor) OR codbar = CONCAT(@nompro,40,@idcolor))
		BEGIN
			INSERT INTO tb_productos (codbar,imagen, nompro, precio, talla, idcolor, categoria, temporada, descripcion, estado)
			VALUES (CONCAT(@nompro,35,@idcolor),LOWER(CONCAT(@nompro,@idcolor,'.jpg')), @nompro, @precio, 35, @idcolor, @categoria, @temporada, @descripcion, 'Activo');
			SELECT @idpro = scope_identity();
			INSERT INTO tb_stocks (idpro, cantidad)  values (@idpro,0)
			INSERT INTO tb_productos (codbar,imagen, nompro, precio, talla, idcolor, categoria, temporada, descripcion, estado)
			VALUES (CONCAT(@nompro,36,@idcolor),LOWER(CONCAT(@nompro,@idcolor,'.jpg')), @nompro, @precio, 36, @idcolor, @categoria, @temporada, @descripcion, 'Activo');
			SELECT @idpro = scope_identity();
			INSERT INTO tb_stocks (idpro, cantidad)  values (@idpro,0)
			INSERT INTO tb_productos (codbar,imagen, nompro, precio, talla, idcolor, categoria, temporada, descripcion, estado)
			VALUES (CONCAT(@nompro,37,@idcolor),LOWER(CONCAT(@nompro,@idcolor,'.jpg')), @nompro, @precio, 37, @idcolor, @categoria, @temporada, @descripcion, 'Activo');
			SELECT @idpro = scope_identity();
			INSERT INTO tb_stocks (idpro, cantidad)  values (@idpro,0)
			INSERT INTO tb_productos (codbar,imagen, nompro, precio, talla, idcolor, categoria, temporada, descripcion, estado)
			VALUES (CONCAT(@nompro,38,@idcolor),LOWER(CONCAT(@nompro,@idcolor,'.jpg')), @nompro, @precio, 38, @idcolor, @categoria, @temporada, @descripcion, 'Activo');
			SELECT @idpro = scope_identity();
			INSERT INTO tb_stocks (idpro, cantidad)  values (@idpro,0)
			INSERT INTO tb_productos (codbar,imagen, nompro, precio, talla, idcolor, categoria, temporada, descripcion, estado)
			VALUES (CONCAT(@nompro,39,@idcolor),LOWER(CONCAT(@nompro,@idcolor,'.jpg')), @nompro, @precio, 39, @idcolor, @categoria, @temporada, @descripcion, 'Activo');
			SELECT @idpro = scope_identity();
			INSERT INTO tb_stocks (idpro, cantidad)  values (@idpro,0)
			INSERT INTO tb_productos (codbar,imagen, nompro, precio, talla, idcolor, categoria, temporada, descripcion, estado)
			VALUES (CONCAT(@nompro,40,@idcolor),LOWER(CONCAT(@nompro,@idcolor,'.jpg')), @nompro, @precio, 40, @idcolor, @categoria, @temporada, @descripcion, 'Activo');
			SELECT @idpro = scope_identity();
			INSERT INTO tb_stocks (idpro, cantidad)  values (@idpro,0)
			SET @message  = 'Producto agregado correctamente.';
		END
    ELSE
		BEGIN
			SET @message=  'Error: El producto ya existe.';
		END
 END
GO

CREATE OR ALTER PROCEDURE PA_MODIFICAR_PRODUCTO
    @idpro INT,
    @nompro VARCHAR(100),
    @precio DECIMAL(7,2),
	@talla INT,
    @idcolor INT,
    @categoria VARCHAR(100),
    @temporada VARCHAR(100),
    @descripcion VARCHAR(100),
	@message VARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si la combinación de talla, idcolor y nompro ya existe para otro producto
    IF EXISTS (
        SELECT 1 
        FROM tb_productos 
        WHERE talla = @talla 
        AND idcolor = @idcolor 
        AND nompro = @nompro 
        AND idpro <> @idpro
    )
    BEGIN
        SET @message= 'Error: La combinación de talla, color y nombre ya está asociada a otro producto.';
        RETURN;
    END 
    ELSE
    BEGIN
        -- Actualizar los datos del producto
        UPDATE tb_productos
        SET 
			codbar = ISNULL(CONCAT(@nompro,@talla,@idcolor), codbar),
            imagen = ISNULL(LOWER(CONCAT(@nompro,@idcolor,'.jpg')), imagen),
            nompro = ISNULL(@nompro, nompro),
            precio = ISNULL(@precio, precio),
            talla = ISNULL(@talla, talla),
            idcolor = ISNULL(@idcolor, idcolor),
            categoria = ISNULL(@categoria, categoria),
            temporada = ISNULL(@temporada, temporada),
            descripcion = ISNULL(@descripcion, descripcion)
        WHERE idpro = @idpro;

        SET @message= 'Producto' + ' ' + @nompro + ' actualizado correctamente.';
    END
END
GO





--PA_LISTAR_PRODUCTOS

CREATE OR ALTER  PROCEDURE PA_LISTAR_PRODUCTOS
AS
BEGIN
    SELECT 
        p.idpro ,
        p.codbar,
		p.imagen,
        p.nompro,
		p.precio,
		p.talla,
		c.color,
		p.categoria,
		p.temporada,
		p.descripcion,
		p.estado
    FROM 
        tb_productos p
	INNER JOIN 
        tb_colores c ON c.idcolor = p.idcolor;
END
GO


--PA_ELIMINAR_PRODUCTOS

CREATE OR ALTER PROCEDURE PA_ELIMINAR_PRODUCTOS
@idpro INT
AS
    UPDATE tb_productos
        SET estado='Inactivo'
    WHERE idpro = @idpro
GO

--  PA_RESTAURAR_PRODUCTOS
 CREATE OR ALTER PROCEDURE PA_RESTAURAR_PRODUCTOS
 @idpro INT
 AS
    UPDATE tb_productos 
    SET estado = 'Activo'
    WHERE idpro = @idpro
 GO


--TB_STOCKS

--PA_LISTAR_STOCKS

CREATE OR ALTER  PROCEDURE PA_LISTAR_STOCKS
AS
BEGIN
    SELECT 
        s.idstock,
		p.codbar,
		p.nompro,
        p.imagen,
		c.color,
		p.talla,
		p.precio,
        s.cantidad
    FROM 
        tb_stocks s
    INNER JOIN 
        tb_productos p ON s.idpro = p.idpro
	INNER JOIN 
        tb_colores c ON c.idcolor = p.idcolor
END
GO



--tb_cliente


--PA_GRABAR_CLIENTE

create or alter procedure PA_GRABAR_CLIENTE
 @nomcli VARCHAR(40),
 @apellidos VARCHAR(40),
 @tipodocumento VARCHAR(40),
 @nrodocumento VARCHAR(10),
 @telefono VARCHAR(10) = NULL,
 @direccion VARCHAR(40) = NULL,
 @message VARCHAR(100) OUTPUT
 AS
 BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM tb_clientes WHERE nrodocumento = @nrodocumento)
        BEGIN
            INSERT INTO tb_clientes (nomcli, apellidos, tipodocumento , nrodocumento, telefono, direccion,estado)
            VALUES (@nomcli, @apellidos, @tipodocumento, @nrodocumento, @telefono, @direccion, 'Activo');
            SET @message ='Cliente agregado correctamente.';
        END
    ELSE
        BEGIN
            SET @message ='Error: El número de documento ya existe.';
        END
 END
GO



--PA_MODIFICAR_CLIENTE

create or alter procedure PA_MODIFICAR_CLIENTE
    @idcli INT,
    @nomcli VARCHAR(40),
    @apellidos VARCHAR(40),
    @tipodocumento VARCHAR(40),
    @telefono VARCHAR(10) = NULL,
    @direccion VARCHAR(40) = NULL,
    @nrodocumento VARCHAR(10),
    @message VARCHAR(100) OUTPUT
  AS
 BEGIN
    SET NOCOUNT ON;

    -- Verificar si el número de documento ya está asociado a otro cliente
    IF EXISTS (SELECT 1 FROM tb_clientes WHERE nrodocumento = @nrodocumento AND idcli <> @idcli)
    BEGIN
        SET @message ='Error: El número de documento ya está asociado a otro cliente.';
        RETURN;
    END 
    ELSE
    BEGIN
        -- Si no se modificaron todos los datos, actualizar solo los datos modificados
        UPDATE tb_clientes
        SET nomcli = ISNULL(@nomcli, nomcli),
            apellidos = ISNULL(@apellidos, apellidos),
            tipodocumento = ISNULL(@tipodocumento, tipodocumento),
            telefono = @telefono,
            direccion = @direccion,
            nrodocumento = ISNULL(@nrodocumento, nrodocumento)
        WHERE idcli = @idcli
        SET @message = 'Cliente '  + @nomcli +' actualizado correctamente.';
    END
END
GO


--PA_LISTAR_CLIENTES

create or alter procedure PA_LISTAR_CLIENTES
AS
	SELECT * FROM tb_clientes
go

--PA_ELIMINAR_CLIENTES

CREATE OR ALTER PROCEDURE PA_ELIMINAR_CLIENTES
@idcli INT
AS
BEGIN
    UPDATE tb_clientes SET estado='Inactivo' WHERE idcli = @idcli;
END
GO

--PA_RESTAURAR_CLIENTES

CREATE OR ALTER PROCEDURE PA_RESTAURAR_CLIENTES
@idcli INT
AS
BEGIN
    UPDATE tb_clientes SET estado='Activo' WHERE idcli = @idcli;
END
GO










--TB_COLORES

--PA_GRABAR_COLOR


CREATE OR ALTER PROCEDURE PA_GRABAR_COLOR
    @color VARCHAR(100),
    @message VARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM tb_colores WHERE color = @color)
    BEGIN
        INSERT INTO tb_colores (color, estado)
        VALUES (@color, 'Activo');
        SET @message = 'Color agregado correctamente.';
    END
    ELSE
    BEGIN
        SET @message = 'Error: El color ya existe en la tabla.';
    END
END
GO



--PA_ACTUALIZAR_COLOR

CREATE or alter PROCEDURE PA_MODIFICAR_COLOR
    @idcolor INT,
    @color VARCHAR(100),
	@message VARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el color ya está asociado a otro registro
    IF EXISTS (SELECT 1 FROM tb_colores WHERE color = @color AND idcolor <> @idcolor)
		BEGIN
		SET @message = 'Error: El color ya está asociado a otro registro.';
        RETURN;
    END
    ELSE
    BEGIN
        -- Si no se modificaron todos los datos, actualizar solo los datos modificados
        UPDATE tb_colores
        SET color = ISNULL(@color, color)
        WHERE idcolor = @idcolor;
        SET @message = 'Color actualizado correctamente.';
    END
END
GO

--PA_LISTAR_COLORES

create or alter procedure PA_LISTAR_COLORES
as
SELECT * FROM tb_colores
go

--PA_ELIMINAR_COLOR

CREATE or alter PROCEDURE PA_ELIMINAR_COLOR
    @idcolor INT
AS
BEGIN
    UPDATE tb_colores
    SET estado = 'Inactivo'
    WHERE idcolor = @idcolor;
END
GO

--PA_RESTAURAR_COLOR

CREATE or alter PROCEDURE PA_RESTAURAR_COLOR
    @idcolor INT
AS
BEGIN
    UPDATE tb_colores
    SET estado = 'Activo'
    WHERE idcolor = @idcolor;
END
GO







--TB_VENTAS Y TB_DETALLLE_VENTAS



--PA_GRABAR_VENTA

CREATE OR ALTER PROCEDURE PA_GRABAR_VENTA
	@idtra INT,
	@idcli INT,
	@id INT  OUTPUT
AS
BEGIN
    INSERT INTO tb_ventas(idtra,idcli,fecha,total,estadocomprobante,estado) VALUES(@idtra, @idcli,GETDATE(),0,'Pendiente','Activo');
     SET @id =  scope_identity(); 
END
GO


--PA_GRABAR_DETALLE_VENTA

CREATE OR ALTER PROCEDURE PA_GRABAR_DETALLE_VENTA
    @idventa INT,
	@idpro INT,
	@cantidad INT,
	@precioUni DECIMAL,
	@subtotal DECIMAL
AS
BEGIN
    -- Inserta el detalle del ingreso
    INSERT INTO tb_detalle_ventas(idventa, idpro, cantidad,preciouni,subtotal)
    VALUES (@idventa, @idpro, @cantidad,@precioUni,@subtotal);

    -- Actualiza el stock
    UPDATE tb_stocks
    SET cantidad = cantidad - @cantidad
    WHERE idpro = @idpro;

	-- Actualiza el total de ventas
	UPDATE tb_ventas
	SET total = total + @subtotal
	WHERE idventa = @idventa;
	
END
GO

--PA_ELIMINAR_VENTA

CREATE OR ALTER PROCEDURE PA_ELIMINAR_VENTA
@idventa INT
AS
BEGIN
    UPDATE tb_ventas SET estado='Inactivo' WHERE idventa = @idventa;
END
GO

--PA_ELIMINAR_DETALLE_VENTA

CREATE OR ALTER PROCEDURE PA_ELIMINAR_DETALLE_VENTA
@idpro INT,
@cantidad INT
AS
BEGIN
     UPDATE tb_stocks SET cantidad=cantidad+@cantidad WHERE idPro = @idpro;
END
GO





--PA_RESTAURAR_VENTA

CREATE OR ALTER PROCEDURE PA_RESTAURAR_VENTA
@idventa INT
AS
BEGIN
    UPDATE tb_ventas SET estado='Activo' WHERE idventa = @idventa;
END
GO

--PA_EDITAR_VENTA

CREATE OR ALTER PROCEDURE PA_EDITAR_VENTA
@idventa INT,
@estadoComprobante VARCHAR(100)
AS
BEGIN
    UPDATE tb_ventas 
	SET
	estadoComprobante = @estadoComprobante,
	estado='Activo' 
	WHERE idventa = @idventa;
END
GO

--PA_RESTAURAR_DETALLE_VENTA

CREATE OR ALTER PROCEDURE PA_RESTAURAR_DETALLE_VENTA
@idpro INT,
@cantidad INT
AS
BEGIN
     UPDATE tb_stocks SET cantidad=cantidad-@cantidad WHERE idPro = @idpro;
END
GO



--PA_LISTAR_VENTAS

CREATE OR ALTER PROCEDURE PA_LISTAR_VENTAS
AS
BEGIN
    SELECT V.idventa, T.nombres as trabajador,(C.nomcli+' '+C.apellidos) as cliente,V.fecha,V.total,V.estadocomprobante,V.estado
    FROM tb_ventas V
    INNER JOIN tb_trabajadores T ON V.idtra = T.idtra
	INNER JOIN tb_clientes C ON V.idcli = C.idcli;
END
GO

--PA_LISTAR_DETALLE_VENTAS

CREATE OR ALTER PROCEDURE PA_LISTAR_DETALLE_VENTAS
@idventa INT
AS
BEGIN
    SELECT DV.idventa,P.imagen, P.nompro, C.color, P.Talla, DV. cantidad, DV.preciouni, DV.subtotal
    FROM tb_detalle_ventas DV 
	INNER JOIN tb_productos P ON DV.idpro = P.idpro 
	INNER JOIN tb_colores C ON P.idcolor = C.idcolor
	WHERE DV.idventa = @idventa
END
GO












--TB_INGRESOS Y TB_DETALLLE_INGRESOS



--PA_GRABAR_INGRESOS

CREATE OR ALTER PROCEDURE PA_GRABAR_INGRESOS
    @idtra INT,
    @descripcion VARCHAR(100) = NULL,
    @id INT OUTPUT 
AS
BEGIN
    INSERT INTO tb_ingresos (fecha,descripcion, idtra,  estado)
    VALUES (GETDATE(), @descripcion,@idtra,  'Activo');
    SET @id = SCOPE_IDENTITY();
END
GO


--PA_GRABAR_DETALLE_INGRESOS

CREATE OR ALTER PROCEDURE PA_GRABAR_DETALLE_INGRESOS
    @idingre INT,
	@idpro INT,
	@cantidad INT
AS
BEGIN
    -- Inserta el detalle del ingreso
    INSERT INTO tb_detalle_ingresos (idingre, idpro, cantidad)
    VALUES (@idingre, @idpro, @cantidad);

    -- Actualiza el stock
    UPDATE tb_stocks
    SET cantidad = cantidad + @cantidad
    WHERE idPro = @idpro;
END
GO

CREATE OR ALTER PROCEDURE PA_EDITAR_INGRESOS
@idingre INT,
@descripcion VARCHAR(100)
AS
BEGIN
    UPDATE tb_ingresos
	SET
	descripcion = @descripcion,
	estado='Activo' 
	WHERE idingre = @idingre;
END
GO
--PA_ELIMINAR_INGRESOS

CREATE OR ALTER PROCEDURE PA_ELIMINAR_INGRESOS
@idingre INT
AS
BEGIN
    UPDATE tb_ingresos SET estado='Inactivo' WHERE idingre = @idingre;
END
GO

--PA_ELIMINAR_DETALLE_INGRESO

CREATE OR ALTER PROCEDURE PA_ELIMINAR_DETALLE_INGRESO
@idpro INT,
@cantidad INT
AS
BEGIN
     UPDATE tb_stocks SET cantidad=cantidad-@cantidad WHERE idPro = @idpro;
END
GO

--PA_RESTAURAR_INGRESOS

CREATE OR ALTER PROCEDURE PA_RESTAURAR_INGRESOS
@idingre INT
AS
BEGIN
    UPDATE tb_ingresos SET estado='Activo' WHERE idingre = @idingre;
END
GO



--PA_RESTAURAR_DETALLE_INGRESO

CREATE OR ALTER PROCEDURE PA_RESTAURAR_DETALLE_INGRESO
@idpro INT,
@cantidad INT
AS
BEGIN
     UPDATE tb_stocks SET cantidad=cantidad+@cantidad WHERE idPro = @idpro;
END
GO




--PA_LISTAR_INGRESOS

CREATE OR ALTER PROCEDURE PA_LISTAR_INGRESOS
AS
BEGIN
    SELECT I.idingre , I.fecha,T.nombres, I.descripcion, I.estado
    FROM tb_ingresos I 
    INNER JOIN tb_trabajadores T ON I.idtra = T.idtra
END
GO



--PA_LISTAR_DETALLE_INGRESOS

CREATE OR ALTER PROCEDURE PA_LISTAR_DETALLE_INGRESOS
@idingre INT 
AS
BEGIN
    SELECT DI.idingre, P.imagen, P.nompro, C.color, P.Talla, DI.cantidad
    FROM tb_detalle_ingresos DI
	INNER JOIN tb_productos P ON DI.idpro = P.idpro 
	INNER JOIN tb_colores C ON P.idcolor = C.idcolor
	WHERE DI.idingre = @idingre
END
GO



--tb_roles

 -- INSERTAR_ROLES
 insert into tb_roles(nomRol) values
 ('Administrador'),
 ('Vendedor'),
 ('Operador Logistico')
 go

  -- LISTAR ROLES
 create or alter procedure pa_listar_roles
 as
	select * from tb_roles
 go












--TB_TRABAJADORES

 -- pa_listar_trabajadores

create or alter procedure pa_listar_trabajadores
 as
    select t.idtra, t.nombres, t.tipoDocumento, t.nroDocumento, t.direccion, t.email,t.pass, r.nomRol, t.estado
        from tb_trabajadores t inner join tb_roles r
        on t.idrol = r.idrol
 go



-- AGREGAR TRABAJADORES
 create or alter procedure PA_AGREGAR_TRABAJADORES
 @nombres varchar(100), 
 @tipoDocumento varchar(50), 
 @nroDocumento varchar(15), 
 @direccion varchar(100), 
 @email varchar(100),
 @pass varchar(100), 
 @idrol int, 
 @message varchar(100) OUTPUT
 as
 begin
    set nocount on
    if not exists (select 1 from tb_trabajadores where nroDocumento = @nroDocumento)
        begin
            insert into tb_trabajadores(nombres, tipoDocumento, nroDocumento, direccion, email, pass, idrol, estado)
            values(@nombres, @tipoDocumento, @nroDocumento, @direccion, @email, @pass, @idrol, 'Activo')
            set @message = 'Trabajador(a) agregado(a) correctamente'
        end
    else
        begin
            set @message = 'Error: el numero de documento ya existe'
        end
 end
 go

 --insertar trabajadores
insert into tb_trabajadores(nombres, tipoDocumento, nroDocumento, direccion, email, pass, idrol, estado)
	values('Gisela Torres Perez', 'DNI', '76878452', 'calle sol nro 255', 'admin@gmail.com', 'admin123', 1 , 'Activo')
go

select * from tb_trabajadores
go


 -- ACTUALIZAR TRABAJADORES
 CREATE OR ALTER PROCEDURE PA_MODIFICAR_TRABAJADORES
    @idtra INT,
    @nombres VARCHAR(100),
    @tipoDocumento VARCHAR(50),
    @nroDocumento VARCHAR(15),
    @direccion VARCHAR(100),
    @email VARCHAR(100),
    @pass VARCHAR(100),
    @idrol INT,
    @message varchar(100) output
AS
BEGIN
    SET NOCOUNT ON

    -- Verificar si el número de documento ya está asociado a otro trabajador
    IF EXISTS (SELECT 1 FROM tb_trabajadores WHERE nroDocumento = @nroDocumento AND idtra <> @idtra)
    BEGIN
        set @message = 'Error: El número de documento ya está asociado a otro trabajador.'
        RETURN
    END 
    ELSE IF EXISTS (SELECT 1 FROM tb_trabajadores WHERE email = @email AND idtra <> @idtra)
    BEGIN
        set @message = 'Error: El email ya está asociado a otro trabajador.'
        RETURN
    END
    ELSE
    BEGIN
        -- Si no se modificaron todos los datos, actualizar solo los datos modificados
        UPDATE tb_trabajadores
        SET nombres = ISNULL(@nombres, nombres),
            tipoDocumento = ISNULL(@tipoDocumento, tipoDocumento),
            nroDocumento = ISNULL(@nroDocumento, nroDocumento),
            direccion = ISNULL(@direccion, direccion),
            email = ISNULL(@email, email),
            pass = ISNULL(@pass, pass),
            idrol = ISNULL(@idrol, idrol),
			estado = 'Activo'
        WHERE idtra = @idtra

        set @message = 'Trabajador actualizado correctamente.'
    END
END
GO


 -- ELIMINAR TRABAJADORES
  create or alter procedure PA_ELIMINAR_TRABAJADORES
 @idtra int
 as
    update tb_trabajadores set estado = 'Inactivo'
    where idtra = @idtra
 go
 
 -- RESTAURAR TRABAJADORES
 create or alter procedure PA_RESTAURAR_TRABAJADORES
 @idtra int
 as
    update tb_trabajadores set estado = 'Activo'
    where idtra = @idtra
 go


 -- PA GET CATALOGO APP

 create or alter procedure PA_OBTENER_CATALOGO_APP
 as
	SELECT 
    p.nompro,
    LEFT(p.imagen, LEN(p.imagen) - 4) AS imagen,
    c.color,
    STRING_AGG(p.talla, ', ') AS tallas,
	p.precio,
	p.categoria
	FROM 
		tb_stocks s
	INNER JOIN 
		tb_productos p ON s.idpro = p.idpro
	INNER JOIN 
		tb_colores c ON c.idcolor = p.idcolor
	WHERE 
		s.cantidad > 0
	GROUP BY 
		p.nompro, p.imagen, c.color,p.precio,p.categoria
	ORDER BY 
		p.nompro;

 go
