﻿namespace muchik.market.web.Models
{
	public class PostSignInResponse
    {
		public bool Success { get; set; }
		public string Message { get; set; } = null!;
		public User Data { get; set; } = null!;
	}

    public class GetRolesResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public List<Role> Data { get; set; } = null!;
    }

    public class User
	{
		public string Id { get; set; } = null!;
		public string Email { get; set; } = null!;
		public Role Role { get; set; } = null!;
		public string Token { get; set; } = null!;
	}

    public class NewUser
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RoleId { get; set; } = null!;
    }

    public class Role
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
	}

	public class SignInRequest
	{
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
