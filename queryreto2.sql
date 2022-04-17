create database Reto2_GinaGonzalez 
go 
use Reto2_GinaGonzalez
go

create table libros(
   codigo varchar(4) ,
   titulo varchar(40),
   autor varchar(30),
   editorial varchar(20),
   precio decimal(5,2),
   cantidad smallint,
  )  
go


create proc sp_listar_libros
as 
select * from libros order by codigo

go

create proc sp_buscar_libros
@titulo varchar(40)
as select codigo,titulo,autor,editorial,precio,cantidad from libros where titulo like @titulo + '% '
go

create proc sp_insertar_libros
@codigo varchar(4) ,
@titulo varchar(40),
@autor varchar(30),
@editorial varchar(20),
@precio decimal(5,2),
@cantidad smallint,
@accion varchar(50)  output
as
if(@accion='1')
begin
	declare @newcode varchar(4),@codmax varchar(4)
	set @codmax= (select max(codigo) from libros)
	set @codmax= isnull(@codmax,'A000')
	set @newcode= 'A'+RIGHT(RIGHT(@codmax,3)+1001,3)
	insert into libros(codigo,titulo,autor,editorial,precio,cantidad)
	values(@newcode,@titulo,@autor,@editorial,@precio,@cantidad)
	set @accion='se generó un nuevo libro con el codigo: '+@newcode
end
else if (@accion='2')
begin
	update libros set titulo=@titulo,autor=@autor, editorial=@editorial,precio=@precio, cantidad=@cantidad where codigo=@codigo
	set @accion='se editaron los datos del codigo: '+@codigo
end
else if(@accion='3')
begin
	delete from libros where codigo=@codigo
	set @accion='se borraron los datos del codigo: '+@codigo
end
go



