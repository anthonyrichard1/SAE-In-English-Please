
# SAE 2A Anglais

This project aims to facilitate the learning of English in the context of higher studies thanks to a website and a mobile application.
## Run Locally

Clone the project

```bash
  git clone https://codefirst.iut.uca.fr/git/antoine.jourdain/SAE_2A_Anglais.git
```

Go to the project directory

```bash
  cd SAE_2A_Anglais
```

Follow the following instructions according to your need.

### PHP

Switch branch

```bash
  git switch php
```

Go to the php directory

```bash
  cd Project/php
```

Create composer files

```bash
  php composer.phar install
  php composer.phar dump-autoload
```

Launch your apache server and don't forget to execute ```createdb.sql``` and ```defaultinsert.sql``` on your Local SQL Server before using the site.

### Blazor

Switch branch

```bash
  git switch blazor
```

Choose Project/adminBlazor.sln in Visual Studio or Rider.\
Edit configuration and create a multi-launch with adminBlazor and adminBlazor.Api.\
Launch it and enjoy the admin app.

## Authors

- [Anthony Richard](https://codefirst.iut.uca.fr/git/anthony.richard)
- [Patrick Brugière](https://codefirst.iut.uca.fr/git/patrick.brugiere)
- [Lucie Goigoux](https://codefirst.iut.uca.fr/git/lucie.goigoux2)
- [Antoine Jourdain](https://codefirst.iut.uca.fr/git/antoine.jourdain)