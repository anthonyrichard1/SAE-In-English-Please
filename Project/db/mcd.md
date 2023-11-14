```plantuml
@startuml

skinparam cardAttributeIconSize 9
skinparam cardBackgroundColor #009900
skinparam cardBorderColor #black
skinparam ArrowColor #00331f
skinparam cardFontColor #black
skinparam cardFontName arial
skinparam BackgroundColor #lightgrey
skinparam usecaseBackgroundColor #80ff80

card User [
    User
    --
    <u>id
    password
    email
    name
    surname
    nickname
    image
    extratime
]

card VocabularyList [
    VocabularyList
    --
    <u>id
    name
    image
]

card Vocabulary [
    Vocabulary
    --
    <u>word
]

card Language [
    Language
    --
    <u>name
]

card Group [
    Group
    --
    <u>id
    num
    year
    sector
]

card Role [
    Role
    --
    <u>id
    name
]

usecase Create

User "0,n " -- Create 
Create -- "1,1    " VocabularyList

usecase Practice

Group "0,n " -- Practice
Practice -r-- "0,n" VocabularyList

usecase Belong
User "0,1" -- Belong
Belong -- "0,n" Group

usecase Have

User "0,n" -- Have
Have -- "0,n " Role

usecase Register
Vocabulary "1,n" -- Register 
Register - "0,n" Language

usecase Translate

Translate - "0,n" Vocabulary
Vocabulary - "0,n" Translate
Translate --- "0,n" VocabularyList
@enduml