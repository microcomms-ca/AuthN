using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Application
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ClientId { get; set; }

    public string ClientSecret { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public string SignInRedirectUri { get; set; } = null!;

    public string SignOutRedirectUri { get; set; } = null!;

    public bool IsPkceenabled { get; set; }

    public bool IsActive { get; set; }
}
