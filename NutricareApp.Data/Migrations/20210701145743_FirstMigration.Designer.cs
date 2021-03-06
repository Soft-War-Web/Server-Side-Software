// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutricareApp.Data;

namespace NutricareApp.Data.Migrations
{
    [DbContext(typeof(DbContextNutricareApp))]
    [Migration("20210701145743_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientRecipe", b =>
                {
                    b.Property<int>("ClientsClientId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("int");

                    b.HasKey("ClientsClientId", "RecipesRecipeId");

                    b.HasIndex("RecipesRecipeId");

                    b.ToTable("ClientRecipe");
                });

            modelBuilder.Entity("DietRecipe", b =>
                {
                    b.Property<int>("DietsDietId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("int");

                    b.HasKey("DietsDietId", "RecipesRecipeId");

                    b.HasIndex("RecipesRecipeId");

                    b.ToTable("DietRecipe");
                });

            modelBuilder.Entity("NutricareApp.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("appointment_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("appointment_date");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<int?>("DietId")
                        .HasColumnType("int")
                        .HasColumnName("diet_id");

                    b.Property<int>("NutritionistId")
                        .HasColumnType("int")
                        .HasColumnName("nutritionist_id");

                    b.Property<string>("NutritionistNotes")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("nutritionist_notes");

                    b.HasKey("AppointmentId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DietId")
                        .IsUnique()
                        .HasFilter("[diet_id] IS NOT NULL");

                    b.HasIndex("NutritionistId");

                    b.ToTable("appointment");
                });

            modelBuilder.Entity("NutricareApp.Entities.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bill_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal")
                        .HasColumnName("amount");

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("bill_date");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Ruc")
                        .HasColumnType("int")
                        .HasColumnName("ruc");

                    b.HasKey("BillId");

                    b.HasIndex("ClientId");

                    b.ToTable("bill");
                });

