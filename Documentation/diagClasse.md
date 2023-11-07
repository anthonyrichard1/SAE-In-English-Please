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
        - con : Connection
        + {abstract} add() : void
        + {abstract} remove() : void
    }

    Class studentGateway {
        + findVocabulary() : string
    }

    Class adminGateway {
        + findStudent(): User
    }

    class teacherGateway {
        + findGroup() : Group
    }

    class groupGateway {
        + fct(): void
    }

   
    AbsGateway <|-- studentGateway
    AbsGateway <|-- teacherGateway
    AbsGateway <|-- adminGateway
    AbsGateway <|-- groupGateway
}

@enduml
