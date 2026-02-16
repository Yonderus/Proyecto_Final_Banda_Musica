<div align="center">

# 🎼 Proyecto Final - Banda de Música 🎵

### Sistema de Gestión Musical desarrollado en C# con WPF

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![WPF](https://img.shields.io/badge/WPF-0078D4?style=for-the-badge&logo=windows&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)](https://visualstudio.microsoft.com/)

<img src="https://user-images.githubusercontent.com/74038190/212284100-561aa473-3905-4a80-b561-0d28506553ee.gif" width="700">

</div>

---

## 📖 Tabla de Contenidos

- [🎯 Descripción](#-descripción)
- [✨ Características](#-características)
- [🏗️ Arquitectura](#️-arquitectura)
- [💻 Tecnologías](#-tecnologías)
- [📋 Requisitos](#-requisitos)
- [🚀 Instalación](#-instalación)
- [▶️ Ejecución](#️-ejecución)
- [🧪 Testing](#-testing)
- [🤝 Contribuir](#-contribuir)
- [👤 Autor](#-autor)

---

## 🎯 Descripción

<div align="center">

**Proyecto Final - Banda de Música** es una aplicación de escritorio robusta y elegante desarrollada en **C# con WPF** que permite gestionar toda la información relacionada con una banda de música de manera eficiente y profesional.

</div>

### 💡 ¿Qué hace este proyecto?

Este sistema implementa una solución completa siguiendo el patrón de diseño **MVC (Modelo-Vista-Controlador)**, garantizando:

- 📊 **Separación de responsabilidades** clara y mantenible
- 🎨 **Interfaz de usuario moderna** con WPF
- 🔧 **Arquitectura escalable** y profesional
- ✅ **Código testeado** con pruebas unitarias

---

## ✨ Características

<table>
<tr>
<td width="50%">

### 🎨 Interfaz Moderna
- Diseño intuitivo con WPF
- Experiencia de usuario fluida
- Interfaz responsive

</td>
<td width="50%">

### 🏗️ Arquitectura Sólida
- Patrón MVC implementado
- Código limpio y organizado
- Fácil mantenimiento

</td>
</tr>
<tr>
<td width="50%">

### 🔒 Calidad Garantizada
- Pruebas unitarias incluidas
- Código bien estructurado
- Buenas prácticas de desarrollo

</td>
<td width="50%">

### 🚀 Alto Rendimiento
- Optimizado para Windows
- Respuesta rápida
- Consumo eficiente de recursos

</td>
</tr>
</table>

---

## 🏗️ Arquitectura

<div align="center">

```mermaid
graph TD
    A[👤 Usuario] -->|Interactúa| B[🎨 Musica.ViewWPF]
    B -->|Solicita acciones| C[🎮 Musica.Controller]
    C -->|Gestiona datos| D[📦 Musica.Model]
    D -->|Retorna información| C
    C -->|Actualiza vista| B
    E[🧪 TestingBanda] -.->|Valida| C
    E -.->|Valida| D
    
    style A fill:#e1f5ff
    style B fill:#fff3cd
    style C fill:#d4edda
    style D fill:#f8d7da
    style E fill:#e7d4f5
```

</div>

### 📁 Estructura del Proyecto

```
📦 Proyecto_Final_Banda_Musica
┣ 📂 Musica.Model
┃ ┗ 📋 Entidades y modelos de datos
┣ 📂 Musica.Controller
┃ ┗ 🎮 Lógica de negocio y controladores
┣ 📂 Musica.ViewWPF
┃ ┗ 🎨 Interfaces de usuario (XAML + C#)
┣ 📂 TestingBanda
┃ ┗ 🧪 Pruebas unitarias
┗ 📄 Banda_Musica.sln
  ┗ ⚙️ Solución de Visual Studio
```

<details>
<summary><b>🔍 Ver descripción detallada de cada capa</b></summary>

<br>

| Componente | Descripción | Responsabilidad |
|:----------:|:------------|:----------------|
| 📦 **Musica.Model** | Capa de Datos | Define las entidades del dominio, estructuras de datos y acceso a la información |
| 🎮 **Musica.Controller** | Capa de Lógica | Implementa las reglas de negocio, orquesta operaciones y conecta Modelo con Vista |
| 🎨 **Musica.ViewWPF** | Capa de Presentación | Maneja la interfaz gráfica, eventos de usuario y visualización de datos |
| 🧪 **TestingBanda** | Capa de Pruebas | Valida el correcto funcionamiento mediante pruebas unitarias |

</details>

---

## 💻 Tecnologías

<div align="center">

| Categoría | Tecnología |
|:---------:|:-----------|
| 🔤 **Lenguaje** | C# 8.0+ |
| 🎯 **Framework** | .NET Framework 4.7.2+ / .NET Core 3.1+ |
| 🎨 **UI Framework** | WPF (Windows Presentation Foundation) |
| 🏗️ **Patrón** | MVC (Model-View-Controller) |
| 🧪 **Testing** | MSTest / NUnit / xUnit |
| 🛠️ **IDE** | Visual Studio 2019+ |

</div>

---

## 📋 Requisitos

<table>
<tr>
<td align="center" width="33%">
<img src="https://img.icons8.com/color/96/000000/visual-studio-2019.png" width="64"/>
<br><b>Visual Studio</b>
<br>2019 o superior
</td>
<td align="center" width="33%">
<img src="https://img.icons8.com/color/96/000000/net-framework.png" width="64"/>
<br><b>.NET Framework</b>
<br>4.7.2 o superior
</td>
<td align="center" width="33%">
<img src="https://img.icons8.com/color/96/000000/windows-10.png" width="64"/>
<br><b>Windows</b>
<br>7 o superior
</td>
</tr>
</table>

---

## 🚀 Instalación

### Paso 1️⃣: Clonar el repositorio

```bash
git clone https://github.com/Yonderus/Proyecto_Final_Banda_Musica.git
cd Proyecto_Final_Banda_Musica
```

### Paso 2️⃣: Abrir en Visual Studio

```bash
# Abre la solución directamente
start Banda_Musica.sln
```

O desde Visual Studio:
- `File` → `Open` → `Project/Solution`
- Navega a la carpeta y selecciona `Banda_Musica.sln`

### Paso 3️⃣: Restaurar dependencias

```bash
# Desde la consola del Administrador de Paquetes
dotnet restore
```

O en Visual Studio:
- Click derecho en la solución → `Restore NuGet Packages`

### Paso 4️⃣: Compilar

```bash
dotnet build
```

O en Visual Studio: `Ctrl + Shift + B`

---

## ▶️ Ejecución

<div align="center">

### 🎯 Método 1: Desde Visual Studio

</div>

1. Establece **Musica.ViewWPF** como proyecto de inicio
   - Click derecho en el proyecto → `Set as StartUp Project`
2. Presiona `F5` o el botón ▶️ **Start**

<div align="center">

### 🎯 Método 2: Desde la línea de comandos

</div>

```bash
cd Musica.ViewWPF
dotnet run
```

---

## 🧪 Testing

<div align="center">

### Ejecutar todas las pruebas

</div>

**Desde Visual Studio:**
```
Test → Test Explorer → Run All Tests
```

**Desde la terminal:**
```bash
dotnet test
```

**Con cobertura de código:**
```bash
dotnet test /p:CollectCoverage=true
```

---

## 🤝 Contribuir

¡Las contribuciones son siempre bienvenidas! 💙

<div align="center">

### 🔄 Flujo de Contribución

</div>

```mermaid
graph LR
    A[🍴 Fork] --> B[🔨 Crear rama]
    B --> C[💻 Codificar]
    C --> D[✅ Commit]
    D --> E[⬆️ Push]
    E --> F[🔀 Pull Request]
    
    style A fill:#e3f2fd
    style B fill:#fff3e0
    style C fill:#f3e5f5
    style D fill:#e8f5e9
    style E fill:#fce4ec
    style F fill:#e0f2f1
```

### 📝 Pasos detallados

1. **Fork** del proyecto
2. Crea tu **Feature Branch**
   ```bash
   git checkout -b feature/NuevaCaracteristica
   ```
3. **Commit** tus cambios
   ```bash
   git commit -m '✨ Add: Nueva característica increíble'
   ```
4. **Push** a la rama
   ```bash
   git push origin feature/NuevaCaracteristica
   ```
5. Abre un **Pull Request** 🎉

### 💡 Convención de Commits

| Emoji | Código | Descripción |
|:-----:|:-------|:------------|
| ✨ | `:sparkles:` | Nueva característica |
| 🐛 | `:bug:` | Corrección de bugs |
| 📝 | `:memo:` | Documentación |
| ♻️ | `:recycle:` | Refactorización |
| 🎨 | `:art:` | Mejoras de UI/UX |
| ⚡ | `:zap:` | Mejora de rendimiento |
| 🧪 | `:test_tube:` | Añadir tests |

---

## 📄 Licencia

<div align="center">

Este proyecto está disponible como **código abierto**.

Si deseas especificar una licencia, considera usar:

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg?style=for-the-badge)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/)
[![Apache License](https://img.shields.io/badge/License-Apache%202.0-blue.svg?style=for-the-badge)](https://opensource.org/licenses/Apache-2.0)

</div>

---

## 👤 Autor

<div align="center">

<img src="https://avatars.githubusercontent.com/u/155857861?v=4" width="100" style="border-radius: 50%"/>

### **Yonderus**

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Yonderus)
[![Email](https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:tu-email@ejemplo.com)

</div>

---

## 📞 Soporte

<div align="center">

¿Necesitas ayuda? ¡Estamos aquí para ti!

[![Issues](https://img.shields.io/badge/Issues-Report%20Bug-red?style=for-the-badge&logo=github)](https://github.com/Yonderus/Proyecto_Final_Banda_Musica/issues)
[![Discussions](https://img.shields.io/badge/Discussions-Ask%20Question-blue?style=for-the-badge&logo=github)](https://github.com/Yonderus/Proyecto_Final_Banda_Musica/discussions)

</div>

---

<div align="center">

### 💖 ¿Te ha gustado el proyecto?

Si este proyecto te ha sido útil, considera darle una ⭐️

<br>

**Desarrollado con** ❤️ **y mucho** ☕

<br>

![Wave](https://user-images.githubusercontent.com/74038190/212284100-561aa473-3905-4a80-b561-0d28506553ee.gif)

---

**© 2026 Yonderus - Proyecto Final Banda de Música**

</div>
