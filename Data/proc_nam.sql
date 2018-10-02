alter proc USP_GetAllCuaHang
as
begin
	select u.MaCuaHang,u.TenCuaHang,u.DiaChi
	from CuaHang u
end
go

create proc USP_GetAllKhoHang
as
begin
	select k.MaCuaHang,k.MaKieu,k.SoLuong
	from KhoHang k
end 
go
ALTER PROCEDURE GetAllNV
AS
BEGIN
	select *
	from NhanVien
END
GO
go
ALTER PROCEDURE GetNV2
AS
BEGIN
	select n.MaNV, n.MaCuaHang,n.MaLoaiNV,n.TenNV,n.GioiTinh,n.DiaChi,n.SDT,n.Luong
	from NhanVien n
END
GO