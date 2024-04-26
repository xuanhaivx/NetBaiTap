use[BaiTap_net];
CREATE database BaiTap_net

-- Bài tập SELECT cơ bản - Buôi 11
-- Tạo bảng Employees Bài 1 Buổi 11
create table Employees 
(
EmployeeID int primary key, -- id nhân viên
FirstName nvarchar(20), -- tên đầu
LastName nvarchar(20), -- họ 
Position nvarchar(250), -- chức vụ
DepartmentID int, -- Khoa
Salary decimal(10,2) -- lương
);

-- Thêm dữ liệu vào bảng Employees
insert into [dbo].[Employees](EmployeeID, FirstName, LastName, Position, DepartmentID, Salary)
values (8, N'Nguyệt',N'Vũ',N'Trưởng Phòng',1,1980000),
		(2, N'Ngân',N'Nguyễn',N'Nhân Viên',2,1890000),
		(3, N'Thành',N'Dương',N'Trưởng Nhóm',3,1890000),
		(4, N'Hoàng',N'Võ',N'Giám Đốc',1,1790000),
		(5, N'Nguyệt',N'Nguyễn',N'Nhân Viên',2,1090000),
		(6, N'Khánh',N'Dương',N'Nhân Viên',3,1090000),
		(7, N'Tài',N'Vũ',N'Kế Toán',4,2990000)

-- Truy cấn thông tin bảng
select EmployeeID, FirstName, LastName, Position, DepartmentID, Salary from [dbo].[Employees];

-- Bài tập JOIN - Buôi 11

-- Tạo bảng Departments
create table Departments
(
DepartmentID int primary key,
DepartmentName nvarchar(250)
);

-- Thêm dữ liệu vào bảng Departments
insert into [dbo].[Departments](DepartmentID, DepartmentName)
values (1, N'Kỹ Thuật'),
		(2, N'Kinh Doanh'),
		(3, N'Máy Tính'),
		(4, N'Văn Phòng')

-- Sử dụng INNER JOIN để kết hợp thông tin từ bảng "Employees" và "Departments"
select FirstName, LastName, DepartmentName  from [dbo].[Employees]
inner join [dbo].[Departments] on [dbo].[Departments].DepartmentID = [dbo].[Employees].DepartmentID;

-- Bài tập Aggregation và Group By
select [dbo].[Departments].DepartmentName, Sum([dbo].[Employees].Salary) as SumSalary
from [dbo].[Employees]
inner join [dbo].[Departments] on [dbo].[Departments].DepartmentID = [dbo].[Employees].DepartmentID
group by [DepartmentName] -- tính tổng của các phòng ban sắp xếp theo phòng ban.
order by SumSalary; -- sắp xếp theo mức lương của từng phòng ban từ nhỏ tới lớn.