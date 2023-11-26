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

namespace Model #lightgrey {
    Class VocabularyList {
        - id : int
        - name : string
        - image : string
        - aut : int

        + VocabularyList(id : int, name : string, image : string, aut : sint)
        + getId() : int
        + getName() : string
        + getImage() : string
        + getAut() : int
    }

    Class User {
        - id : int
        - password : string
        - email : string
        - name : string
        - surname : string
        - nickname : string
        - image : string
        - extraTime : bool
        - roles : array
        - group : int

        + User(id : int, password : string, email : string, name : string, surname : string, nickname : string, image : string, extratime : bool, roles : array, group : int)
        + getId() : int
        + getPassword() : string
        + getEmail() : string
        + getName() : string
        + getSurname() : string
        + getNickname() : string
        + getImage() : string
        + isExtratime() : bool
        + getRoles() : array
        + getGroup() : int
    }

    Class Translation {
        - id : int
        - word1 : string
        - word2 : string
        - listVocab : int

        + Translation(id : int, word1 : string, word2 : string, listVocab : int)
        + getId() : int
        + getWord1() : string
        + getWord2() : string
        + getListVocab() : int
    }

    Class Group {
        - id : string
        - num : int
        - year : int
        - sector : string

        + Group(id : int, num : int, year : int, sector : string)
        + getId() : int
        + getNum() : int
        + getYear() : int
        + getSector() : string
    }

    Abstract Class AbsModel {
        + connection(login : string, password : string) : void
        + deconnection() : void
        + checkLoginExist(login : string)
        + abstract is(login : string, roles : array) : User
    }

    Class MdlAdmin {
        + getAllUsers() : array
        + getAllAdmins(): array 
        + getAllTeachers() : array
        + getAllGroups() : array 
        + getUnassignedUsers() : array
        + getUsersOfGroup(id : int) : array
        + removeUser(id : int) : void
        + addUserToGroup(user : int, group : int) : void
        + removeUserFromGroup(id : int) : void
        + addGroup(num : int, year : int, sector : string) : int
        + removeGroup(id : int) : void
        + is(login : string, roles : array) : User
    }

    Class MdlStudent {
        + getAll() : array
        + getVocabByName(name : string) : array
        + {abstract} is(login : string, roles : array) : User
    }

    Class MdlTeacher {
        + getAll() : array
        + getAllGroups() : array
        + getAllStudent() : array
        + getVocabByName(name : string) : array
        + findByUser(id : int) : array
        + findGroupVocab(vocab : int) : array
        + findGroupNoVocab(vocab : int) : array
        + findByIdVoc(id : int) : array
        + addVocabToGroup(vocabID : int, groupID : int) : void
        + removeVocabFromGroup(vocabID : int, groupID : int) : void
        + addVocabList(userID : int, name : string, image : string, words : array) : void
        + removeVocById(id : int) : void
        + is(login : string, roles : array) : User
    }

    Class MdlUser {
        + getAll() : array
        + modifyNickname(id : int, newNickname : string) : void
        + ModifyPassword(id : int, newPassword : string) : void
        + getUserById(id : int) : User
        + is(login : string, roles : array) : User
    }

    MdlAdmin --|> MdlUser
    MdlStudent --|> MdlUser
    MdlTeacher --|> MdlUser
    MdlUser --|> AbsModel

    MdlAdmin --|> Gateway.GroupGateway
    MdlAdmin --|> Gateway.UserGateway

    MdlStudent --|> Gateway.UserGateway
    MdlStudent --|> Gateway.VocabularyGateway
    MdlStudent --|> Gateway.VocabularyListGateway

    MdlTeacher --|> Gateway.UserGateway
    MdlTeacher --|> Gateway.GroupGateway
    MdlTeacher --|> Gateway.Translation
    MdlTeacher --|> Gateway.VocabularyGateway
    MdlTeacher --|> Gateway.VocabularyListGateway
}

