﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [CLIENTE] (
    [IDCLIENTE] uniqueidentifier NOT NULL,
    [NOME] nvarchar(150) NOT NULL,
    [CPF] nvarchar(11) NOT NULL,
    [EMAIL] nvarchar(100) NOT NULL,
    [SENHA] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_CLIENTE] PRIMARY KEY ([IDCLIENTE])
);

GO

CREATE TABLE [PRODUTO] (
    [IDPRODUTO] uniqueidentifier NOT NULL,
    [NOME] nvarchar(150) NOT NULL,
    [PRECO] decimal(18,2) NOT NULL,
    [QUANTIDADE] int NOT NULL DEFAULT 0,
    [FOTO] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_PRODUTO] PRIMARY KEY ([IDPRODUTO])
);

GO

CREATE TABLE [PEDIDO] (
    [IDPEDIDO] uniqueidentifier NOT NULL,
    [DATAPEDIDO] date NOT NULL,
    [VALOR] decimal(18,2) NOT NULL,
    [IDCLIENTE] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PEDIDO] PRIMARY KEY ([IDPEDIDO]),
    CONSTRAINT [FK_PEDIDO_CLIENTE_IDCLIENTE] FOREIGN KEY ([IDCLIENTE]) REFERENCES [CLIENTE] ([IDCLIENTE]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_CLIENTE_CPF] ON [CLIENTE] ([CPF]);

GO

CREATE UNIQUE INDEX [IX_CLIENTE_EMAIL] ON [CLIENTE] ([EMAIL]);

GO

CREATE INDEX [IX_PEDIDO_IDCLIENTE] ON [PEDIDO] ([IDCLIENTE]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210702142433_Initial', N'3.1.16');

GO
