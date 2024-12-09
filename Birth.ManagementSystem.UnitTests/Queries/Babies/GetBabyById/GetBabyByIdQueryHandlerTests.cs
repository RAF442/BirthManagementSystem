using AutoMapper;
using Birth.ManagementSystem.UnitTests;
using BirthManagementSystem.Application.Configuration.Mappings;
using BirthManagementSystem.Application.Queries.Babies.GetBabies;
using BirthManagementSystem.Application.Queries.Babies.GetBabyById;
using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthManagementSystem.UnitTests.Queries.Babies.GetBabyById
{
    public class GetBabyByIdQueryHandlerTests
    {
        private readonly Mock<IBabyRepository> _babyRepositoryMock;
        private readonly IMapper _mapper;

        public GetBabyByIdQueryHandlerTests()
        {
            _babyRepositoryMock = new();
            _mapper = MapperHelper.CreateMapper(new BabyMappingProfile());
        }

        [Fact]
        public async Task Handle_Should_CallGetByIdAsyncOnRepository_WhenGetBabyByIdQuery()
        {
            //Arrange
            _babyRepositoryMock.Setup(
                x => x.GetByIdAsync(It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Baby());

            var handler = new GetBabyByIdQueryHandler(
                _babyRepositoryMock.Object,
                _mapper);

            //Act
            await handler.Handle(new GetBabyByIdQuery(1), default);

            //Assert
            _babyRepositoryMock.Verify(
                x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()),
                Times.Once
                );
        }

        [Fact]
        public async Task Handle_Should_ReturnBaby_WhenGetBabyByIdQuery()
        {
            //Arrange
            var baby = new Baby()
            {
                Id = 1,
                FirstName = "Jan",
                SecondName = "Zbigniew",
                LastName = "Kowalski",
                PersonalIdentityNumber = "12345678901",
                DateOfBirth = DateOnly.FromDateTime(new DateTime(2003, 1, 1)),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _babyRepositoryMock.Setup(
                x => x.GetByIdAsync(It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(baby);

            var handler = new GetBabyByIdQueryHandler(
                _babyRepositoryMock.Object,
                _mapper);

            //Act
            var babyDto = await handler.Handle(new GetBabyByIdQuery(1), default);

            //Assert
            babyDto.Should().NotBeNull();
            babyDto.Id.Should().Be(baby.Id);
            babyDto.FirstName.Should().Be(baby.FirstName);
            babyDto.SecondName.Should().Be(baby.SecondName);
            babyDto.LastName.Should().Be(baby.LastName);
            babyDto.PersonalIdentityNumber.Should().Be(baby.PersonalIdentityNumber);
            babyDto.DateOfBirth.Should().Be(baby.DateOfBirth);
        }

        [Fact]
        public async Task Handle_Should_ReturnNull_WhenGetBabyByIdQuery()
        {
            //Arrange
            _babyRepositoryMock.Setup(
                x => x.GetByIdAsync(It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync((Baby)null);

            var handler = new GetBabyByIdQueryHandler(
                _babyRepositoryMock.Object,
                _mapper);

            //Act
            var babyDto = await handler.Handle(new GetBabyByIdQuery(1), default);

            //Assert
            babyDto.Should().BeNull();
        }
    }
}