            modelBuilder.Entity("NutricareApp.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("client_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("username");

                    b.HasKey("ClientId");

                    b.ToTable("client");
                });

            modelBuilder.Entity("NutricareApp.Entities.Diet", b =>
                {
                    b.Property<int>("DietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("diet_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("created_at");

                    b.Property<string>("DietDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("description");

                    b.Property<string>("DietName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("DietId");

                    b.ToTable("diet");
                });

            modelBuilder.Entity("NutricareApp.Entities.Nutritionist", b =>
                {
                    b.Property<int>("NutritionistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nutritionist_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CnpNumber")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("cnp_number");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("username");

                    b.HasKey("NutritionistId");

                    b.ToTable("nutritionist");
                });

            modelBuilder.Entity("NutricareApp.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("payment_method_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillingAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("billing_address");

                    b.Property<string>("BillingAddressLine2")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("billing_address_line2");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("card_number");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("card_type");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("country");

                    b.Property<int>("ExpirationDateMonth")
                        .HasColumnType("int")
                        .HasColumnName("expiration_date_month");

                    b.Property<int>("ExpirationDateYear")
                        .HasColumnType("int")
                        .HasColumnName("expiration_date_year");

                    b.Property<string>("OwnerFirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("owner_first_name");

                    b.Property<string>("OwnerLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("owner_last_name");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int")
                        .HasColumnName("phone_number");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("postal_code");

                    b.Property<int>("SecurityCode")
                        .HasColumnType("int")
                        .HasColumnName("security_code");

                    b.HasKey("PaymentMethodId");

                    b.HasIndex("ClientId");

                    b.ToTable("payment_method");
                });

            modelBuilder.Entity("NutricareApp.Entities.Professionalprofile", b =>
                {
                    b.Property<int>("ProfessionalprofileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("professional_profile_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NutritionistId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessionalExperienceDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("professional_experience_description");

                    b.HasKey("ProfessionalprofileId");

                    b.HasIndex("NutritionistId")
                        .IsUnique();

                    b.ToTable("professional_profile");
                });

            modelBuilder.Entity("NutricareApp.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("created_At");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.Property<int>("Favorites")
                        .HasColumnType("int")
                        .HasColumnName("favorites");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("ingredients");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("DateTime")
                        .HasColumnName("last_modification");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("NutritionistId")
                        .HasColumnType("int")
                        .HasColumnName("nutritionist_id");

                    b.Property<string>("Preparation")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("preparation");

                    b.HasKey("RecipeId");

                    b.HasIndex("NutritionistId");

                    b.ToTable("recipe");
                });

            modelBuilder.Entity("NutricareApp.Entities.Recommendation", b =>
                {
                    b.Property<int>("RecommendationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("recommendation_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("DateTime")
                        .HasColumnName("last_modification");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("NutritionistId")
                        .HasColumnType("int")
                        .HasColumnName("nutritionist_id");

                    b.HasKey("RecommendationId");

                    b.HasIndex("NutritionistId");

                    b.ToTable("recommendation");
                });

            modelBuilder.Entity("NutricareApp.Entities.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("specialty_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description");

                    b.Property<string>("SpecialtyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("SpecialtyId");

                    b.ToTable("specialty");
                });

            modelBuilder.Entity("ProfessionalprofileSpecialty", b =>
                {
                    b.Property<int>("ProfessionalprofilesProfessionalprofileId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtiesSpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("ProfessionalprofilesProfessionalprofileId", "SpecialtiesSpecialtyId");

                    b.HasIndex("SpecialtiesSpecialtyId");

                    b.ToTable("ProfessionalprofileSpecialty");
                });

            modelBuilder.Entity("ClientRecipe", b =>
                {
                    b.HasOne("NutricareApp.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutricareApp.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DietRecipe", b =>
                {
                    b.HasOne("NutricareApp.Entities.Diet", null)
                        .WithMany()
                        .HasForeignKey("DietsDietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutricareApp.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutricareApp.Entities.Appointment", b =>
                {
                    b.HasOne("NutricareApp.Entities.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("fk_client_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutricareApp.Entities.Diet", "Diet")
                        .WithOne("Appointment")
                        .HasForeignKey("NutricareApp.Entities.Appointment", "DietId");

                    b.HasOne("NutricareApp.Entities.Nutritionist", "Nutritionist")
                        .WithMany("Appointments")
                        .HasForeignKey("NutritionistId")
                        .HasConstraintName("fk_nutritionist_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Diet");

                    b.Navigation("Nutritionist");
                });

            modelBuilder.Entity("NutricareApp.Entities.Bill", b =>
                {
                    b.HasOne("NutricareApp.Entities.Client", "Client")
                        .WithMany("Bills")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("fk_client_id3")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("NutricareApp.Entities.PaymentMethod", b =>
                {
                    b.HasOne("NutricareApp.Entities.Client", "Client")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("fk_client_id2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("NutricareApp.Entities.Professionalprofile", b =>
                {
                    b.HasOne("NutricareApp.Entities.Nutritionist", "Nutritionist")
                        .WithOne("ProfessionalProfile")
                        .HasForeignKey("NutricareApp.Entities.Professionalprofile", "NutritionistId")
                        .HasConstraintName("fk_nutritionist_profile_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutritionist");
                });

            modelBuilder.Entity("NutricareApp.Entities.Recipe", b =>
                {
                    b.HasOne("NutricareApp.Entities.Nutritionist", "Nutritionist")
                        .WithMany("Recipes")
                        .HasForeignKey("NutritionistId")
                        .HasConstraintName("fk_nutritionist_recipe_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutritionist");
                });

            modelBuilder.Entity("NutricareApp.Entities.Recommendation", b =>
                {
                    b.HasOne("NutricareApp.Entities.Nutritionist", "Nutritionist")
                        .WithMany("Recommendations")
                        .HasForeignKey("NutritionistId")
                        .HasConstraintName("fk_nutritionist_recommendation_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutritionist");
                });

            modelBuilder.Entity("ProfessionalprofileSpecialty", b =>
                {
                    b.HasOne("NutricareApp.Entities.Professionalprofile", null)
                        .WithMany()
                        .HasForeignKey("ProfessionalprofilesProfessionalprofileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutricareApp.Entities.Specialty", null)
                        .WithMany()
                        .HasForeignKey("SpecialtiesSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutricareApp.Entities.Client", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Bills");

                    b.Navigation("PaymentMethods");
                });

            modelBuilder.Entity("NutricareApp.Entities.Diet", b =>
                {
                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("NutricareApp.Entities.Nutritionist", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("ProfessionalProfile");

                    b.Navigation("Recipes");

                    b.Navigation("Recommendations");
                });
#pragma warning restore 612, 618
        }
    }
}
