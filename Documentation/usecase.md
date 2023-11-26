```plantuml

@startuml

left to right direction

skinparam usecase {
BackgroundColor lightGreen
BorderColor DarkSlateGray

ArrowColor darkgreen
}

actor User as User
actor Admin as Admin
actor Teacher as Teacher
actor Student as Student
actor Visitor as Visitor

User <|--- Admin
User <|---- Teacher
User <|-- Student
Visitor <|- User

note left of (User)
  The user must
  be connected
end note


package App {
 
  usecase "Add a group" as ES1.1
  usecase "Delete a group" as ES1.2
  usecase "Import students automatically \n from an Excel doc" as ES1.3
  usecase "Show the groups" as ES1.4
  usecase "Delete a user" as ES1.5
  usecase "Show the users list" as ES1.6
  usecase "Give a role" as ES1.7
  usecase "Add a student in a group" as ES1.9
  usecase "Delete a student in a group" as ES1.10
  usecase "Ban a user" as ES1.11
  usecase "Choose if a quiz is \n accessible only to a particular group \n or open to all, to each group" as ES1.13
  usecase "Share my quiz with other teachers" as ES1.14
  usecase "Listen to the words to also \n work my listening comprehension" as ES1.15



  usecase "Create an interactive quiz during a course" as ES2.1
  usecase "Know my overall progress since I installed the app" as ES2.4
  usecase "Consult the translation and the meaning \n of certain words in an online dictionary" as ES2.5
  usecase "Create my own flash card to train myself" as ES2.7
  usecase "Know my progress on a quiz" as ES2.8
  usecase "View student results who \n participate in my quizzes at all moment" as ES2.9

  usecase "Create a quiz for students training" as ES3.1
  usecase "Download quizzes to do them \n later without an internet connection" as ES3.3
  usecase "Join a quizz with a code" as ES3.4
  usecase "Have access to the vocabulary \n list with a link" as ES3.6
  
  usecase "Evaluate students from anywhere" as ES4.1
  usecase "Receive an email to notify \n me when I’m about to have an exam " as ES4.2
  usecase "Change the level of my \n trainings games/quizzes" as ES4.3
  usecase "Choose if I want to work \n from English to French or vice \nversa in the tests" as ES4.4
  usecase "Choose a strict difficulty mode (0 error) \n or tolerant (1 or 2 errors) for my exams" as ES4.5

  usecase "Easily switch from dark \n theme to theme clear and vice versa \n when I’m on the application (web or mobile)" as ES5.1
  usecase "Change the speed of scrolling \n flashcard when I use scroll mode automatic" as ES5.3
  usecase "Change my password" as ES5.6
  usecase "Receive a message encouraging the end \n of my test to motivate me to continue" as ES5.8
  usecase "Show my rank on quizzes" as ES5.10


  usecase "Play a game in a demo to test the app" as ES6.1
  usecase "Play a game" as ES6.2
  usecase "Choose a game" as ES6.3
  usecase "Choose the vocabulary list" as ES6.4  
  usecase "Give feedback after a quiz" as ES6.5
  usecase "Sign in" as ES6.6
  usecase "List quizzes/Vocabulary" as ES6.7
  usecase "Delete a quiz" as ES6.8
  usecase "Change nickname" as ES6.9
}

Admin --> ES1.1

Admin --> ES1.3
Admin --> ES1.4
Admin ----> ES1.6
Student --> ES1.15

Teacher -> ES2.1
Student --> ES2.4
Student --> ES2.5
Student --> ES2.7

ES6.2 <.. ES2.8 : include


Student --> ES3.3
Student --> ES3.4

ES3.1 ..> ES3.6 : extends
ES2.1 ..> ES3.6 : extends

Teacher ---> ES4.1
Student --> ES4.2

ES4.1 ..> ES4.5 : include
ES3.1 ..> ES1.13 : include

ES3.1 ..> ES1.14 : extends

Teacher --> ES3.1

ES6.3 ..> ES4.3 : extends
ES6.3 ..> ES4.4 : include
ES4.1 ..> ES2.9 : extends

Visitor --> ES5.1
User --> ES5.3
User --> ES5.6

ES3.4 <.. ES5.10 : include
ES6.2 <.. ES5.8 : include

Visitor --> ES6.1
Student --> ES6.2
Visitor --> ES6.6
Teacher --> ES6.7
User --> ES6.9

ES6.2 ..> ES6.3 : include
ES6.3 ..> ES6.4 : include

ES6.2 <.. ES6.5 : include

ES6.7 ..> ES6.8 : extends

ES1.6 ..> ES1.7 : extends
ES1.6 ..> ES1.5 : extends
ES1.6 ..> ES1.11 : extends

ES1.4 ..> ES1.2 : extends
ES1.4 ..> ES1.9 : extends
ES1.4 ..> ES1.10 : extends

ES1.6 ..> ES1.9 : extends



@enduml