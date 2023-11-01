```plantuml
@startuml
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

card Vocabulary [
    Vocabulary
    --
    <u>id
    name
    image
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

User "0,n" -- Create 
Create -- "1,1" Vocabulary

usecase Practice

Group "0,n" -- Practice
Practice -- "1,n" Vocabulary

usecase Belong

User "1,1" -- Belong
Belong -- "1,n" Group

usecase Be

User "1,n" -- Be
Be -- "1,1" Role
@enduml
