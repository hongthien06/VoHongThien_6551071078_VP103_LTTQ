SET QUOTED_IDENTIFIER ON;
GO
USE master;
GO
IF DB_ID(N'DuLieu') IS NOT NULL
BEGIN
    ALTER DATABASE DuLieu SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DuLieu;
END
GO
CREATE DATABASE DuLieu;
GO
USE DuLieu;
GO

CREATE TABLE CongViec (
    MaSach  NVARCHAR(15) NOT NULL PRIMARY KEY,   -- khóa chính, tối đa 15 ký tự
    TenSach NTEXT        NOT NULL,               -- tên sách, không rỗng
    GiaTien NVARCHAR(12) NOT NULL                -- giá tiền sách, tối đa 12 ký tự, không rỗng
);
GO

INSERT INTO CongViec (MaSach, TenSach, GiaTien) VALUES
(N'S001', N'Lập trình C# cơ bản', N'180000'),
(N'S002', N'Cấu trúc dữ liệu',    N'210000'),
(N'S003', N'Giải thuật nâng cao', N'195000'),
(N'S004', N'Nhập môn AI',         N'230000'),
(N'S005', N'Quản trị mạng',       N'175000');
GO

SELECT * FROM CongViec;
GO
