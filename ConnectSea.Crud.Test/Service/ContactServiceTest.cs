//using ConnectSea.Crud.Application;
//using ConnectSea.Crud.Domain.Command;
//using ConnectSea.Crud.Domain.Dto.Results;
//using ConnectSea.Crud.Domain.Entity;
//using ConnectSea.Crud.Domain.Enum;
//using ConnectSea.Crud.Domain.Exceptions;
//using ConnectSea.Crud.Domain.Repository;
//using Moq;
//using System.Linq.Expressions;

//namespace ConnectSea.Crud.Test.Service
//{
//    public class ContactServiceTest
//    {
//        private readonly Mock<IContactRepository> _repositoryMock;
//        private readonly ManifestoService _service;

//        public ContactServiceTest()
//        {
//            _repositoryMock = new Mock<IContactRepository>();
//            _service = new ContactService(_repositoryMock.Object);
//        }

//        private ManifestoCommand CreateValidCommand()
//            => new ManifestoCommand
//            {
//                Name = "Bruno",
//                BirthDate = DateTime.Today.AddYears(-20),
//                Sex = EscalaStatusEnum.Male
//            };

//        private ManifestoEditCommand CreateValidEditCommand()
//            => new ManifestoEditCommand
//            {
//                Name = "Carlos",
//                BirthDate = DateTime.Today.AddYears(-25),
//                Sex = EscalaStatusEnum.Male
//            };

//        #region CreateAsync Tests

//        [Fact]
//        public async Task Should_Create_Contact_When_Valid_Command()
//        {
//            var command = CreateValidCommand();

//            await _service.CreateAsync(command);

//            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Manifesto>()), Times.Once);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
//        }


//        [Fact]
//        public async Task Should_Throw_DomainException_When_Command_Has_Invalid_Name()
//        {
//            var command = CreateValidCommand();
//            command.Name = "";

//            await Assert.ThrowsAsync<DomainException>(() =>
//                _service.CreateAsync(command));

//            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Manifesto>()), Times.Never);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
//        }

//        [Fact]
//        public async Task Should_Throw_DomainException_When_Command_Has_Invalid_BirthDate()
//        {
//            var command = CreateValidCommand();
//            command.BirthDate = DateTime.Today.AddYears(-17);

//            await Assert.ThrowsAsync<DomainException>(() =>
//                _service.CreateAsync(command));

//            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Manifesto>()), Times.Never);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
//        }

//        [Fact]
//        public async Task Should_Throw_DomainException_When_Command_Has_Invalid_Sex()
//        {
//            var command = CreateValidCommand();
//            command.Sex = (EscalaStatusEnum)999;

//            await Assert.ThrowsAsync<DomainException>(() =>
//                _service.CreateAsync(command));

//            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Manifesto>()), Times.Never);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
//        }

//        #endregion

//        #region DeleteAsync Tests

//        [Fact]
//        public async Task Should_Delete_Contact_When_Exists()
//        {
//            var contact = new Manifesto(CreateValidCommand());

//            _repositoryMock.Setup(r => r.GetByIdAsync(1))
//                .ReturnsAsync(contact);

//            await _service.DeleteAsync(1);

//            _repositoryMock.Verify(r => r.Remove(contact), Times.Once);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
//        }

//        [Fact]
//        public async Task Should_Throw_NotFoundException_When_Delete_Contact_Not_Found()
//        {
//            _repositoryMock.Setup(r => r.GetByIdAsync(1))
//                .ReturnsAsync((Manifesto?)null);

//            await Assert.ThrowsAsync<NotFoundException>(() =>
//                _service.DeleteAsync(1));

//            _repositoryMock.Verify(r => r.Remove(It.IsAny<Manifesto>()), Times.Never);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
//        }

//        #endregion

//        #region UpdateAsync Tests

//        [Fact]
//        public async Task Should_Update_Contact_When_Exists_And_Valid_Command()
//        {
//            var contact = new Manifesto(CreateValidCommand());
//            var command = CreateValidEditCommand();

//            _repositoryMock.Setup(r => r.GetByIdAsync(1))
//                .ReturnsAsync(contact);

//            await _service.UpdateAsync(1, command);

//            _repositoryMock.Verify(r => r.Update(contact), Times.Once);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
//        }

//        [Fact]
//        public async Task Should_Throw_NotFoundException_When_Update_Contact_Not_Found()
//        {
//            var command = CreateValidEditCommand();

//            _repositoryMock.Setup(r => r.GetByIdAsync(1))
//                .ReturnsAsync((Manifesto?)null);

//            await Assert.ThrowsAsync<NotFoundException>(() =>
//                _service.UpdateAsync(1, command));

//            _repositoryMock.Verify(r => r.Update(It.IsAny<Manifesto>()), Times.Never);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
//        }



