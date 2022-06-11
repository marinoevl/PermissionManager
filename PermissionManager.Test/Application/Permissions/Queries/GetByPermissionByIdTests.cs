using FakeItEasy;
using FluentAssertions;
using PermissionManager.Application.Common.Dtos.Permissions;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Application.Permissions.Queries;
using PermissionManager.Domain.Entities;
using Xunit;

namespace PermissionManager.Test.Application.Permissions.Queries;

public class GetByPermissionByIdTests
{
    [Fact]
    public async Task Invoke_ShouldReturnPermissions_WhenPermissionsExists()
    {
        //Arrange
        var permissionId = 1;
        var getPermissionByIdRequest = new GetPermissionByIdRequest(permissionId);
        var permissionResponse = new Permission()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Smith",
            PermissionTypeId = 1,
            PermissionDate = DateTime.Now.AddDays(5)
        };
        
        var permissionRepository = A.Fake<IPermissionRepository>(builder 
             => builder.Strict());
              
        var sut = new GetPermissionById(permissionRepository);

        A.CallTo(() => permissionRepository.GetByIdAsync(permissionId, new CancellationToken())).Returns(permissionResponse);

        //Act
        var result = await sut.Invoke(getPermissionByIdRequest, new CancellationToken());

        //Assert
        result.Id.Should().Be(permissionResponse.Id);
        result.FirstName.Should().Be(permissionResponse.FirstName);
        result.LastName.Should().Be(permissionResponse.LastName);
        result.PermissionTypeId.Should().Be(permissionResponse.PermissionTypeId);
        result.PermissionDate.Should().Be(permissionResponse.PermissionDate.ToString("yyyy-MM-dd"));
    }
}