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