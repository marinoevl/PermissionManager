using FakeItEasy;
using FluentAssertions;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Application.PermissionTypes.Queries;
using PermissionManager.Domain.Entities;
using Xunit;

namespace PermissionManager.Test.Application.PermissionTypes.Queries;

public class GetAllPermissionTypesTests
{
    [Fact]
    public void Invoke_ShouldReturnPermissions_WhenPermissionsExists()
    {
         //Arrange
         var permissionTypes = new List<PermissionType>();
         permissionTypes.Add(new PermissionType()
         {
             Id = 1,
             Description = "Disciplina"
         });
         permissionTypes.Add(new PermissionType()
         {
             Id = 1,
             Description = "Enfermedad"
         });
         var permissionTypeRepository = A.Fake<IPermissionTypeRepository>(builder 
             => builder.Strict());
         
         var sut = new GetAllPermissionTypes(permissionTypeRepository);

         A.CallTo(() => permissionTypeRepository.GetAll()).Returns(permissionTypes.AsQueryable());

         //Act
         var result = sut.Invoke().ToList();

         //Assert
         result.Count
             .Should().Be(permissionTypes.Count);
         result.Should()
             .BeInAscendingOrder(m => m.Description);
         result.Count
             .Should().BeGreaterThan(0);

    }
}