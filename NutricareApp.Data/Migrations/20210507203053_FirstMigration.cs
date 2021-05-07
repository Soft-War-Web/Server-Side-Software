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
                name: "appointment",
                columns: table => new
                {
                    appointment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    nutritionist_id = table.Column<int>(type: "int", nullable: false),
                    diet_id = table.Column<int>(type: "int", nullable: false),
                    appointment_date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    nutritionist_notes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.appointment_id);
                    table.ForeignKey(
                        name: "fk_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_diet_id",
                        column: x => x.diet_id,
                        principalTable: "diet",
                        principalColumn: "diet_id",
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
                name: "specialty_professional_profile",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    ProfessionalProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialty_professional_profile", x => new { x.SpecialtyId, x.ProfessionalProfileId });
                    table.ForeignKey(
                        name: "FK_specialty_professional_profile_professional_profile_ProfessionalProfileId",
                        column: x => x.ProfessionalProfileId,
                        principalTable: "professional_profile",
                        principalColumn: "professional_profile_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specialty_professional_profile_specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "specialty",
                        principalColumn: "specialty_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_client_id",
                table: "appointment",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_diet_id",
                table: "appointment",
                column: "diet_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_nutritionist_id",
                table: "appointment",
                column: "nutritionist_id");

            migrationBuilder.CreateIndex(
                name: "IX_professional_profile_NutritionistId",
                table: "professional_profile",
                column: "NutritionistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipe_nutritionist_id",
                table: "recipe",
                column: "nutritionist_id");

            migrationBuilder.CreateIndex(
                name: "IX_recommendation_nutritionist_id",
                table: "recommendation",
                column: "nutritionist_id");

            migrationBuilder.CreateIndex(
                name: "IX_specialty_professional_profile_ProfessionalProfileId",
                table: "specialty_professional_profile",
                column: "ProfessionalProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.DropTable(
                name: "recommendation");

            migrationBuilder.DropTable(
                name: "specialty_professional_profile");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "diet");

            migrationBuilder.DropTable(
                name: "professional_profile");

            migrationBuilder.DropTable(
                name: "specialty");

            migrationBuilder.DropTable(
                name: "nutritionist");
        }
    }
}
