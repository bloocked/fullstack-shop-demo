using backend.Controllers;
using backend.DTOs;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class NotificationsControllerTests
{
    [Fact]
    public void GetLatestNotification_ReturnsOk_WhenNotificationExists()
    {
        // Arrange
        var mockService = new Mock<INotificationService>();
        var userId = 1;
        var notification = new NotificationDto { Id = 1, Message = "Test" };
        mockService.Setup(s => s.GetLatestForUser(userId)).Returns(notification);

        var controller = new NotificationsController(mockService.Object);

        // Act
        var result = controller.GetLatestNotification(userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(notification, okResult.Value);
    }

    [Fact]
    public void GetLatestNotification_ReturnsNotFound_WhenNoNotification()
    {
        // Arrange
        var mockService = new Mock<INotificationService>();
        var userId = 2;
        mockService.Setup(s => s.GetLatestForUser(userId)).Returns((NotificationDto?)null);

        var controller = new NotificationsController(mockService.Object);

        // Act
        var result = controller.GetLatestNotification(userId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }
}