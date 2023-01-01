using System;
namespace MyMinimalApi.Tests
{
	//This is for replacing "PeopleService"(Depenedency Injection) in MyMiniApi
	public class TestPeopleService:IPeopleService
	{
		public string Create(Person person) => "It works!";
	}
}

