// See https://aka.ms/new-console-template for more information
using DTO;
using System.Net.Http.Json;

Console.WriteLine("Hello, World!");


HttpClient client = new HttpClient()
{
    BaseAddress = new Uri("https://localhost:7013/api/v1/")
};

Console.WriteLine("test Groups");
var GetGroups = await client.GetAsync("Group");
Console.WriteLine("rep : " + GetGroups.StatusCode);
Console.WriteLine("test get Groups" + await GetGroups.Content.ReadAsStringAsync());

var getGroup = await client.GetAsync("Group/1");
Console.WriteLine("rep : " + getGroup.StatusCode);
Console.WriteLine("test get Group" + await getGroup.Content.ReadAsStringAsync());

var addGroup = await client.PostAsJsonAsync("Group", new GroupDTO{ Id=2, Num = 1, sector = "sector1", Year = 2024 });
Console.WriteLine("rep : " + addGroup.StatusCode);
Console.WriteLine("test add Group" + await addGroup.Content.ReadAsStringAsync());

var updateGroup = await client.PutAsJsonAsync("Group", new GroupDTO{Id=2, Num = 1, sector = "sector1", Year = 2024 });
Console.WriteLine("rep : " + updateGroup.StatusCode);
Console.WriteLine("test update Group" + await updateGroup.Content.ReadAsStringAsync());

var deleteGroup = await client.DeleteAsync("Group/2");
Console.WriteLine("rep : " + deleteGroup.StatusCode);
Console.WriteLine("test delete Group" + await deleteGroup.Content.ReadAsStringAsync());

Console.WriteLine("test Translates");
var GetTranslates = await client.GetAsync("Translate");
Console.WriteLine("rep : " + GetTranslates.StatusCode);
Console.WriteLine("test get Translates" + await GetTranslates.Content.ReadAsStringAsync());

var getTranslate = await client.GetAsync("Translate/1");
Console.WriteLine("rep : " + getTranslate.StatusCode);
Console.WriteLine("test get Translate" + await getTranslate.Content.ReadAsStringAsync());

var addTranslate = await client.PostAsJsonAsync("Translate", new  TranslateDTO{ WordsId = "Bonjour", VocabularyListVocId = 1 });
Console.WriteLine("rep : " + addTranslate.StatusCode);
Console.WriteLine("test add Translate" + await addTranslate.Content.ReadAsStringAsync());

var updateTranslate = await client.PutAsJsonAsync("Translate/1", new TranslateDTO{ WordsId = "Bonjour", VocabularyListVocId = 1 });
Console.WriteLine("rep : " + updateTranslate.StatusCode);
Console.WriteLine("test update Translate" + await updateTranslate.Content.ReadAsStringAsync());

var deleteTranslate = await client.DeleteAsync("Translate/1");
Console.WriteLine("rep : " + deleteTranslate.StatusCode);
Console.WriteLine("test delete Translate" + await deleteTranslate.Content.ReadAsStringAsync());

Console.WriteLine("test VocabularyLists");

var GetVocabularyLists = await client.GetAsync("VocabularyList");
Console.WriteLine("rep : " + GetVocabularyLists.StatusCode);
Console.WriteLine("test get VocabularyLists" + await GetVocabularyLists.Content.ReadAsStringAsync());

var getVocabularyList = await client.GetAsync("VocabularyList/1");
Console.WriteLine("rep : " + getVocabularyList.StatusCode);
Console.WriteLine("test get VocabularyList" + await getVocabularyList.Content.ReadAsStringAsync());

var addVocabularyList = await client.PostAsJsonAsync("VocabularyList", new VocabularyListDTO{ Id=2, Image="img", Name="name" });
Console.WriteLine("rep : " + addVocabularyList.StatusCode);
Console.WriteLine("test add VocabularyList" + await addVocabularyList.Content.ReadAsStringAsync());

var updateVocabularyList = await client.PutAsJsonAsync("VocabularyList", new VocabularyListDTO { Id = 2, Image = "img2", Name = "name2" });
Console.WriteLine("rep : " + updateVocabularyList.StatusCode);
Console.WriteLine("test update VocabularyList" + await updateVocabularyList.Content.ReadAsStringAsync());

var deleteVocabularyList = await client.DeleteAsync("VocabularyList/2");
Console.WriteLine("rep : " + deleteVocabularyList.StatusCode);
Console.WriteLine("test delete VocabularyList" + await deleteVocabularyList.Content.ReadAsStringAsync());

Console.WriteLine("test Vocabularys");
var GetVocabularys = await client.GetAsync("Vocabulary");
Console.WriteLine("rep : " + GetVocabularys.StatusCode);
Console.WriteLine("test get Vocabularys" + await GetVocabularys.Content.ReadAsStringAsync());

var getVocabulary = await client.GetAsync("Vocabulary/1");
Console.WriteLine("rep : " + getVocabulary.StatusCode);
Console.WriteLine("test get Vocabulary" + await getVocabulary.Content.ReadAsStringAsync());

var addVocabulary = await client.PostAsJsonAsync("Vocabulary", new VocabularyDTO{ word = "Test", LangueName = "French" });
Console.WriteLine("rep : " + addVocabulary.StatusCode);
Console.WriteLine("test add Vocabulary" + await addVocabulary.Content.ReadAsStringAsync());

var updateVocabulary = await client.PutAsJsonAsync("Vocabulary", new { word = "Test", LangueName = "French" });
Console.WriteLine("rep : " + updateVocabulary.StatusCode);
Console.WriteLine("test update Vocabulary" + await updateVocabulary.Content.ReadAsStringAsync());

var deleteVocabulary = await client.DeleteAsync("Vocabulary/Test");
Console.WriteLine("rep : " + deleteVocabulary.StatusCode);
Console.WriteLine("test delete Vocabulary" + await deleteVocabulary.Content.ReadAsStringAsync());

Console.WriteLine("test Langues");

var GetLangues = await client.GetAsync("Langue");
Console.WriteLine("rep : " + GetLangues.StatusCode);
Console.WriteLine("test get Langues" + await GetLangues.Content.ReadAsStringAsync());

var getLangue = await client.GetAsync("Langue/1");
Console.WriteLine("rep : " + getLangue.StatusCode);
Console.WriteLine("test get Langue" + await getLangue.Content.ReadAsStringAsync());

var addLangue = await client.PostAsJsonAsync("Langue", new LangueDTO{ name = "Test" });
Console.WriteLine("rep : " + addLangue.StatusCode);
Console.WriteLine("test add Langue" + await addLangue.Content.ReadAsStringAsync());

var deleteLangue = await client.DeleteAsync("Langue/Test");
Console.WriteLine("rep : " + deleteLangue.StatusCode);
Console.WriteLine("test delete Langue" + await deleteLangue.Content.ReadAsStringAsync());

Console.WriteLine("test Users");

var GetUsers = await client.GetAsync("User");
Console.WriteLine("rep : " + GetUsers.StatusCode);
Console.WriteLine("test get Users" + await GetUsers.Content.ReadAsStringAsync());

var getUser = await client.GetAsync("User/1");
Console.WriteLine("rep : " + getUser.StatusCode);
Console.WriteLine("test get User" + await getUser.Content.ReadAsStringAsync());

var addUser = await client.PostAsJsonAsync("User", new { email = "" });



