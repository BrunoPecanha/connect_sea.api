//using ConnectSea.Crud.Application.Mappers;
//using ConnectSea.Crud.Domain.Command;
//using ConnectSea.Crud.Domain.Entity;
//using ConnectSea.Crud.Domain.Enum;

//namespace ConnectSea.Crud.Test.Entity
//{
//    public class ContactTest
//    {
//        private ManifestoCommand CreateValidCommand()
//            => new ManifestoCommand
//            {
//                Name = "Bruno",
//                BirthDate = DateTime.Today.AddYears(-20),
//                Sex = EscalaStatusEnum.Male
//            };

//        [Fact]
//        public void Should_Create_Contact_When_Data_Is_Valid()
//        {
//            var command = CreateValidCommand();

//            var contact = new Manifesto(command);

//            Assert.NotNull(contact);
//            Assert.Equal("Bruno", contact.Name);
//            Assert.True(contact.IsActive);
//        }     

//        [Fact]
//        public void Should_Update_Contact_When_Data_Is_Valid()
//        {
//            var contact = new Manifesto(CreateValidCommand());

//            var updateCommand = new ManifestoEditCommand
//            {
//                Name = "Carlos",
//                BirthDate = DateTime.Today.AddYears(-25),
//                Sex = EscalaStatusEnum.Male
//            };

//            contact.Update(updateCommand);

//            Assert.Equal("Carlos", contact.Name);
//        }

//        [Fact]
//        public void Should_Deactivate_Contact()
//        {
//            var contact = ContactMapper.ToEntity(CreateValidCommand());

//            contact.Deactivate();

//            Assert.False(contact.IsActive);
//        }

//        [Fact]
//        public void Should_Calculate_Age_Correctly()
//        {
//            var command = new ManifestoCommand
//            {
//                Name = "Bruno",
//                BirthDate = DateTime.Today.AddYears(-30),
//                Sex = EscalaStatusEnum.Male
//            };

//            var contact = new Manifesto(command);

//            Assert.True(contact.Age >= 29);
//        }
//    }
//}