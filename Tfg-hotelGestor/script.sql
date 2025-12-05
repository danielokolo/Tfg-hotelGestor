CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;
ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `CustomerBasicInfo` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nif` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `BankAcountNumber` longtext CHARACTER SET utf8mb4 NOT NULL,
    `FirstSurname` longtext CHARACTER SET utf8mb4 NOT NULL,
    `LastSurname` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_CustomerBasicInfo` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `CustomerContact` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Tlf_number` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Address` longtext CHARACTER SET utf8mb4 NOT NULL,
    `MailAddress` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_CustomerContact` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ProductType` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Type` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_ProductType` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `RoomType` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TypeRoom` longtext CHARACTER SET utf8mb4 NOT NULL,
    `RoomCapacity` int NOT NULL,
    CONSTRAINT `PK_RoomType` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `UserType` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Type` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_UserType` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Customer` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CustomerBasicInfoId` int NOT NULL,
    `VacancyId` int NOT NULL,
    `ContactId` int NOT NULL,
    `IsActive` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Customer` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Customer_CustomerBasicInfo_CustomerBasicInfoId` FOREIGN KEY (`CustomerBasicInfoId`) REFERENCES `CustomerBasicInfo` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Customer_CustomerContact_ContactId` FOREIGN KEY (`ContactId`) REFERENCES `CustomerContact` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Product` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `IdProductType` int NOT NULL,
    `ProductTypeId` int NOT NULL,
    `Price` decimal(65,30) NOT NULL,
    CONSTRAINT `PK_Product` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Product_ProductType_ProductTypeId` FOREIGN KEY (`ProductTypeId`) REFERENCES `ProductType` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Room` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoomNumber` int NOT NULL,
    `RoomTypeId` int NOT NULL,
    CONSTRAINT `PK_Room` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Room_RoomType_RoomTypeId` FOREIGN KEY (`RoomTypeId`) REFERENCES `RoomType` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `User` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserTypeId` int NOT NULL,
    `UserName` longtext CHARACTER SET utf8mb4 NOT NULL,
    `HashPassword` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_User` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_User_UserType_UserTypeId` FOREIGN KEY (`UserTypeId`) REFERENCES `UserType` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Vacancy` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `EntryDate` datetime(6) NOT NULL,
    `ExitDate` datetime(6) NOT NULL,
    `RoomId` int NOT NULL,
    CONSTRAINT `PK_Vacancy` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Vacancy_Room_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Room` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Invoices` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` int NOT NULL,
    `RoomId` int NOT NULL,
    `InvoiceDate` datetime(6) NOT NULL,
    `TotalAmount` decimal(65,30) NOT NULL,
    `CustomerId` int NULL,
    CONSTRAINT `PK_Invoices` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Invoices_Customer_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `Customer` (`Id`),
    CONSTRAINT `FK_Invoices_Room_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Room` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Invoices_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `InvoicesDetails` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `InvoiceId` int NOT NULL,
    `ProductId` int NOT NULL,
    `Quantity` int NOT NULL,
    `UnitPrice` decimal(65,30) NOT NULL,
    `Subtotal` decimal(65,30) NOT NULL,
    CONSTRAINT `PK_InvoicesDetails` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_InvoicesDetails_Invoices_InvoiceId` FOREIGN KEY (`InvoiceId`) REFERENCES `Invoices` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_InvoicesDetails_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Product` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE UNIQUE INDEX `IX_Customer_ContactId` ON `Customer` (`ContactId`);

CREATE UNIQUE INDEX `IX_Customer_CustomerBasicInfoId` ON `Customer` (`CustomerBasicInfoId`);

CREATE INDEX `IX_Invoices_CustomerId` ON `Invoices` (`CustomerId`);

CREATE INDEX `IX_Invoices_RoomId` ON `Invoices` (`RoomId`);

CREATE INDEX `IX_Invoices_UserId` ON `Invoices` (`UserId`);

CREATE INDEX `IX_InvoicesDetails_InvoiceId` ON `InvoicesDetails` (`InvoiceId`);

CREATE INDEX `IX_InvoicesDetails_ProductId` ON `InvoicesDetails` (`ProductId`);

CREATE INDEX `IX_Product_ProductTypeId` ON `Product` (`ProductTypeId`);

CREATE INDEX `IX_Room_RoomTypeId` ON `Room` (`RoomTypeId`);

CREATE INDEX `IX_User_UserTypeId` ON `User` (`UserTypeId`);

CREATE INDEX `IX_Vacancy_RoomId` ON `Vacancy` (`RoomId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251204145135_initialmiggration', '9.0.0');

COMMIT;

