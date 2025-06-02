# 🌱 Demeter: Sistema de Gestión para Mercados Agrícolas 🌾

<p align="center">
  <img src="GUI/image/LogoDemeter_ORIGINAL (2).png" alt="Logo Demeter"/>
</p>

**Demeter** es un sistema de escritorio diseñado para la gestión integral de mercados agrícolas físicos en Colombia. Este proyecto, desarrollado como una iniciativa académica, sienta las bases para una visión más amplia: transformar y modernizar el sector agrícola colombiano, facilitando una conexión más directa y justa entre productores y consumidores.

[![Estado del Proyecto](https://img.shields.io/badge/estado-en%20desarrollo-yellowgreen)](https://github.com/jeda-ca/demeter) [![Lenguaje](https://img.shields.io/badge/lenguaje-C%23-blueviolet)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Framework](https://img.shields.io/badge/framework-.NET%20Framework-blue)](https://dotnet.microsoft.com/)
[![UI](https://img.shields.io/badge/UI-Windows%20Forms-orange)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/?view=netdesktop-6.0)
[![BaseDeDatos](https://img.shields.io/badge/base%20de%20datos-SQL%20Server-critical)](https://www.microsoft.com/es-es/sql-server)

---

## 🌟 Visión del Proyecto (A Largo Plazo)

El sueño detrás de Demeter es construir un **ecosistema tecnológico integral** que revolucione la comercialización agrícola en Colombia. Aspiramos a:

* 🔗 **Conectar directamente** a los campesinos con los compradores finales.
* 💸 **Eliminar intermediarios** que reducen significativamente los márgenes de ganancia de los agricultores.
* 💪 **Empoderar a los productores** con herramientas digitales que optimicen sus operaciones y maximicen sus ingresos.
* 🌱 **Fomentar prácticas justas y transparentes** en toda la cadena de valor agrícola.
* 💡 **Modernizar el agro colombiano** mediante la investigación, el desarrollo de software especializado, propuestas logísticas y la búsqueda de apoyos estratégicos.

## 🎯 Demeter: El Sistema de Gestión Actual (Proyecto Semestral)

Como un primer paso crucial hacia nuestra visión a largo plazo, la versión actual de **Demeter** se enfoca en ser una solución robusta para la **gestión de mercados agrícolas físicos**.

### ⚠️ El Problema que Soluciona

Los mercados agrícolas locales en Colombia a menudo carecen de herramientas sistematizadas, lo que resulta en:

* 📉 Dificultad para llevar un control preciso del inventario y el stock.
* ✍️ Procesos manuales o ineficientes para el registro de ventas, vendedores y clientes.
* 📊 Falta de información consolidada para la toma de decisiones y análisis del mercado.

**Demeter** aborda estos desafíos proporcionando una plataforma centralizada y eficiente.

### 👥 Público Objetivo

Este sistema está diseñado para organizaciones que son el corazón de la agricultura local:

* 🤝 Cooperativas de productores.
* 🌾 Asociaciones rurales.
* 🧺 Mercados campesinos.
* 🏙️ Plazas de mercado municipales.
* 🚚 Centrales de abastos locales.

### ✨ Funcionalidades Clave de Demeter

* **👤 Gestión de Usuarios:**
    * **Administradores:** Control total del sistema, gestión de vendedores, clientes, categorías, productos, inventario global, reportes y usuarios.
    * **Vendedores:** Gestión de sus propios productos (altas, bajas, modificaciones de stock, precios), registro de nuevos clientes y procesamiento de ventas con actualización automática de inventario.
* **📦 Gestión de Productos e Inventario:** Registro detallado de productos agrícolas, manejo de stock, precios, categorías y unidades de medida.
* **🛒 Gestión de Ventas:** Registro de transacciones, actualización automática de inventario y generación de datos para informes.
* **🧑‍🤝‍🧑 Gestión de Clientes y Vendedores:** Administración centralizada de la información de contacto y actividad en el mercado.
* **📊 Generación de Informes y Dashboards:** Visualización de datos clave para la toma de decisiones, tanto para administradores (visión global y por vendedor) como para vendedores (su propio desempeño).

---

## 🛠️ Pila Tecnológica (Stack)

* **Lenguaje de Programación:** C#
* **Framework:** .NET Framework (versión 4.7.2 o superior)
* **Interfaz de Usuario (UI):** Windows Forms
* **Base de Datos:** Microsoft SQL Server
* **Acceso a Datos:** ADO.NET
* **Librerías Adicionales:**
    * FontAwesome.Sharp (para iconografía moderna en la UI)
    * RJCodeAdvance.RJControls (para controles de UI personalizados)

## 🏗️ Arquitectura y Diseño

El proyecto Demeter se ha desarrollado siguiendo una arquitectura por capas y aplicando principios y patrones de diseño para asegurar un software robusto, mantenible y escalable.

### 🧱 Estructura del Proyecto (Capas)

1.  **`ENTITY` (Capa de Entidades):**
    * Define las clases POCO (Plain Old CLR Object) que representan los objetos de dominio del sistema (Ej: `Producto`, `Venta`, `Usuario`, `Cliente`, etc.).
2.  **`DAL` (Capa de Acceso a Datos):**
    * Responsable de la persistencia y recuperación de datos de la base de datos (`DEMETER_DB`).
    * Implementa el patrón **Repositorio** (`IGenericRepository<T>`, `IProductoRepository`, etc.) para abstraer las operaciones de datos.
    * Utiliza ADO.NET para la comunicación directa con SQL Server.
    * Incluye un `ConnectionHelper` para gestionar la cadena de conexión.
3.  **`BLL` (Capa de Lógica de Negocio):**
    * Contiene la lógica de negocio central de la aplicación.
    * Implementa servicios (`IUsuarioService`, `IProductoService`, etc.) que orquestan las operaciones y aplican las reglas de negocio, utilizando los repositorios de la capa DAL.
4.  **`GUI` (Capa de Interfaz Gráfica de Usuario):**
    * Aplicación de escritorio desarrollada con Windows Forms.
    * Interactúa con la capa BLL para presentar datos y procesar las acciones del usuario.
    * Utiliza `SessionManager` para gestionar la información del usuario autenticado y `AppContext` para controlar el flujo de la aplicación.

### 🎨 Patrones de Diseño Implementados

* **Patrón Repositorio:** Utilizado en la capa DAL para desacoplar la lógica de acceso a datos de la lógica de negocio. Facilita la intercambiabilidad de la fuente de datos y mejora la testeabilidad.
* **Patrón DAO (Data Access Object):** Aunque el patrón Repositorio es el principal, los repositorios concretos actúan de manera similar a los DAOs, encapsulando el acceso a datos para cada entidad.

### 💡 Principios de Diseño Aplicados

* **SOLID:** Se ha intentado adherirse a los principios SOLID para crear un código más limpio, flexible y fácil de mantener:
    * **S**ingle Responsibility Principle (SRP): Cada clase y método tiene una responsabilidad bien definida.
    * **O**pen/Closed Principle (OCP): Las entidades y servicios están diseñados para ser extensibles sin modificar su código existente (ej. mediante herencia e interfaces).
    * **L**iskov Substitution Principle (LSP): Las clases derivadas (ej. `Administrador`, `Vendedor` de `Usuario`) pueden sustituir a sus clases base.
    * **I**nterface Segregation Principle (ISP): Se utilizan interfaces específicas para los repositorios y servicios (`IProductoRepository`, `IProductoService`).
    * **D**ependency Inversion Principle (DIP): Las capas de alto nivel (BLL) dependen de abstracciones (interfaces DAL) en lugar de implementaciones concretas.
* **GRASP (General Responsibility Assignment Software Patterns):** Aunque no se declaran explícitamente en cada clase, se han tenido en cuenta principios como:
    * **Experto en Información:** La clase que tiene la información necesaria para cumplir una responsabilidad es la que la cumple.
    * **Creador:** Se asigna la responsabilidad de crear un objeto a la clase que lo agrega, contiene o registra.
    * **Bajo Acoplamiento y Alta Cohesión:** Se busca minimizar las dependencias entre módulos y asegurar que las responsabilidades dentro de un módulo estén fuertemente relacionadas.

---

## 🔄 Metodología de Desarrollo

El desarrollo de Demeter ha seguido un enfoque **Iterativo e Incremental**. Esto ha permitido:

* Construir el sistema en ciclos cortos, entregando funcionalidades completas en cada iteración.
* Obtener retroalimentación temprana y realizar ajustes continuos.
* Gestionar la complejidad del proyecto dividiéndolo en módulos manejables.
* Adaptarse a los requisitos y comprensiones que evolucionan a medida que avanza el proyecto.

---

## 🗃️ Base de Datos

* **Sistema Gestor:** Microsoft SQL Server.
* **Nombre de la BD:** `DEMETER_DB`.
* **Scripts SQL:**
    * `CreateDB_Tables.sql`: Creación de la estructura de tablas y relaciones.
    * `CreateAndDropDB_Tables.sql`: Script para recrear la base de datos (elimina y crea).
    * `Seed.sql`: Inserción de datos iniciales para catálogos y ejemplos.
    * `VistasyProcedimientos.sql`: Creación de vistas SQL para simplificar consultas complejas y mejorar el rendimiento en ciertas operaciones de lectura.

---

## 🚀 Cómo Empezar (Prerrequisitos)

1.  **Software:**
    * Microsoft SQL Server (Express, Developer, o Standard edition).
    * SQL Server Management Studio (SSMS) o una herramienta similar para gestionar la BD.
    * Visual Studio (2019 o superior recomendado) con la carga de trabajo de ".NET desktop development".
2.  **Configuración de la Base de Datos:**
    * Ejecutar el script `CreateDB_Tables.sql` (o `CreateAndDropDB_Tables.sql` si se desea una base limpia) en su instancia de SQL Server para crear la base de datos `DEMETER_DB` y sus tablas.
    * Ejecutar el script `Seed.sql` para poblar las tablas con datos iniciales.
    * Ejecutar el script `VistasyProcedimientos.sql` para crear las vistas necesarias.
3.  **Configuración de la Aplicación:**
    * Clonar este repositorio.
    * Abrir la solución (`.sln`) en Visual Studio.
    * **Importante:** Verificar y actualizar la cadena de conexión `DemeterDBConnection` en el archivo `GUI/App.config` para que apunte a su instancia local de SQL Server y utilice las credenciales correctas.
        ```xml
        <connectionStrings>
          <add name="DemeterDBConnection" 
               connectionString="Server=TU_SERVIDOR_SQL;Database=DEMETER_DB;User ID=TU_USUARIO;Password=TU_CONTRASENA;" 
               providerName="System.Data.SqlClient" />
        </connectionStrings>
        ```
    * Compilar y ejecutar el proyecto desde Visual Studio (establecer `GUI` como proyecto de inicio).

---

## 🧑‍💻 Equipo de Desarrollo

* **Jesús David Carvajal Coneo** - Desarrollador Principal
* **María Isabel García Moscoso** - Desarrolladora Principal

_Estudiantes de Ingeniería de Sistemas, Universidad Popular del Cesar, Valledupar, Cesar, Colombia._ 🇨🇴

---

## 🚧 Estado del Proyecto

Actualmente, Demeter es un proyecto universitario en desarrollo. Se han implementado las funcionalidades principales descritas, pero siempre hay espacio para mejoras, nuevas características y la eventual transición hacia la visión a largo plazo.

---

¡Gracias por tu interés en Demeter! 🌱
