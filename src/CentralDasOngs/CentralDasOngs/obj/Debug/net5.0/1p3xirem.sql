IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [banks] (
    [Code] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_banks] PRIMARY KEY ([Code])
);
GO

CREATE TABLE [ufs] (
    [Uf] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_ufs] PRIMARY KEY ([Uf])
);
GO

CREATE TABLE [user_ong] (
    [Cnpj] bigint NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Contact] nvarchar(max) NOT NULL,
    [UserType] int NOT NULL,
    CONSTRAINT [PK_user_ong] PRIMARY KEY ([Cnpj])
);
GO

CREATE TABLE [user_voluntario] (
    [Cpf] bigint NOT NULL,
    [DateBirthDay] datetime2 NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Contact] nvarchar(max) NOT NULL,
    [UserType] int NOT NULL,
    CONSTRAINT [PK_user_voluntario] PRIMARY KEY ([Cpf])
);
GO

CREATE TABLE [ong_bank_information] (
    [Id] int NOT NULL IDENTITY,
    [AccountNumber] nvarchar(max) NOT NULL,
    [Agency] int NOT NULL,
    [AccountType] int NOT NULL,
    [BankId] int NOT NULL,
    [UserOngId] bigint NOT NULL,
    CONSTRAINT [PK_ong_bank_information] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ong_bank_information_banks_BankId] FOREIGN KEY ([BankId]) REFERENCES [banks] ([Code]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ong_bank_information_user_ong_UserOngId] FOREIGN KEY ([UserOngId]) REFERENCES [user_ong] ([Cnpj]) ON DELETE CASCADE
);
GO

CREATE TABLE [adress] (
    [Id] int NOT NULL IDENTITY,
    [State] nvarchar(450) NULL,
    [City] nvarchar(max) NOT NULL,
    [District] nvarchar(max) NOT NULL,
    [Street] nvarchar(max) NOT NULL,
    [HouseNumber] int NOT NULL,
    [Complement] nvarchar(max) NULL,
    [UserVoluntarioId] bigint NULL,
    [UserOngId] bigint NULL,
    CONSTRAINT [PK_adress] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_adress_ufs_State] FOREIGN KEY ([State]) REFERENCES [ufs] ([Uf]) ON DELETE NO ACTION,
    CONSTRAINT [FK_adress_user_ong_UserOngId] FOREIGN KEY ([UserOngId]) REFERENCES [user_ong] ([Cnpj]) ON DELETE CASCADE,
    CONSTRAINT [FK_adress_user_voluntario_UserVoluntarioId] FOREIGN KEY ([UserVoluntarioId]) REFERENCES [user_voluntario] ([Cpf]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_adress_State] ON [adress] ([State]);
GO

CREATE UNIQUE INDEX [IX_adress_UserOngId] ON [adress] ([UserOngId]) WHERE [UserOngId] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_adress_UserVoluntarioId] ON [adress] ([UserVoluntarioId]) WHERE [UserVoluntarioId] IS NOT NULL;
GO

CREATE INDEX [IX_ong_bank_information_BankId] ON [ong_bank_information] ([BankId]);
GO

CREATE UNIQUE INDEX [IX_ong_bank_information_UserOngId] ON [ong_bank_information] ([UserOngId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221024070116_Initial', N'5.0.17');
GO

COMMIT;
GO

