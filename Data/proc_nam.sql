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

create proc USP_GETAllInfoSP
@id  varchar(50)
as
begin
	select lsp.MaLSP, dsp.MaDSP,dsp.MaHSX,sp.MaSP,ctsp.MaKieu,ctsp.SoluongSP,ctsp.Gia
	from (( LoaiSP lsp join DongSanPham dsp on lsp.MaLSP = dsp.MaLSP ) join SanPham sp on sp.MaDSP= dsp.MaDSP) join ChiTietSP ctsp on ctsp.MaSP = sp.MaSP
	where ctsp.MaKieu = @id
end
go

create proc USP_GETAllInfoSPNew
@id  varchar(50)
as
begin
	select lsp.TenLSP, dsp.TenDong,sp.TenSP,ctsp.MaKieu,ctsp.SoluongSP,ctsp.Gia,hsx.TenHSX
	from ((( LoaiSP lsp join DongSanPham dsp on lsp.MaLSP = dsp.MaLSP ) join SanPham sp on sp.MaDSP= dsp.MaDSP) join ChiTietSP ctsp on ctsp.MaSP = sp.MaSP)join HSX hsx on hsx.MaHSX = dsp.MaHSX
	where ctsp.MaKieu = @id
end
go

create proc USP_DeleteCTSP
@id  varchar(50)
as
begin
	Delete ChiTietSP  where MaKieu = @id
end
go
exec USP_GETAllInfoSPNew @id='ipX256Gray'
go
alter proc USP_GetCTSPOderByMaCHByMaSP
@idch  varchar(10) , 
@id  varchar(30)
as
begin
select ct.MaSP,ct.MaKieu,ct.MaMau,ct.Gia,k.SoLuong as [SoluongSP],ct.Anh
	from ChiTietSP ct join KhoHang k on k.MaKieu=ct.MaKieu
	where k.MaCuaHang = @idch and ct.MaSP=@id
end
go
alter proc USP_GetCTSPOderByMaCHByMaKieu
@idch  varchar(10) , 
@id  varchar(50)
as
begin
select ct.MaSP,ct.MaKieu,ct.MaMau,ct.Gia,k.SoLuong as [SoluongSP],ct.Anh
	from ChiTietSP ct join KhoHang k on k.MaKieu=ct.MaKieu
	where k.MaCuaHang = @idch and ct.MaKieu=@id
end
go
exec USP_GetCTSPOderByMaCHByMaKieu @idch='cs1' ,@id ='ipX256Gray'
create proc USP_ThayDoiGiaChiTietSP
@id varchar(50), @Gia decimal 
as
begin
	update ChiTietSP set Gia= @Gia where MaKieu=@id
end
go


create proc USP_ThayDoiSoLuongChiTietSP
@id varchar(50), @sl int 
as
begin
	update ChiTietSP set SoluongSP= SoluongSP+@sl where MaKieu=@id
end
go


create proc USP_GetHDTheoThang
@date int
as
begin
	select *
	from HoaDon 
	where  MONTH( NgayLapHD) = @date
end
go

exec USP_GetHDTheoThang @date=9

go


create proc USP_PhanChiaSP
@id varchar(50), @idNhap varchar(10) ,@idPP varchar(10),@SL int
as
begin
	Update KhoHang set SoLuong+=@SL where @id=MaKieu and @idNhap=MaCuaHang
	Update KhoHang set SoLuong-=@SL where @id=MaKieu and @idPP=MaCuaHang
end
go

create proc USP_ThemSL_KhoHangByMaKieuByMaCH
@id varchar(50),  @idCH varchar(10), @SL int
as
begin
	Update KhoHang set SoLuong+=@SL where @id=MaKieu and @idCH=MaCuaHang
end
go

create proc USP_ThayDoiSLChiTietHoaDon
 @idhd varchar(15),@idch varchar(10) , @id varchar(50), @SL int 
as
begin
	update ChiTietHoaDon set SoluongSP+= @SL where MaKieu=@id and MaCuaHang=@idch and MaHoaDon=@idhd
end
go


--create proc USP_ThanhToanHoaDon
-- @idhd varchar(15),@idch varchar(10)
-- as
-- begin
-- end
-- go

alter proc InHoaDon
@idhd varchar(15), @idch varchar(10)
as
begin
	select ct.MaKieu as [Mã Sản Phẩm],sp.TenSP as [Tên Sản Phẩm],mau.Mau as [Màu Sắc],ct.GiaSP as [Giá], ct.SoluongSP[Số Lượng Mua],ct.SoluongSP*ct.GiaSP as [Tổng Tiền]
	from ((ChiTietHoaDon ct join ChiTietSP ctsp on ct.MaKieu=ctsp.MaKieu ) join SanPham sp on sp.MaSP= ctsp.MaSP )join MauSP mau on mau.MaMau = ctsp.MaMau
	 where ct.MaHoaDon=@idhd and ct.MaCuaHang=@idch
end
go

exec InHoaDon @idhd='hd0002' , @idch= 'cs2'