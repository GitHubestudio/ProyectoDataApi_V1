# Analítica de Datos: de la API al Almacenamiento y Procesamiento 📊

Este proyecto personal demuestra un flujo de trabajo de datos de backend completo,
desde la ingesta de datos hasta el almacenamiento y el análisis. La solución se construyó
utilizando un stack de tecnologías de .NET para el desarrollo de la API.

# Objetivos del Proyecto 🎯

● Dominar la creación de una API REST con ASP.NET Core y C# para la ingesta y el procesamiento de datos.

● Aprender a gestionar una base de datos SQL Server utilizando Entity Framework Core, evitando sentencias SQL manuales.

● Realizar análisis de datos del lado del servidor usando LINQ para obtener métricas de negocio clave.

# Características Principales 🌟

● API de Carga de Datos:
Un endpoint POST recibe datos de ventas en formato JSON,
los deserializa y los almacena en la base de datos de manera eficiente.

● Paginación Eficiente:
El endpoint de datos de ventas implementa paginación (?pagina=1&tamanoDePagina=25)
para manejar grandes volúmenes de datos de manera óptima.

● Análisis del Lado del Servidor:
La API incluye varios endpoints GET avanzados para obtener métricas clave:

•Total de Ventas 💰

• Ventas por Producto 📦

• Ingresos Totales 📈

• Ingresos por Producto 💲

# Tecnologías Utilizadas 🛠️

● Backend: C#, ASP.NET Core, Entity Framework Core

● Base de Datos: SQL Server

● Pruebas de API: Postman

# Cómo Ejecutar el Proyecto ▶️

Clona este repositorio.

Abre el proyecto en Visual Studio.

Configura tu cadena de conexión a SQL Server en appsettings.json.

Ejecuta la migración inicial de la base de datos con los siguientes comandos en la Consola del Administrador de Paquetes:

Add-Migration InitialCreate

Update-Database

Ejecuta la aplicación (F5) y usa Postman para enviar datos al endpoint POST /api/Datos/cargar.

Conéctate a tu base de datos desde Power BI para construir tu dashboard de análisis.
