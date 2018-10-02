use GalaxyMobile
go
CREATE PROCEDURE GetLNV
AS
BEGIN
	select *
	from LoaiNV
END
GO
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

	