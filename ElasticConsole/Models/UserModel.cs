using System;
using System.ComponentModel.DataAnnotations;

namespace ElasticConsole.Models
{
    /// <summary>
    /// Represents a user
    /// </summary>
    public class UserModel
    {
        public Guid Id { get; set; }

        public Guid OrganisationId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}