```plantuml
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
        - role : string
        + connection(login: string, password: string) : void
        + deconnection()
        + {abstract} is()
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
        - roles : array

        + User(id : int, password : string, email : string, string name, string surname, string nickname, string image, bool extraTime, int group)
    }

    Class MdlAdmin{
        + getAllUsers() : array
        + getAllAdmins() : array
        + getAllTeachers() : array
        + getAllStudents() : array
        + getAllGroups() : array
        + removeUser(id: int) : void
        + getUsersOfGroup(id: int) : array
        + removeUserFromGroup(id: int) : void
        + removeGroup(id: int) : void
        + addGroup(num: int, year: int, sector: string) : int
        + addUserToGroup(user: int, group: int) : void
        + getUnassignedUsers(): array
    }

    Class MdlStudent{
        + getAll() : array
        + getVocabByNale(name: string) : array
        + getUser(id: int) : User
        + modifyNickname(id: int, newNickname: string) : void
        + modifyPassword(id: int, newPassword: string) : void
    }

    Class MdlTeacher{
        + getAll() : array
        + getAllStudent() : array
        + getVocabByName(name: string) : array
        + RemoveVocById(id: int) : void
    }

    Class Translation{
        - id : int
        - word1 : string
        - word2 : string
        - listVocab : int

        + Translation(id : int, word1 : string, word2 : string, listVocab : int)
    }

    Class Group{
        - id : int
        - num : int
        - year : int
        - sector : string

        + Group(id : int, num : int, year : int, sector : string)
    }

    Class VocabularyList{
        - id : int
        - name : string
        - image : string
        - aut : string

        + VocabularyList(id : int, name : string, image : string, aut : string)
    }

    AbsModel *-> Gateway.AbsGateway
    AbsModel <|-- MdlStudent
    AbsModel <|-- MdlAdmin
    AbsModel <|-- MdlTeacher

}


namespace Controller #lightgray{
    Class AdminController{
        + showAllUsers() : void
        + showAllAdmins() : void
        + showAllTeachers() : void
        + showAllStudents() : void
        + showAllGroups() : void
        + removeUser() : void
        + showGroupDetails() : void
        + removeUserFromGroup() : void
        + removeGroup() : void
        + addGroup() : void
        + addUserToGroup() : void
    }

    Class StudentController{
        + affAllVocab() : void
        + affAllStudent() : void
        + getByName() : void
        + showAccountInfos() : void
        + modifyNickname() : void
        + modifyPassword() : void
    }

    Class TeacherController{
        + affAllStudent() : void
        + affAllVocab() : void
        + getByName() : void
        + DelById() : void
    }

    Model.MdlTeacher <-- TeacherController
    Model.MdlStudent <-- StudentController
    Model.MdlAdmin <-- AdminController
}


namespace Config #lightgray{
    Class Connection {
        - stmt 
        + executeQuery(query : string, parameters : array) : bool
        + getResult() : array
    }

    Class Validation{
        + {static} val_action(action) : string
        + {static} val_password(value) : string
        + {static} filter_int(value) : int
        + {static} filter_str_simple(value) : string
        + {static} filter_str_nospecialchar(value) : string
    }

    Connection *--> Gateway.AbsGateway

    Validation <-- Controller.AdminController
    Validation <-- Controller.StudentController
    Validation <-- Controller.TeacherController
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
