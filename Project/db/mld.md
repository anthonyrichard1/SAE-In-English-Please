```plantuml
@startuml

skinparam cardAttributeIconSize 9
skinparam cardBackgroundColor #009900
skinparam cardBorderColor #black
skinparam ArrowColor #00331f
skinparam cardFontColor #black
skinparam cardFontName arial
skinparam BackgroundColor #lightgrey

card Group  [
    Group
    --
    <u>id
    num
    year
    sector
]

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
    ~#groupID
]

card VocabularyList [
    VocabularyList
    --
    <u>id
    name
    image
    ~#userID
]

card Translate [
    Translate
    --
    <u>id
    ~#firstWordID
    ~#secondWordID
    ~#listVoc
]

card Vocabulary [
    Vocabulary
    --
    <u>id
    word
]

card Language [
    Language
    --
    <u>name
]

card Register [
    Register
    --
    <u>#language
    <u>#idWord
]

card Role [
    Role
    --
    <u>id
    name
]
card Practice [
    Practice
    --
    <u>#vocabID
    <u>#groupID
]


card Be [
    Be
    --
    <u>#userID
    <u>#roleID
]


User --> Group
Translate --> VocabularyList
Vocabulary <-- Translate
Vocabulary <-- Translate
Language <-r- Register
Register --> Vocabulary
Practice -> VocabularyList
Practice -> Group
Be --> User
Role <-l- Be
VocabularyList -> User

@enduml
