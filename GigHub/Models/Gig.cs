using System.ComponentModel.DataAnnotations;
using GigHub.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GigHub.Models;

public class Gig
{
    public int Id { get; set; }
    
    [Required]
    public IdentityUser Artist  { get; set; }
    
    public DateTime DateTime { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Venue { get; set; }
    
    [Required]
    public Genre Genre { get; set; }
}