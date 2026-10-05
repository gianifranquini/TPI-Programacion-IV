# AppleStore API

API REST desarrollada como proyecto para la materia Programación IV de la Tecnicatura Universitaria en Programación.

El proyecto simula el backend de una tienda de productos Apple y permite gestionar productos, categorías, usuarios y pedidos. También cuenta con autenticación mediante JWT, manejo de roles y consumo de una API externa para consultar la cotización del dólar oficial.

## Tecnologías

- C# y .NET
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT
- BCrypt
- Swagger / OpenAPI
- Git y GitHub
- GitHub Actions
- Microsoft Azure

## Funcionalidades principales

- Gestión de productos y categorías
- Registro y gestión de usuarios
- Gestión de pedidos y sus detalles
- Autenticación mediante JWT
- Autorización por roles (Administrador y Cliente)
- Contraseñas almacenadas mediante hash con BCrypt
- Consulta de la cotización del dólar oficial mediante una API externa
- Documentación y prueba de endpoints con Swagger
- Persistencia de datos con Entity Framework Core y SQL Server

## Arquitectura

El proyecto está organizado siguiendo una arquitectura por capas:

- **Domain:** entidades y reglas principales del dominio.
- **Application:** servicios, interfaces y lógica de la aplicación.
- **Infrastructure:** acceso a datos con Entity Framework Core e implementación de repositorios.
- **API:** controladores, autenticación y configuración de la aplicación.

Para el acceso a datos se utilizó un repositorio genérico junto con inyección de dependencias.

## Deploy

La API fue desplegada en Microsoft Azure utilizando **Azure App Service** y **Azure SQL Database**.

También se configuró un flujo de **CI/CD con GitHub Actions** para compilar y desplegar el proyecto automáticamente ante nuevos cambios en el repositorio.

## Equipo

-Lorenzo Piatti
-Gianina Franquini
-Valentino Gentiletti
