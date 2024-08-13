INSERT INTO [FPTeeth].[dbo].[Accounts] 
    ([Password], [Email], [Gender], [Image], [Status], [UpdateAt], [CreatedAt], [RoleId], [FullName])
VALUES
    ('1', 'hoangtrieuduong1910@gmail.com', '1', NULL, '1', GETDATE(), GETDATE(), 1, N'Hoàng Triệu Dương'),
    ('1', 'nguyenvanan@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 2, N'Nguyễn Văn An'),
    ('1', 'tranbinhtan@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 3, N'Trần Bình Tân'),
    ('1', 'phamminhcuong@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 4, N'Phạm Minh Cường'),
    ('1', 'lequocdung@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 1, N'Lê Quốc Dũng'),
    ('1', 'doanphulan@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 2, N'Đoàn Phú Lân'),
    ('1', 'vuongtrongPhúc@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 3, N'Vương Trọng Phúc'),
    ('1', 'buiducgiang@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 4, N'Bùi Đức Giang'),
    ('1', 'nguyenkhanhh@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 1, N'Nguyễn Khánh Hòa'),
    ('1', 'phamquochuan@example.com', '1', NULL, '1', GETDATE(), GETDATE(), 2, N'Phạm Quốc Huân'),
    ('1', 'doctor1@example.com', 1, NULL, 1, GETDATE(), GETDATE(), 3, N'Nguyễn Minh Tâm'),
    ('1', 'doctor2@example.com', 1, NULL, 1, GETDATE(), GETDATE(), 3, N'Lê Văn Sơn'); 
INSERT INTO [FPTeeth].[dbo].[Clinics] 
    ([Name], [Description], [Address], [Image], [OwnerId], [CreateAt], [UpdateAt], [Status])
VALUES
    (N'Nha Khoa Kim', N'Nha khoa Kim – Chăm sóc sức khỏe răng miệng chuyên sâu.', N'123 Hoàng Văn Thụ, HCM City', NULL, 7, GETDATE(), GETDATE(), 1),
    (N'Nha Khoa Việt Đức', N'Nha khoa Việt Đức – Dịch vụ nha khoa uy tín và chất lượng.', N'456 Nguyễn Trãi, Hà Nội', NULL, 11, GETDATE(), GETDATE(), 1),
    (N'Nha Khoa Paris', N'Nha khoa Paris – Chuyên gia trong điều trị và thẩm mỹ răng miệng.', N'789 Lê Lợi, Đà Nẵng', NULL, 15, GETDATE(), GETDATE(), 1);
INSERT INTO [FPTeeth].[dbo].[Doctors] 
    ([DoB], [AccountId], [ClinicsId])
VALUES
    ('1980-02-15', 8, 2),  -- Trần Bình Tân
    ('1985-09-25', 12, 3), -- Vương Trọng Phúc
    ('1984-03-10', 16, 3),  -- Nguyễn Minh Tâm
    ('1977-07-20', 17, 4);  -- Lê Văn Sơn
INSERT INTO [FPTeeth].[dbo].[Roles] 
    ([Name])
VALUES
    ('ADMIN'),
    ('CLINICOWNER'),
    ('DOCTOR'),
    ('CUSTOMER');
INSERT INTO [FPTeeth].[dbo].[Services] 
    ([Status], [Name])
VALUES
    (1, N'Niềng Răng'),
    (1, N'Tẩy Trắng Răng'),
    (1, N'Bọc Răng Sứ'),
    (1, N'Trồng Răng Implant'),
    (1, N'Nhổ Răng Khôn');
INSERT INTO [FPTeeth].[dbo].[Slot] 
    ([Status], [SlotTime])
VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (1, 4),
    (1, 5),
    (1, 6),
    (1, 7),
    (1, 8),
    (1, 9),
    (1, 10);