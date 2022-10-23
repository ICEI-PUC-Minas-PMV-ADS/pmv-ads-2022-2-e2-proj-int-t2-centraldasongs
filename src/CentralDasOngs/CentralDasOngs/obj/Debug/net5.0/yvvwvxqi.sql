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

CREATE TABLE [bancos] (
    [Codigo] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_bancos] PRIMARY KEY ([Codigo])
);
GO

CREATE TABLE [ufs] (
    [uf] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_ufs] PRIMARY KEY ([uf])
);
GO

CREATE TABLE [UsuariosOng] (
    [Cnpj_Id] nvarchar(450) NOT NULL,
    [Cnpj] nvarchar(max) NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [Contato] nvarchar(max) NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_UsuariosOng] PRIMARY KEY ([Cnpj_Id])
);
GO

CREATE TABLE [UsuariosVoluntarios] (
    [Cpf_Id] nvarchar(450) NOT NULL,
    [Cpf] nvarchar(max) NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [Contato] nvarchar(max) NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_UsuariosVoluntarios] PRIMARY KEY ([Cpf_Id])
);
GO

CREATE TABLE [DadosBancarios] (
    [Id] int NOT NULL IDENTITY,
    [NumeroConta] nvarchar(max) NOT NULL,
    [Agencia] int NOT NULL,
    [Operacao] int NOT NULL,
    [Codigo] int NOT NULL,
    [UsuarioOngCnpj] nvarchar(450) NULL,
    CONSTRAINT [PK_DadosBancarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DadosBancarios_bancos_Codigo] FOREIGN KEY ([Codigo]) REFERENCES [bancos] ([Codigo]) ON DELETE CASCADE,
    CONSTRAINT [FK_DadosBancarios_UsuariosOng_UsuarioOngCnpj] FOREIGN KEY ([UsuarioOngCnpj]) REFERENCES [UsuariosOng] ([Cnpj_Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [enderecos] (
    [Id] int NOT NULL IDENTITY,
    [Logradouro] nvarchar(max) NOT NULL,
    [Bairro] nvarchar(max) NOT NULL,
    [NumeroEndereco] int NOT NULL,
    [Complemento] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NOT NULL,
    [UsuarioVoluntarioCpf] nvarchar(450) NULL,
    [UsuarioOngCnpj] nvarchar(450) NULL,
    [Uf] nvarchar(450) NULL,
    CONSTRAINT [PK_enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_enderecos_ufs_Uf] FOREIGN KEY ([Uf]) REFERENCES [ufs] ([uf]) ON DELETE NO ACTION,
    CONSTRAINT [FK_enderecos_UsuariosOng_UsuarioOngCnpj] FOREIGN KEY ([UsuarioOngCnpj]) REFERENCES [UsuariosOng] ([Cnpj_Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_enderecos_UsuariosVoluntarios_UsuarioVoluntarioCpf] FOREIGN KEY ([UsuarioVoluntarioCpf]) REFERENCES [UsuariosVoluntarios] ([Cpf_Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_DadosBancarios_Codigo] ON [DadosBancarios] ([Codigo]);
GO

CREATE INDEX [IX_DadosBancarios_UsuarioOngCnpj] ON [DadosBancarios] ([UsuarioOngCnpj]);
GO

CREATE INDEX [IX_enderecos_Uf] ON [enderecos] ([Uf]);
GO

CREATE INDEX [IX_enderecos_UsuarioOngCnpj] ON [enderecos] ([UsuarioOngCnpj]);
GO

CREATE INDEX [IX_enderecos_UsuarioVoluntarioCpf] ON [enderecos] ([UsuarioVoluntarioCpf]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221023050952_Inicial', N'5.0.17');
GO

COMMIT;
GO