namespace Gateway #lightgrey {
    abstract Class AbsGateway {
        # con : Connection

        + AbsGateway()
        + {abstract} add(parameters: array) : int
        + {abstract} remove(id: int) : void
        + {abstract} findAll() : array
        + {abstract} findById(id: int)
    }

    Class UserGateway {
        - getRoles(id : int) : array
        + UserGateway()
        + add(parameters: array) : int
        + remove(id: int) : void
        + findAll() : array
        + findById(id: int) : User
        + findAllAdmins() : array
        + findAllTeachers() : array
        + findAllStudents() : array
        + findUserByEmail() : User
        + findUserByName(name : string) : array
        + findUserBySurname(surname : string) : array
        + findUserByNickname(nickname : string) : array
        + findUsersByGroup(id : int) : array
        + findUnassignedUsers() : array
        + login(login : string) : string
        + modifyPassword(id : int, newPassword : string) : void
        + modifyNickname(id : int, nickname : string) : void
        + modifyImage(id : int, image : string) : void
        + modifyGroup(id : int, newGroup : int) : void
        
    }

    class GroupGateway {
        + GroupGateway()
        + add(parameters: array) : int
        + remove(id: int) : void
        + findAll() : array
        + findById(id: int) : Group
        + findByNum (num: string): array
        + findGroupVocab(vocab : int) : array
        + findGroupNoVocab(vocab : int) : array
        + addVocabToGroup(vocab : int, group : int) : void
        + removeVocabFromGroup(vocab : int, group : int) : void
        + modifyGroupById (id: int, num: int, year: int, sector: string): void
        
    }

    class TranslationGateway {
        - addWord(word: string): void
        + TranslationGateway()
        + add(parameters: array) : int
        + remove(id: int) : void
        + findAll() : array
        + findById(id: int) : Translation
        + findByIdVoc(id: int): array
    }

    Class VocabularyListGateway {
        + VocabularyListGateway()
        + add(parameters: array) : int
        + remove(id: int) : void
        + findAll() : array
        + findById(id: int) : VocabularyList
        + findByName(name : string) : array
        + findByGroup(id : int) : array
        + findByUser(id : int) : array
        + findByName(name: string): array
        + findByGroup(id: int): array  
        + modifVocabListById(id : int, name : string, img : string, aut : string) : void
    }    

    UserGateway ..|> AbsGateway
    GroupGateway ..|> AbsGateway
    TranslationGateway ..|> AbsGateway
    VocabularyListGateway ..|> AbsGateway
    AbsGateway *-- Config.Connection
    UserGateway .> Model.User
    GroupGateway .> Model.Group
    TranslationGateway .> Model.Translation
    VocabularyListGateway .> Model.VocabularyList
}

namespace Controller #lightgrey {
    class VisitorController {
        + login() : void
        + confirmLogin() : void
        + disconnect() : void
        + checkLoginExist(login : string) : bool
        + memory(match : array) : void
        + quiz(match : array) : void
        + resultatsJeux(match : string) : void
    }

    class UserController {
        + showAccountInfos() : void
        + modifyPassword() : void
        + modifyNickname() : void
        + {static} home() : void
    }

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
        + ListVocChoice() : void
        + gameChoice() : void
    }

    Class TeacherController{
        + affAllStudent() : void
        + affAllVocab() : void
        + getByName() : void
        + DelById() : void
        + getContent() : void
        + addVocabToGroup() : void
        + removeVocabFromGroup() : void
        + showVocabListForm() : void
        + addVocabList() : void
    }

    Class FrontController {
        + FrontController()
    }

    AdminController --|> UserController
    TeacherController --|> UserController
    StudentController --|> UserController
    UserController --|> VisitorController
    FrontController ..> VisitorController
    FrontController ..> UserController
    FrontController ..> Config.Validation
    FrontController ..> Model.MdlUser
    
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
}

@enduml