'''plantuml

@startuml IEP

hide circle
allowmixing
skinparam classAttributeIconSize 9
skinparam classBackgroundColor #123123
skinparam classBorderColor #fff
skinparam classArrowColor #123123
skinparam classFontColor #white
skinparam classFontName arial
skinparam BackgroundColor #white

namespace Model #lightgrey{
    abstract Class AbsModel{
        - gtw : AbsGateway
        - role : string
        + connection() : void
        + deconnection() : void
    }

    abstract Class User {
        - id : int
        - password : string
        - email : string 
        - name : string
        - surname : string
        - nickname : string
        - image : string
        - extraTime : bool
        - group : int 

        + User(id : int, password : string, email : string, string name, string surname, string nickname, string image, bool extraTime, int group)
    }

    Class StudentModel {
        + action() : void
    }

    AbsModel *--> Gateway.AbsGateway
    AbsModel <|-- StudentModel

}


namespace Controller #lightgray{
    Class studentController {
        - attribut 
        + fct() : void
    }
}


namespace Config #lightgray{
    Class Connection {
        - stmt 
        + executeQuery(query : string, parameters : array) : bool
        + getResult() :  array
    }
}

namespace Gateway #lightgray{

    abstract Class AbsGateway {
        # con : Connection
        + {abstract} add(parameters: array) : int
        + {abstract} remove(id: int) : void
        + {abstract} findAll() : array
        + {abstract} findById(id: int)
    }

    class GroupGateway {
        + findByNum (num: string): array
        + modifyGroupById (id: int, num: int, year: int, sector: string): void
    }

    class TranslationGateway {
        - addWord(word: string): void
        + findByIdVoc(id: int): array
    }

    Class VocabularyListGateway {
        + findByName(name: string): array
        + modifVocabListById(id: int, name: string, img: string, aut: string): void
        + findByGroup(id: int): array  
    }

    Class UserGateway {
        - getRoles(id: int): array

        + findAllAdmins(): array
        + findAllTeachers(): array
        + findAllStudents(): array
        + findUserByEmail(email: string): User
        + findUserByName(name: string): array
        + findUserBySurname(surname: string): array
        + findUserByNickname(nickname: string): array
        + findUsersByGroup(id: int): array
        + modifyPassword(id: int, newPassword: string): void
        + modifyNickname(id: int, newNickname: string): void
        + modifyImage(id: int, newImage: string): void
        + modifyGroup(id: int, newGroup: int=Null): void
        + findUnassignedUsers(): array
    }

   
    AbsGateway <|-- TranslationGateway
    AbsGateway <|-- UserGateway
    AbsGateway <|-- VocabularyListGateway
    AbsGateway <|-- GroupGateway
}

@enduml
