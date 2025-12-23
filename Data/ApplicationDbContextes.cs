using ApplicationDeGestionERP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContextes : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContextes(DbContextOptions<ApplicationDbContextes> options) : base(options)
    {
    }

    // DbSet existants
    public DbSet<G_Article> Articles { get; set; }
    public DbSet<G_Categorie> Categories { get; set; }
    public DbSet<G_Client> Clients { get; set; }
    public DbSet<G_Facture> Factures { get; set; }
    public DbSet<G_LigneFacture> LignesFacture { get; set; }
    public DbSet<G_Fournisseur> Fournisseurs { get; set; }

    // Nouveau DbSet pour G_Utilisateurs
    public DbSet<G_Utilisateurs> Utilisateurs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuration des rôles Identity
        var adminRoleId = "admin-role-id"; // Remplacez par un ID statique
        var userRoleId = "user-role-id";   // Remplacez par un ID statique

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "some-static-value",
            },
            new IdentityRole()
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "some-static-value",
            });

        base.OnModelCreating(modelBuilder);

        // Configuration pour G_Article
        modelBuilder.Entity<G_Article>()
            .HasOne(a => a.Categorie)
            .WithMany(c => c.Articles)
            .HasForeignKey(a => a.CategorieID)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuration pour G_Client
        modelBuilder.Entity<G_Client>()
            .HasMany(c => c.Factures)
            .WithOne(f => f.Client)
            .HasForeignKey(f => f.ClientID)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuration pour G_Facture
        modelBuilder.Entity<G_Facture>()
            .HasMany(f => f.LignesFacture)
            .WithOne(lf => lf.Facture)
            .HasForeignKey(lf => lf.FactureID)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuration pour G_Utilisateurs
        modelBuilder.Entity<G_Utilisateurs>(entity =>
        {
            entity.HasKey(e => e.Id); // Définir la clé primaire
            entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Générer automatiquement l'ID
            entity.Property(e => e.UserName).IsRequired().HasMaxLength(256); // Limiter la longueur du nom d'utilisateur
            entity.Property(e => e.Email).IsRequired().HasMaxLength(256); // Limiter la longueur de l'email
            entity.Property(e => e.RoleName).HasMaxLength(256); // Limiter la longueur du nom du rôle
        });
    }
}