using System;
using System.Collections.Generic;

namespace DOTNET_IBE_1.Entities
{
    public partial class UserSearchRequest
    {
        public string UserId { get; set; } = null!;
        public string SearchRequest { get; set; } = null!;
    }
}
