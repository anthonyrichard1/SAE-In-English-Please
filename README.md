
# SAE 2A Anglais

Ce projet vise à faciliter l'apprentissage de l'anglais dans le cadre d'études supérieures grâce à un site internet et une application mobile.

## Exécuter localement

Clonez le projet

```bash
  git clone https://codefirst.iut.uca.fr/git/antoine.jourdain/SAE_2A_Anglais.git
```

Allez dans le répertoire

```bash
  cd SAE_2A_Anglais
```

Suivez les différentes instructions suivant la partie que vous souhaitez lancer.

### EF et WebAPI

Bonjour cette partie a été réalisé par Patrick Brugière seul.

Le .sln se trouve dans le repertoir Project/EntityFramework 

Il est normalement précisé dans le nom de des tests à quelles parties ils appartiennent



### PHP

Changez de branche

```bash
  git switch php
```

Allez dans le répertoire php

```bash
  cd Project/php
```

Créez les fichiers composer

```bash
  php composer.phar install
  php composer.phar dump-autoload
```

Lancez votre serveur apache et n'oubliez pas d'exécuter  ```createdb.sql``` et ```defaultinsert.sql``` sur votre serveur SQL local avant d'utiliser le site.

### Blazor

Changez de branche

```bash
  git switch blazor
```

Choississez Project/adminBlazor.sln dans Visual Studio ou Rider.\
Modifiez la configuration et créez un "multi-launch" avec adminBlazor et adminBlazor.Api.\
Lancez le "multi-launch" et appréciez le site administratif.

## Documentation
### Diagramme de navigation de l'application Admin Blazor

![App Screenshot](https://cdn.discordapp.com/attachments/1150763562046861332/1198696860773265428/navigation.jpeg?ex=65bfd872&is=65ad6372&hm=44dcbc9e42872be5f68f30b452e9b43f1f5e28ec8af71e4fa8715380e5074290&)

## Auteurs

- [Patrick Brugière](https://codefirst.iut.uca.fr/git/patrick.brugiere)
- [Lucie Goigoux](https://codefirst.iut.uca.fr/git/lucie.goigoux2)
- [Antoine Jourdain](https://codefirst.iut.uca.fr/git/antoine.jourdain)
- [Anthony Richard](https://codefirst.iut.uca.fr/git/anthony.richard) (Au Canada depuis Décembre 2023)