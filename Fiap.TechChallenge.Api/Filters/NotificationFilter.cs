using Fiap.TechChallenge.Api.Application.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;

namespace Fiap.TechChallenge.Api.Filters;

public class NotificationFilter : IEndpointFilter
{
    private readonly NotificationContext _notificationContext;

    public NotificationFilter(NotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next(context);

        if (_notificationContext.HasNotifications)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = "application/json";

            var notifications = JsonSerializer.Serialize(_notificationContext.Notifications);

            await context.HttpContext.Response.WriteAsync(notifications);
        }

        return await next(context);
    }
}