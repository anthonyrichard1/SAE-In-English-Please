@startuml

card Group [
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
User --> Group

card Vocabulary [
    Vocabulary
    --
    <u>id
    name
    image
    ~#creator
]
Vocabulary --> User

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
Practice --> Vocabulary
Practice --> Group

card Be [
    Be
    --
    <u>#userID
    <u>#roleID
]
Be --> User
Be --> Role

@enduml