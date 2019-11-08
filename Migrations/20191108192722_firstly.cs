using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalProject.Migrations
{
    public partial class firstly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    State_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.State_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Full_name = table.Column<string>(nullable: true),
                    Role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Role_id",
                        column: x => x.Role_id,
                        principalTable: "Roles",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Work_name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Role_id = table.Column<int>(nullable: false),
                    User_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_id);
                    table.ForeignKey(
                        name: "FK_Customers_Roles_Role_id",
                        column: x => x.Role_id,
                        principalTable: "Roles",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    Designer_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Skills = table.Column<string>(nullable: true),
                    Softs = table.Column<string>(nullable: true),
                    Role_id = table.Column<int>(nullable: false),
                    User_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Designer_id);
                    table.ForeignKey(
                        name: "FK_Designers_Roles_Role_id",
                        column: x => x.Role_id,
                        principalTable: "Roles",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Designers_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    User_id = table.Column<int>(nullable: false),
                    State_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_Orders_States_State_id",
                        column: x => x.State_id,
                        principalTable: "States",
                        principalColumn: "State_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Request_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    User_id = table.Column<int>(nullable: false),
                    State_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Request_id);
                    table.ForeignKey(
                        name: "FK_Requests_States_State_id",
                        column: x => x.State_id,
                        principalTable: "States",
                        principalColumn: "State_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders_Designers",
                columns: table => new
                {
                    Order_id = table.Column<int>(nullable: false),
                    Designer_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Designers", x => new { x.Designer_id, x.Order_id });
                    table.ForeignKey(
                        name: "FK_Orders_Designers_Designers_Designer_id",
                        column: x => x.Designer_id,
                        principalTable: "Designers",
                        principalColumn: "Designer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Designers_Orders_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests_Customers",
                columns: table => new
                {
                    Request_id = table.Column<int>(nullable: false),
                    Customers_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests_Customers", x => new { x.Customers_id, x.Request_id });
                    table.ForeignKey(
                        name: "FK_Requests_Customers_Customers_Customers_id",
                        column: x => x.Customers_id,
                        principalTable: "Customers",
                        principalColumn: "Customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_Requests_Request_id",
                        column: x => x.Request_id,
                        principalTable: "Requests",
                        principalColumn: "Request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Role_id",
                table: "Customers",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_User_id",
                table: "Customers",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_Role_id",
                table: "Designers",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_User_id",
                table: "Designers",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_State_id",
                table: "Orders",
                column: "State_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_User_id",
                table: "Orders",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Designers_Order_id",
                table: "Orders_Designers",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_State_id",
                table: "Requests",
                column: "State_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_User_id",
                table: "Requests",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Customers_Request_id",
                table: "Requests_Customers",
                column: "Request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_id",
                table: "Users",
                column: "Role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders_Designers");

            migrationBuilder.DropTable(
                name: "Requests_Customers");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
