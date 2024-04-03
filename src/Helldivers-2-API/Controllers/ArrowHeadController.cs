﻿using Helldivers.Core.Contracts;
using Helldivers.Core.Contracts.Collections;
using Helldivers.Models.ArrowHead;
using Microsoft.AspNetCore.Mvc;

namespace Helldivers.API.Controllers;

/// <summary>
/// Contains API endpoints to mimic the endpoints exposed by the official ArrowHead API.
/// </summary>
public static class ArrowHeadController
{
    /// <summary>
    /// Returns the currently active war season ID.
    /// </summary>
    [ProducesResponseType<WarId>(StatusCodes.Status200OK)]
    public static async Task<IResult> WarId(HttpContext context, IStore<WarId> store)
    {
        var result = await store.Get(context.RequestAborted);

        return Results.Ok(result);
    }

    /// <summary>
    /// Get a snapshot of the current war status.
    /// </summary>
    [ProducesResponseType<WarStatus>(StatusCodes.Status200OK)]
    public static async Task<IResult> Status(HttpContext context, IStore<WarStatus> store)
    {
        var status = await store.Get(context.RequestAborted);

        return Results.Ok(status);
    }

    /// <summary>
    /// Gets the current war info.
    /// </summary>
    [ProducesResponseType<WarInfo>(StatusCodes.Status200OK)]
    public static async Task<IResult> WarInfo(HttpContext context, IStore<WarInfo> store)
    {
        var info = await store.Get(context.RequestAborted);

        return Results.Ok(info);
    }

    /// <summary>
    /// Gets the current war info.
    /// </summary>
    [ProducesResponseType<WarSummary>(StatusCodes.Status200OK)]
    public static async Task<IResult> Summary(HttpContext context, IStore<WarSummary> store)
    {
        var summary = await store.Get(context.RequestAborted);

        return Results.Ok(summary);
    }

    /// <summary>
    /// Retrieves a list of news messages from Super Earth.
    /// </summary>
    [ProducesResponseType<List<NewsFeedItem>>(StatusCodes.Status200OK)]
    public static async Task<IResult> NewsFeed(HttpContext context, IStore<NewsFeedItem, int> store)
    {
        var items = await store.AllAsync(context.RequestAborted);

        return Results.Ok(items);
    }

    /// <summary>
    /// Retrieves a list of currently active assignments (like Major Orders).
    /// </summary>
    [ProducesResponseType<List<Assignment>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public static async Task<IResult> Assignments(HttpContext context, IStore<Assignment, int> store)
    {
        var assignments = await store.AllAsync(context.RequestAborted);

        return Results.Ok(assignments);
    }
}