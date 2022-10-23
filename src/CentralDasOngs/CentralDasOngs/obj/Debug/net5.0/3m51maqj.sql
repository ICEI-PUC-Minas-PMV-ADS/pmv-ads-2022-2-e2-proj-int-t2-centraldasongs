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

CREATE TABLE [ufs] (
    [uf] char(2) NOT NULL,
    CONSTRAINT [PK_ufs] PRIMARY KEY ([uf])
);
GO

CREATE TABLE [UsuariosVoluntarios] (
    [Cpf_Id] nvarchar(14) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [Contato] varchar(14) NOT NULL,
    CONSTRAINT [PK_UsuariosVoluntarios] PRIMARY KEY ([Cpf_Id])
);
GO

CREATE TABLE [enderecos] (
    [Id] int NOT NULL IDENTITY,
    [Logradouro] nvarchar(max) NOT NULL,
    [Bairro] nvarchar(max) NOT NULL,
    [NumeroEndereco] int NOT NULL,
    [Complemento] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NOT NULL,
    [UsuarioVoluntarioCpf] nvarchar(14) NULL,
    [Uf] char(2) NULL,
    CONSTRAINT [PK_enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_enderecos_ufs_Uf] FOREIGN KEY ([Uf]) REFERENCES [ufs] ([uf]) ON DELETE NO ACTION,
    CONSTRAINT [FK_enderecos_UsuariosVoluntarios_UsuarioVoluntarioCpf] FOREIGN KEY ([UsuarioVoluntarioCpf]) REFERENCES [UsuariosVoluntarios] ([Cpf_Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_enderecos_Uf] ON [enderecos] ([Uf]);
GO

CREATE INDEX [IX_enderecos_UsuarioVoluntarioCpf] ON [enderecos] ([UsuarioVoluntarioCpf]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221022023504_Usuario_Voluntario', N'5.0.17');
GO

COMMIT;
GO

