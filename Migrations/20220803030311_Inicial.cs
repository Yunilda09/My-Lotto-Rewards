using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal_AP1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ganancias",
                columns: table => new
                {
                    GananciaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaGanancia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalGanancia = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganancias", x => x.GananciaId);
                });

            migrationBuilder.CreateTable(
                name: "Loterias",
                columns: table => new
                {
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreLoteria = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loterias", x => x.LoteriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaTicket = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalMonto = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "TipoJugadas",
                columns: table => new
                {
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreJugada = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoJugadas", x => x.TipoJugadaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ganancia = table.Column<double>(type: "REAL", nullable: false),
                    Jugado = table.Column<double>(type: "REAL", nullable: false),
                    UseApi = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GananciasDetalle",
                columns: table => new
                {
                    GananciaDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GananciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ganancia = table.Column<decimal>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GananciasDetalle", x => x.GananciaDetalleId);
                    table.ForeignKey(
                        name: "FK_GananciasDetalle_Ganancias_GananciaId",
                        column: x => x.GananciaId,
                        principalTable: "Ganancias",
                        principalColumn: "GananciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketsDetalle",
                columns: table => new
                {
                    TicketDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ganancia = table.Column<double>(type: "REAL", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsDetalle", x => x.TicketDetalleId);
                    table.ForeignKey(
                        name: "FK_TicketsDetalle_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "NombreLoteria" },
                values: new object[] { 1, "Loteria Nacional" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "NombreLoteria" },
                values: new object[] { 2, "Loteria Nacional Noche" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "NombreLoteria" },
                values: new object[] { 3, "Loteka" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "NombreLoteria" },
                values: new object[] { 4, "LoteDom" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "NombreLoteria" },
                values: new object[] { 5, "Leidsa" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "NombreLoteria" },
                values: new object[] { 6, "La Primera" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "NombreLoteria" },
                values: new object[] { 7, "Loteria Real" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 1, "Juega+" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 2, "Pega+" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 3, "Gana+" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 4, "Quiniela Loteka" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 5, "Mega Chances" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 6, "El Extra" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 7, "Quiniela" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 8, "Quemaito" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 9, "Pega3 Mas" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 10, "Quiniela Leidsa" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 11, "Loto Pool" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 12, "Super KinitoTV" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 13, "Loto Real" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 14, "Tu Fecha" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 15, "Pega4" });

            migrationBuilder.InsertData(
                table: "TipoJugadas",
                columns: new[] { "TipoJugadaId", "NombreJugada" },
                values: new object[] { 16, "Quiniela" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GananciasDetalle_GananciaId",
                table: "GananciasDetalle",
                column: "GananciaId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsDetalle_TicketId",
                table: "TicketsDetalle",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GananciasDetalle");

            migrationBuilder.DropTable(
                name: "Loterias");

            migrationBuilder.DropTable(
                name: "TicketsDetalle");

            migrationBuilder.DropTable(
                name: "TipoJugadas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ganancias");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
