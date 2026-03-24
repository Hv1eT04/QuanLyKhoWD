use quanlykhodb;
select * from hanghoa;
select * from danhmuc;
select * from nguoidung;
select * from phieunhap;
select * from phieuxuat;
select * from chitietphieunhap;
select * from chitietphieuxuat;
select pn.sophieu, h.tenhang, ct.soluong, ct.dongianhap from chitietphieunhap ct join phieunhap pn on pn.maphieunhap = ct.maphieunhap 
join hanghoa h on h.mahang = ct.mahang
SHOW VARIABLES LIKE 'datadir';