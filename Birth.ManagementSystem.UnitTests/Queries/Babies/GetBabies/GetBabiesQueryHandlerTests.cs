using AutoMapper;
using BirthManagementSystem.Application.Configuration.Mappings;
using BirthManagementSystem.Application.Queries.Babies.GetBabies;
using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth.ManagementSystem.UnitTests.Queries.Babies.GetBabies
{
    public class GetBabiesQueryHandlerTests
    {
        //Stworzenie atrapy repozytorium
        private readonly Mock<IBabyReadOnlyRepository> _babyReadOnlyRepositoryMock;
        private readonly IMapper _mapper;

        public GetBabiesQueryHandlerTests()
        {
            _babyReadOnlyRepositoryMock = new();
            _mapper = MapperHelper.CreateMapper(new BabyMappingProfile());
        }

        [Fact] //Informuje, że metoda jest testem jednostkowym
        public async Task Handle_Should_CallGetAllAsyncOnRepository_WhenGetBabiesQuery()
        {
            //Arrange
            _babyReadOnlyRepositoryMock.Setup(
                x => x.GetAllAsync(
                    It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<Baby>);

            var handler = new GetBabiesQueryHandler(
                _babyReadOnlyRepositoryMock.Object,
                _mapper);

            //Act
            await handler.Handle(new GetBabiesQuery(), default);

            //Assert
            _babyReadOnlyRepositoryMock.Verify(
                x => x.GetAllAsync(It.IsAny<CancellationToken>()),
                Times.Once
                );
        }

        [Fact]
        public async Task Handle_Should_ReturnNotEmptyCollection_WhenGetBabiesQuery()
        {
            //Arrange
            var babies = new List<Baby>() 
            {
                new Baby()
                {
                    Id = 1,
                    FirstName = "Jan",
                    SecondName = "Zbigniew",
                    LastName = "Kowalski",
                    PersonalIdentityNumber = "12345678901",
                    DateOfBirth = DateOnly.FromDateTime(new DateTime(2003,1,1)),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            _babyReadOnlyRepositoryMock.Setup(
                x => x.GetAllAsync(
                    It.IsAny<CancellationToken>())).ReturnsAsync(babies);

            var handler = new GetBabiesQueryHandler(
                _babyReadOnlyRepositoryMock.Object,
                _mapper);

            //Act
            var babiesDto = await handler.Handle(new GetBabiesQuery(), default);

            //Assert
            babiesDto.Should().NotBeNullOrEmpty();
        }
    }
}
