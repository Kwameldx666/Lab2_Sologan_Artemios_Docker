# 🏗️ Lab2 Sologan Artemios Docker - .NET 9 with MAUI

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)
![MAUI](https://img.shields.io/badge/MAUI-Cross--Platform-512BD4?style=for-the-badge&logo=dotnet)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

## 📋 Описание проекта

Современное микросервисное приложение для управления задачами и категориями, построенное на **.NET 9** с использованием **.NET MAUI** для мобильной разработки. Проект демонстрирует интеграцию современных технологий Microsoft для создания полнофункционального решения с мобильным клиентом.

## 🏛️ Архитектура

```
┌─────────────────┐    HTTP     ┌──────────────────┐
│   MAUI Client   │─────────────▶│  CategoryService │
│   (Android)     │             │    (.NET 9)      │
│     Port App    │             │    Port 5000     │
└─────────────────┘             └──────────────────┘
        │                               │
        │ HTTP                          │ HTTP
        ▼                               ▼
┌──────────────────┐             ┌─────────────────┐
│   TaskService    │             │   SQL Server    │
│   (.NET 9)       │─────────────▶│   Database      │
│   Port 5001      │   EF Core    │   Port 1433     │
└──────────────────┘             └─────────────────┘
```

### 🔧 Компоненты системы

- **TaskManagerApp** - .NET MAUI кроссплатформенное мобильное приложение
- **CategoryService** - REST API для управления категориями задач (.NET 9)
- **TaskService** - Web-приложение для управления задачами (.NET 9)
- **SQL Server** - База данных для хранения информации
- **Docker Network** - Объединение всех сервисов в единую сеть

## 🛠️ Технологический стек

- **Mobile Framework**: .NET MAUI (.NET 9.0)
- **Backend Framework**: ASP.NET Core 9.0
- **Database**: Microsoft SQL Server 2022
- **ORM**: Entity Framework Core 9.0.2
- **Documentation**: Swagger/OpenAPI
- **Containerization**: Docker & Docker Compose
- **Language**: C# with nullable reference types
- **HTTP Client**: System.Text.Json with HttpClientFactory

## 📱 Новые возможности MAUI

### MAUI Application Features
- **Кроссплатформенность**: Android, iOS, Windows, macOS
- **Нативный UI**: Платформо-специфичные элементы интерфейса
- **HTTP Integration**: Интеграция с REST API через HttpClient
- **Dependency Injection**: Встроенная поддержка DI
- **Hot Reload**: Мгновенные изменения во время разработки

## 📦 Предварительные требования

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) с MAUI workload
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Android SDK](https://developer.android.com/studio) (для мобильной разработки)

### Установка MAUI workload
```bash
dotnet workload install maui-android
```

## 🚀 Быстрый старт

### 1. Клонирование репозитория

```bash
git clone https://github.com/Kwameldx666/Lab2_Sologan_Artemios_Docker.git
cd Lab2_Sologan_Artemios_Docker
```

### 2. Сборка решения

```bash
dotnet build
```

### 3. Запуск API сервисов

```bash
# Сборка и запуск всех сервисов
docker compose up --build

# Или запуск в фоновом режиме
docker compose up -d --build
```

### 4. Запуск MAUI приложения

```bash
cd TaskManagerApp
dotnet build -f net9.0-android
```

Для запуска в эмуляторе Android:
```bash
dotnet build -f net9.0-android -p:AndroidSdkDirectory="C:\Program Files (x86)\Android\android-sdk"
```

### 5. Проверка работоспособности

После успешного запуска сервисы будут доступны по следующим адресам:

- **Category Service API**: http://localhost:5000
- **Category Service Swagger**: http://localhost:5000/swagger
- **Task Service**: http://localhost:5001
- **Task Service Swagger**: http://localhost:5001/swagger
- **SQL Server**: localhost:1433

## 📱 MAUI Application

### Возможности мобильного приложения

1. **Управление задачами**
   - Загрузка всех задач из API
   - Создание новых задач
   - Отображение статуса выполнения

2. **Управление категориями**
   - Загрузка всех категорий из API
   - Создание новых категорий
   - Просмотр количества связанных задач

3. **Сетевое взаимодействие**
   - Автоматическое определение среды выполнения
   - Поддержка эмулятора Android (10.0.2.2)
   - Поддержка Docker networking
   - Обработка ошибок сети

### Сетевая конфигурация MAUI

Приложение автоматически определяет правильные адреса API:
- **Android Emulator**: `http://10.0.2.2:5000`, `http://10.0.2.2:5001`
- **Docker Environment**: `http://categoryservice:5000`, `http://taskservice:5001`

## 📁 Структура проекта

```
Lab2_Sologan_Artemios_Docker/
├── 📄 README.md                    # Документация проекта
├── 📄 Lab2.sln                     # Solution файл (.NET 9)
├── 📄 docker-compose.yml           # Конфигурация Docker Compose
├── 📁 CategoryService/             # Микросервис категорий (.NET 9)
│   ├── 📄 CategoryService.csproj   # Проект файл
│   ├── 📄 Dockerfile               # Docker конфигурация (.NET 9)
│   └── 📁 [Other files...]
├── 📁 TaskService/                 # Микросервис задач (.NET 9)
│   ├── 📄 TaskService.csproj       # Проект файл
│   ├── 📄 Dockerfile               # Docker конфигурация (.NET 9)
│   └── 📁 [Other files...]
└── 📁 TaskManagerApp/              # MAUI мобильное приложение
    ├── 📄 TaskManagerApp.csproj    # MAUI проект файл
    ├── 📄 MauiProgram.cs           # Конфигурация MAUI
    ├── 📄 MainPage.xaml            # Главная страница UI
    ├── 📄 MainPage.xaml.cs         # Code-behind
    ├── 📁 Models/                  # Модели данных
    │   ├── 📄 Category.cs          # Модель категории
    │   └── 📄 TaskItem.cs          # Модель задачи
    ├── 📁 Services/                # HTTP сервисы
    │   ├── 📄 CategoryService.cs   # Сервис для работы с категориями
    │   └── 📄 TaskService.cs       # Сервис для работы с задачами
    └── 📁 Resources/               # Ресурсы приложения
        ├── 📁 Images/              # Изображения
        ├── 📁 Fonts/               # Шрифты
        └── 📁 AppIcon/             # Иконки приложения
```

## 🧪 Тестирование MAUI приложения

### Тестирование в эмуляторе Android
1. Запустите API сервисы через `docker compose up`
2. Откройте Android эмулятор
3. Запустите MAUI приложение
4. Используйте кнопки в приложении для тестирования API

### Тестирование функций
- **Load All Tasks**: Тестирует GET запрос к TaskService API
- **Create Sample Task**: Тестирует POST запрос к TaskService API
- **Load All Categories**: Тестирует GET запрос к CategoryService API
- **Create Sample Category**: Тестирует POST запрос к CategoryService API

## 🔧 Разработка

### Запуск в режиме разработки
```bash
# API сервисы
docker compose up -d

# MAUI приложение (Visual Studio)
# Откройте TaskManagerApp.csproj в Visual Studio
# Выберите Android эмулятор и запустите проект
```

### Hot Reload для MAUI
Поддерживается автоматическое обновление UI без перезапуска приложения при изменении XAML файлов.

## 📞 Поддержка

Если у вас возникли вопросы или проблемы:

1. Убедитесь, что установлен .NET 9.0 SDK
2. Проверьте, что MAUI workload установлен
3. Убедитесь, что API сервисы запущены через Docker
4. Создайте [Issue](https://github.com/Kwameldx666/Lab2_Sologan_Artemios_Docker/issues)

## 👨‍💻 Автор

**Sologan Artemios** - [@Kwameldx666](https://github.com/Kwameldx666)

---

⭐ Поставьте звезду, если проект был полезен!

---

<div align="center">
  <h3>🔧 Создано с помощью современных технологий .NET 9 и MAUI</h3>
  
  ![Architecture](https://img.shields.io/badge/Architecture-Microservices-orange)
  ![MAUI](https://img.shields.io/badge/Mobile-MAUI-purple)
  ![Status](https://img.shields.io/badge/Status-Production%20Ready-brightgreen)
  ![.NET 9](https://img.shields.io/badge/.NET-9.0-blue)
</div>

## 📦 Предварительные требования

Убедитесь, что у вас установлены следующие компоненты:

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) или Docker Engine
- [Docker Compose](https://docs.docker.com/compose/) (обычно входит в Docker Desktop)
- [Git](https://git-scm.com/) для клонирования репозитория

## 🚀 Быстрый старт

### 1. Клонирование репозитория

```bash
git clone https://github.com/Kwameldx666/Lab2_Sologan_Artemios_Docker.git
cd Lab2_Sologan_Artemios_Docker
```

### 2. Запуск приложения

```bash
# Сборка и запуск всех сервисов
docker compose up --build

# Или запуск в фоновом режиме
docker compose up -d --build
```

### 3. Проверка работоспособности

После успешного запуска сервисы будут доступны по следующим адресам:

- **Category Service API**: http://localhost:5000
- **Category Service Swagger**: http://localhost:5000/swagger
- **Task Service**: http://localhost:5001
- **Task Service Swagger**: http://localhost:5001/swagger
- **SQL Server**: localhost:1433

## 📚 API Документация

### CategoryService Endpoints

| Метод | Endpoint | Описание |
|-------|----------|----------|
| GET | `/api/categories` | Получить все категории |
| GET | `/api/categories/{id}` | Получить категорию по ID |
| POST | `/api/categories` | Создать новую категорию |
| PUT | `/api/categories/{id}` | Обновить категорию |
| DELETE | `/api/categories/{id}` | Удалить категорию |

### TaskService Endpoints

| Метод | Endpoint | Описание |
|-------|----------|----------|
| GET | `/api/tasks` | Получить все задачи |
| GET | `/api/tasks/{id}` | Получить задачу по ID |
| POST | `/api/tasks` | Создать новую задачу |
| PUT | `/api/tasks/{id}` | Обновить задачу |
| DELETE | `/api/tasks/{id}` | Удалить задачу |

## 📁 Структура проекта

```
Lab2_Sologan_Artemios_Docker/
├── 📄 README.md                    # Документация проекта
├── 📄 Lab2.sln                     # Solution файл
├── 📄 docker-compose.yml           # Конфигурация Docker Compose
├── 📄 .dockerignore                # Игнорируемые Docker файлы
├── 📄 .gitignore                   # Игнорируемые Git файлы
├── 📁 CategoryService/             # Микросервис категорий
│   ├── 📄 CategoryService.csproj   # Проект файл
│   ├── 📄 Dockerfile               # Docker конфигурация
│   ├── 📄 Program.cs               # Точка входа приложения
│   ├── 📁 Controllers/             # API контроллеры
│   ├── 📁 Models/                  # Модели данных
│   ├── 📁 Data/                    # Контекст базы данных
│   └── 📁 Properties/              # Конфигурация приложения
└── 📁 TaskService/                 # Микросервис задач
    ├── 📄 TaskService.csproj       # Проект файл
    ├── 📄 Dockerfile               # Docker конфигурация
    ├── 📄 Program.cs               # Точка входа приложения
    ├── 📁 Controllers/             # API контроллеры
    ├── 📁 Models/                  # Модели данных
    ├── 📁 Pages/                   # Razor страницы
    ├── 📁 wwwroot/                 # Статические файлы
    └── 📁 Properties/              # Конфигурация приложения
```

## 🐳 Docker конфигурация

### Образы Docker Hub

Проект использует следующие образы:

- `kwameldx666/category-service:latest`
- `kwameldx666/task-service:latest`
- `mcr.microsoft.com/mssql/server:2022-latest`

### Сетевая конфигурация

Все сервисы работают в единой Docker сети `mynetwork` типа bridge, что обеспечивает безопасную коммуникацию между контейнерами.

## 🔧 Управление сервисами

### Полезные команды Docker Compose

```bash
# Просмотр логов всех сервисов
docker compose logs

# Просмотр логов конкретного сервиса
docker compose logs category-service
docker compose logs task-service

# Остановка всех сервисов
docker compose down

# Остановка с удалением volumes
docker compose down -v

# Пересборка конкретного сервиса
docker compose build category-service

# Просмотр статуса сервисов
docker compose ps
```

### Подключение к базе данных

Для подключения к SQL Server используйте следующие параметры:

- **Server**: localhost,1433
- **Database**: TaskDb / CategoryDb
- **User**: sa
- **Password**: Kwameldx666
- **Trust Server Certificate**: true

## 🧪 Тестирование

### Проверка API через curl

```bash
# Получение всех категорий
curl -X GET http://localhost:5000/api/categories

# Создание новой категории
curl -X POST http://localhost:5000/api/categories \
  -H "Content-Type: application/json" \
  -d '{"name":"Test Category"}'

# Получение всех задач
curl -X GET http://localhost:5001/api/tasks

# Создание новой задачи
curl -X POST http://localhost:5001/api/tasks \
  -H "Content-Type: application/json" \
  -d '{"title":"Test Task","isComplete":false}'
```

## 🐛 Устранение неполадок

### Типичные проблемы

1. **Порты заняты**: Убедитесь, что порты 5000, 5001 и 1433 свободны
2. **Недостаточно памяти**: SQL Server требует минимум 2GB RAM
3. **Проблемы с подключением к БД**: Дождитесь полной инициализации SQL Server

### Проверка работоспособности

```bash
# Проверка статуса контейнеров
docker compose ps

# Проверка логов SQL Server
docker compose logs sql-server

# Проверка доступности API
curl http://localhost:5000/swagger
curl http://localhost:5001/swagger
```

## 🤝 Вклад в проект

1. Форкните репозиторий
2. Создайте feature branch (`git checkout -b feature/amazing-feature`)
3. Зафиксируйте изменения (`git commit -m 'Add amazing feature'`)
4. Отправьте в branch (`git push origin feature/amazing-feature`)
5. Откройте Pull Request

## 📄 Лицензия

Этот проект является учебным и предназначен для образовательных целей.

## 👨‍💻 Автор

**Sologan Artemios** - [@Kwameldx666](https://github.com/Kwameldx666)

---

⭐ Поставьте звезду, если проект был полезен!

## 📞 Поддержка

Если у вас возникли вопросы или проблемы:

1. Проверьте [документацию](#-api-документация)
2. Ознакомьтесь с [устранением неполадок](#-устранение-неполадок)
3. Создайте [Issue](https://github.com/Kwameldx666/Lab2_Sologan_Artemios_Docker/issues)

---

<div align="center">
  <h3>🔧 Создано с помощью современных технологий</h3>
  
  ![Architecture](https://img.shields.io/badge/Architecture-Microservices-orange)
  ![Status](https://img.shields.io/badge/Status-Production%20Ready-brightgreen)
  ![Maintained](https://img.shields.io/badge/Maintained-Yes-green)
</div>