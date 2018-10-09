use GalaxyMobile
go

ALTER PROCEDURE delNV
	@manv varchar(10)
AS
BEGIN
DELETE FROM NhanVien
WHERE MaNV = @manv
END
GO
ALTER PROCEDURE spThemNV
	@manv varchar(10),
	@macuahang varchar(10),
	@maloainv varchar(15),
	@tennv nvarchar(50),
	@gioitinh nvarchar(5),
	@diachi nvarchar(100),
	@sdt varchar(13),
	@luong decimal(18,0)
AS
BEGIN
INSERT INTO NhanVien(MaNV,MaCuaHang,MaLoaiNV,TenNV,GioiTinh,DiaChi,SDT,Luong)
VALUES (@manv,@macuahang,@maloainv,@tennv,@gioitinh,@diachi,@sdt,@luong)
END


go
ALTER PROCEDURE updateNV
	@manv varchar(10),
	@macuahang varchar(10),
	@maloainv varchar(15),
	@tennv nvarchar(50),
	@gioitinh nvarchar(5),
	@diachi nvarchar(100),
	@sdt varchar(13),
	@luong decimal(18,0)
AS
BEGIN
UPDATE NhanVien
SET MaCuaHang=@macuahang,MaLoaiNV=@maloainv,TenNV=@tennv,GioiTinh=@gioitinh,DiaChi=@diachi,SDT=@sdt,Luong=@luong
WHERE MaNV=@manv
END
go
----------Loai NV------------
alter procedure spUpdateLNV
	@maloai varchar(15),
	@tenloai nvarchar(20)
as
begin 
update LoaiNV
set TenLoaiNV=@tenloai
where MaLoaiNV=@maloai
end
go
alter procedure spDelLNV
	@maloai varchar(15)
as
begin 
delete from LoaiNV
where MaLoaiNV=@maloai
end
go
create procedure spInsertLNV
	@maloai varchar(15),
	@tenloai nvarchar(20)
as
begin
insert into LoaiNV(MaLoaiNV,TenLoaiNV)
values ( @maloai,@tenloai)
end
go
ALTER PROCEDURE GetLNV
AS
BEGIN
	select *
	from LoaiNV
END
GO
------------Khach Hang-----------------
alter procedure spInsertKH
	@ma varchar(10),
	@ten nvarchar(50),
	@diachi nvarchar(100),
	@sdt varchar(13)
as
begin
insert into KhachHang(MaKH,TenKH,DiaChi,SDT)
values (@ma,@ten,@diachi,@sdt)
end
go
alter procedure spUpdateKH
	@ma varchar(10),
	@ten nvarchar(50),
	@diachi nvarchar(100),
	@sdt varchar(13)
as
begin 
update KhachHang
set TenKH=@ten,DiaChi=@diachi,SDT=@sdt
where MaKH=@ma
end
go
alter procedure spDelKH
	@ma varchar(10)
as
begin 
delete from KhachHang
where MaKH=@ma 
end
go
alter procedure spGetKH
as
begin 
	select *
	from KhachHang
end
go
