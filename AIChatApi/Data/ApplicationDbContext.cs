using EnterpriseAIAssistant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EnterpriseAIAssistant.API.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                 
        }
        public DbSet<ChatHistory> ChatHistories { get; set; }
    }
}
