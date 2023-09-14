# GitHub

[**Установка**](#установка) | [**Настройка**](#настройка) | [**Использование**](#использование)

---

**GitHub Desktop**:
GitHub Desktop - это графический интерфейс для Git, который облегчает работу с репозиториями на GitHub. Основные особенности включают в себя:
- Простой и понятный пользовательский интерфейс, удобный для начинающих пользователей.
- Возможность клонировать, создавать, фиксировать изменения и пушить их в удаленный репозиторий на GitHub.
- Встроенные инструменты для решения конфликтов слияния (merge conflicts) при работе в команде.
- Отображение истории коммитов и возможность перехода к различным версиям кода.
- Интеграция с GitHub Actions для автоматизации сборки и развертывания проектов.

**GitHub CLI (GitHub Bash)**:
GitHub CLI - это командная строка для GitHub, которая позволяет управлять репозиториями и выполнять различные действия на GitHub из терминала. Особенности включают:
- Мощные команды для управления репозиториями, задачами, Pull Request и многими другими аспектами GitHub.
- Возможность выполнения автоматизированных задач и скриптов с использованием GitHub API.
- Поддержка интерактивных режимов и возможность работы с GitHub Enterprise Server.
- Интеграция с Git, что позволяет легко комбинировать Git-команды с командами GitHub.

**GitHub для Unity 2D**:
GitHub может быть полезным инструментом для управления версиями и совместной разработки в проектах Unity 2D. Основные причины использования GitHub в таких проектах включают:
- **Версионирование**: GitHub позволяет отслеживать изменения в проекте, создавать ветки для разработки новых функций и возвращаться к предыдущим версиям при необходимости. Это особенно полезно для управления версиями игры и предотвращения потери кода.
- **Совместная разработка**: Команды разработчиков могут работать над проектом одновременно, создавать и отслеживать задачи с помощью GitHub Issues, а также совместно решать проблемы и разрабатывать новые функции.
- **Интеграция с Unity**: Существуют плагины и инструменты, которые облегчают интеграцию GitHub с Unity, что упрощает работу с проектами Unity 2D.

Использование GitHub Desktop, GitHub CLI и GitHub в комбинации с Unity 2D позволяет разработчикам более эффективно управлять версиями своего проекта, сотрудничать с командой и следить за изменениями в коде, что особенно важно в разработке игр на Unity.

## Установка
* Скачайте и установите [**GitHub Desktop**](https://desktop.github.com/)
* Скачайте и установите [**GitHub CLI**](https://cli.github.com/)
* Зарегестрируйте аккаунт на [**GitHub**](https://github.com/signup?source=login)
* При открытии программы **GitHub Desktop** впервые, необходимо будет ввести свои данные(логин, пароль)

## Настройка

* Склонируйте репозиторий к себе на ПК:

1. Откройте **ExoRex** в [**GitHub**](https://github.com/Nickiduzo/ExoRex) и скопируйте ссылку:
![Link](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/link.png)
2. Откройте стрелку в интерфейсе слева:
![Arrow](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/arrow.png)
3. Выберите пункт клонировать репозиторий:
![Clone](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/clone.png)
4. Вводим ссылку которую скопировали ранее:
![Link](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/paste.link.png)
5. Перейдите в ветку, название которой совпадает с вашем именем либо название которой вам предоставил *ТЛ*:
![Branch](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/pick.png)

После установки, необходимо удостовериться что вся установка произошла успешно и вы имеете право на внесение измений в проект.

Для этого необходимо сделать:
1. Откройте папку с вашим проектом:
![Openfolder](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/project.png)
2. Откройте GitBash в папке с проектом, используя ПКМ:
![Bash](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/bash.png)
3. Вводим команду *git branch* для того, что бы узнать собственную ветку:
![Bran](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/branch.png)
4. Вводим команду *git config* для того, что бы узнать собственный никнейм:
![User](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/user.png)

На этом первоначальную настройку приложений *Git* завершено.


# Использование

Прежде чем начинать работать над проектом необходимо проверить собственную ветку на актуальность.

* Откройте приложение *GitHub Desktop* и выберите пункт "Current branch":
![Current](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/pick.png)
* Нажмите на кнопку снизу "Choose a branch to merge.."
![Merge](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/merge.png)
* Важно делать *merge* в свою ветку из *main* ветки.
![Master](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/master.png)

* Если долгое время не делать *merge* в свою ветку с *main* ветки могут возникнуть проблемы и через приложение **GitHub Desktop** *merge* может не сработать.

В таких случаях необходимо сделать *merge* с помощью *GitBash*, используя комманду *git merge main*:
![GitBashMerge](https://github.com/Nickiduzo/ExoRex/blob/main/Insctruction/IImages/gitmergemaster.png)
