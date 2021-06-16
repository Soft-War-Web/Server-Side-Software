using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutricareApp.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    password = table.Column<string>(type: "char(60)", unicode: false, maxLength: 60, nullable: false),
                    firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "diet",
                columns: table => new
                {
                    diet_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diet", x => x.diet_id);
                });

            migrationBuilder.CreateTable(
                name: "nutritionist",
                columns: table => new
                {
                    nutritionist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    password = table.Column<string>(type: "char(60)", unicode: false, maxLength: 60, nullable: false),
                    firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cnp_number = table.Column<int>(type: "int", unicode: false, maxLength: 6, nullable: false),
                    created_at = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritionist", x => x.nutritionist_id);
                });

            migrationBuilder.CreateTable(
                name: "specialty",
                columns: table => new
                {
                    specialty_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialty", x => x.specialty_id);
                });

            migrationBuilder.CreateTable(
                name: "bill",
                columns: table => new
                {
                    bill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal", nullable: false),
                    ruc = table.Column<int>(type: "int", nullable: false),
                    bill_date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill", x => x.bill_id);
                    table.ForeignKey(
                        name: "fk_client_id3",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment_method",
                columns: table => new
                {
                    payment_method_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    card_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    expiration_date_month = table.Column<int>(type: "int", nullable: false),
                    expiration_date_year = table.Column<int>(type: "int", nullable: false),
                    security_code = table.Column<int>(type: "int", nullable: false),
                    owner_first_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    owner_last_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    billing_address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    billing_address_line2 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    postal_code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    phone_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_method", x => x.payment_method_id);
                    table.ForeignKey(
                        name: "fk_client_id2",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    appointment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    nutritionist_id = table.Column<int>(type: "int", nullable: false),
                    diet_id = table.Column<int>(type: "int", nullable: true),
                    appointment_date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    nutritionist_notes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.appointment_id);
                    table.ForeignKey(
                        name: "FK_appointment_diet_diet_id",
                        column: x => x.diet_id,
                        principalTable: "diet",
                        principalColumn: "diet_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_nutritionist_id",
                        column: x => x.nutritionist_id,
                        principalTable: "nutritionist",
                        principalColumn: "nutritionist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professional_profile",
                columns: table => new
                {
                    professional_profile_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NutritionistId = table.Column<int>(type: "int", nullable: false),
                    professional_experience_description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional_profile", x => x.professional_profile_id);
                    table.ForeignKey(
                        name: "fk_nutritionist_profile_id",
                        column: x => x.NutritionistId,
                        principalTable: "nutritionist",
                        principalColumn: "nutritionist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nutritionist_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    preparation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ingredients = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    favorite = table.Column<int>(type: "int", nullable: false),
                    created_At = table.Column<DateTime>(type: "DateTime", nullable: false),
                    last_modification = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.category_id);
                    table.ForeignKey(
                        name: "fk_nutritionist_recipe_id",
                        column: x => x.nutritionist_id,
                        principalTable: "nutritionist",
                        principalColumn: "nutritionist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recommendation",
                columns: table => new
                {
                    recommendation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nutritionist_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    created_at = table.Column<DateTime>(type: "DateTime", nullable: false),
                    last_modification = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recommendation", x => x.recommendation_id);
                    table.ForeignKey(
                        name: "fk_nutritionist_recommendation_id",
                        column: x => x.nutritionist_id,
                        principalTable: "nutritionist",
                        principalColumn: "nutritionist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalprofileSpecialty",
                columns: table => new
                {
                    ProfessionalprofilesProfessionalprofileId = table.Column<int>(type: "int", nullable: false),
                    SpecialtiesSpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalprofileSpecialty", x => new { x.ProfessionalprofilesProfessionalprofileId, x.SpecialtiesSpecialtyId });
                    table.ForeignKey(
                        name: "FK_ProfessionalprofileSpecialty_professional_profile_ProfessionalprofilesProfessionalprofileId",
                        column: x => x.ProfessionalprofilesProfessionalprofileId,
                        principalTable: "professional_profile",
                        principalColumn: "professional_profile_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalprofileSpecialty_specialty_SpecialtiesSpecialtyId",
                        column: x => x.SpecialtiesSpecialtyId,
                        principalTable: "specialty",
                        principalColumn: "specialty_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientRecipe",
                columns: table => new
                {
                    ClientsClientId = table.Column<int>(type: "int", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRecipe", x => new { x.ClientsClientId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_ClientRecipe_client_ClientsClientId",
                        column: x => x.ClientsClientId,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientRecipe_recipe_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "recipe",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietRecipe",
                columns: table => new
                {
                    DietsDietId = table.Column<int>(type: "int", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietRecipe", x => new { x.DietsDietId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_DietRecipe_diet_DietsDietId",
                        column: x => x.DietsDietId,
                        principalTable: "diet",
                        principalColumn: "diet_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietRecipe_recipe_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "recipe",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_client_id",
                table: "appointment",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_diet_id",
                table: "appointment",
                column: "diet_id",
                unique: true,
                filter: "[diet_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_nutritionist_id",
                table: "appointment",
                column: "nutritionist_id");

            migrationBuilder.CreateIndex(
                name: "IX_bill_ClientId",
                table: "bill",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRecipe_RecipesRecipeId",
                table: "ClientRecipe",
                column: "RecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_DietRecipe_RecipesRecipeId",
                table: "DietRecipe",
                column: "RecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_payment_method_ClientId",
                table: "payment_method",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_professional_profile_NutritionistId",
                table: "professional_profile",
                column: "NutritionistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalprofileSpecialty_SpecialtiesSpecialtyId",
                table: "ProfessionalprofileSpecialty",
                column: "SpecialtiesSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_nutritionist_id",
                table: "recipe",
                column: "nutritionist_id");

            migrationBuilder.CreateIndex(
                name: "IX_recommendation_nutritionist_id",
                table: "recommendation",
                column: "nutritionist_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "bill");

            migrationBuilder.DropTable(
                name: "ClientRecipe");

            migrationBuilder.DropTable(
                name: "DietRecipe");

            migrationBuilder.DropTable(
                name: "payment_method");

            migrationBuilder.DropTable(
                name: "ProfessionalprofileSpecialty");

            migrationBuilder.DropTable(
                name: "recommendation");

            migrationBuilder.DropTable(
                name: "diet");

            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "professional_profile");

            migrationBuilder.DropTable(
                name: "specialty");

            migrationBuilder.DropTable(
                name: "nutritionist");
        }
    }
}