//        [Fact]
//        public async Task Should_Throw_DomainException_When_Update_With_Invalid_BirthDate()
//        {
//            var contact = new Manifesto(CreateValidCommand());
//            var command = new ManifestoEditCommand
//            {
//                BirthDate = DateTime.Today.AddYears(-17)
//            };

//            _repositoryMock.Setup(r => r.GetByIdAsync(1))
//                .ReturnsAsync(contact);

//            await Assert.ThrowsAsync<DomainException>(() =>
//                _service.UpdateAsync(1, command));

//            _repositoryMock.Verify(r => r.Update(It.IsAny<Manifesto>()), Times.Never);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
//        }

//        [Fact]
//        public async Task Should_Throw_DomainException_When_Update_With_Invalid_Sex()
//        {
//            var contact = new Manifesto(CreateValidCommand());
//            var command = new ManifestoEditCommand
//            {
//                Sex = (EscalaStatusEnum)999
//            };

//            _repositoryMock.Setup(r => r.GetByIdAsync(1))
//                .ReturnsAsync(contact);

//            await Assert.ThrowsAsync<DomainException>(() =>
//                _service.UpdateAsync(1, command));

//            _repositoryMock.Verify(r => r.Update(It.IsAny<Manifesto>()), Times.Never);
//            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
//        }

//        #endregion

//        #region GetAllAsync Tests

//        [Fact]
//        public async Task Should_Get_All_Active_Contacts_When_OnlyActivated_Is_True()
//        {
//            var contacts = new List<Manifesto>
//            {
//                new Manifesto(CreateValidCommand()),
//                new Manifesto(CreateValidCommand())
//            };

//            _repositoryMock.Setup(r => r.GetActiveAsync(true))
//                .ReturnsAsync(contacts);

//            var result = await _service.GetAllAsync(true);

//            Assert.Equal(2, result.Count());
//            _repositoryMock.Verify(r => r.GetActiveAsync(true), Times.Once);
//        }

//        [Fact]
//        public async Task Should_Get_All_Contacts_When_OnlyActivated_Is_False()
//        {
//            var contacts = new List<Manifesto>
//            {
//                new Manifesto(CreateValidCommand()),
//                new Manifesto(CreateValidCommand())
//            };

//            _repositoryMock.Setup(r => r.GetActiveAsync(false))
//                .ReturnsAsync(contacts);

//            var result = await _service.GetAllAsync(false);

//            Assert.Equal(2, result.Count());
//            _repositoryMock.Verify(r => r.GetActiveAsync(false), Times.Once);
//        }

//        #endregion

//        #region GetAllPagedAsync Tests

//        [Fact]
//        public async Task Should_Get_Paged_Contacts()
//        {
//            var contacts = new List<Manifesto>
//            {
//                new Manifesto(CreateValidCommand()),
//                new Manifesto(CreateValidCommand())
//            };

//            var pagedResult = new PagedResult<Manifesto>
//            {
//                Data = contacts,
//                TotalItems = 2,
//                Page = 1,
//                PageSize = 10
//            };

//            _repositoryMock.Setup(r => r.GetPagedAsync(1, 10, It.IsAny<Expression<Func<Manifesto, object>>>()))
//                .ReturnsAsync(pagedResult);

//            var result = await _service.GetAllPagedAsync(1, 10);

//            Assert.Equal(2, result.Data.Count());
//            Assert.Equal(2, result.TotalItems);
//            Assert.Equal(1, result.Page);
//            Assert.Equal(10, result.PageSize);
//            _repositoryMock.Verify(r => r.GetPagedAsync(1, 10, It.IsAny<Expression<Func<Manifesto, object>>>()), Times.Once);
//        }

//        #endregion

//        #region GetByIdAsync Tests

//        [Fact]
//        public async Task Should_Get_Contact_By_Id_When_Exists()
//        {
//            var contact = new Manifesto(CreateValidCommand());

//            _repositoryMock.Setup(r => r.GetByIdAsync(1))
//                .ReturnsAsync(contact);

//            var result = await _service.GetByIdAsync(1);

//            Assert.NotNull(result);
//            Assert.Equal(contact, result);
//            _repositoryMock.Verify(r => r.GetByIdAsync(1), Times.Once);
//        }

//        [Fact]
//        public async Task Should_Return_Null_When_Contact_Not_Found()
//        {
//            _repositoryMock.Setup(r => r.GetByIdAsync(1))
//                .ReturnsAsync((Manifesto?)null);

//            var result = await _service.GetByIdAsync(1);

//            Assert.Null(result);
//            _repositoryMock.Verify(r => r.GetByIdAsync(1), Times.Once);
//        }

//        #endregion
//    }
//}