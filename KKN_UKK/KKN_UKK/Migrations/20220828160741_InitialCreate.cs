using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KKN_UKK.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_MasterLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_MasterLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Flag = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Masters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_MasterSampah",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Harga = table.Column<decimal>(nullable: false),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_MasterSampah", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    IsEmploye = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_BuruanSaes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_BuruanSaes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Mutasi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NasabahId = table.Column<int>(nullable: false),
                    NamaNasabah = table.Column<string>(nullable: true),
                    Jumlah = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Decription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Mutasi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Odf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true),
                    Persentase = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Odf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Saldo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NasabahId = table.Column<int>(nullable: false),
                    Jumlah = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Saldo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    NIK = table.Column<string>(nullable: true),
                    UserIdId = table.Column<int>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    MidleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    JK = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Birtdate = table.Column<DateTime>(maxLength: 1024, nullable: false),
                    Rt = table.Column<string>(nullable: true),
                    Rw = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_Employees_M_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "M_Nasabah",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    NIK = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    UserIdId = table.Column<int>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    MidleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    JK = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Birtdate = table.Column<DateTime>(nullable: false),
                    Rt = table.Column<string>(nullable: true),
                    Rw = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Nasabah", x => x.id);
                    table.ForeignKey(
                        name: "FK_M_Nasabah_M_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Decription = table.Column<string>(maxLength: 1024, nullable: true),
                    UserModelsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_Role_M_Users_UserModelsId",
                        column: x => x.UserModelsId,
                        principalTable: "M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_Panen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    tanggal = table.Column<DateTime>(nullable: false),
                    T_BuruanSaeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Panen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Panen_T_BuruanSaes_T_BuruanSaeId",
                        column: x => x.T_BuruanSaeId,
                        principalTable: "T_BuruanSaes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_Penjualan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    T_BuruanSaeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Penjualan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Penjualan_T_BuruanSaes_T_BuruanSaeId",
                        column: x => x.T_BuruanSaeId,
                        principalTable: "T_BuruanSaes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_BankSampah",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    saldoId = table.Column<int>(nullable: true),
                    mutasiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_BankSampah", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_BankSampah_T_Mutasi_mutasiId",
                        column: x => x.mutasiId,
                        principalTable: "T_Mutasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_BankSampah_T_Saldo_saldoId",
                        column: x => x.saldoId,
                        principalTable: "T_Saldo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    Jenis = table.Column<string>(nullable: true),
                    Qty = table.Column<decimal>(nullable: false),
                    Harga = table.Column<decimal>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    T_PanenId = table.Column<int>(nullable: true),
                    T_PenjualanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Items_T_Panen_T_PanenId",
                        column: x => x.T_PanenId,
                        principalTable: "T_Panen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_Items_T_Penjualan_T_PenjualanId",
                        column: x => x.T_PenjualanId,
                        principalTable: "T_Penjualan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_TransaksiTimbangan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    NasabahId = table.Column<int>(nullable: false),
                    NamaNasabah = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Items = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    HargaSatuan = table.Column<decimal>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    TotalHarga = table.Column<decimal>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    T_BankSampahModelsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TransaksiTimbangan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_TransaksiTimbangan_T_BankSampah_T_BankSampahModelsId",
                        column: x => x.T_BankSampahModelsId,
                        principalTable: "T_BankSampah",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_M_Employees_UserIdId",
                table: "M_Employees",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Nasabah_UserIdId",
                table: "M_Nasabah",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Role_UserModelsId",
                table: "M_Role",
                column: "UserModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_T_BankSampah_mutasiId",
                table: "T_BankSampah",
                column: "mutasiId");

            migrationBuilder.CreateIndex(
                name: "IX_T_BankSampah_saldoId",
                table: "T_BankSampah",
                column: "saldoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Items_T_PanenId",
                table: "T_Items",
                column: "T_PanenId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Items_T_PenjualanId",
                table: "T_Items",
                column: "T_PenjualanId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Panen_T_BuruanSaeId",
                table: "T_Panen",
                column: "T_BuruanSaeId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Penjualan_T_BuruanSaeId",
                table: "T_Penjualan",
                column: "T_BuruanSaeId");

            migrationBuilder.CreateIndex(
                name: "IX_T_TransaksiTimbangan_T_BankSampahModelsId",
                table: "T_TransaksiTimbangan",
                column: "T_BankSampahModelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M_Employees");

            migrationBuilder.DropTable(
                name: "M_MasterLocations");

            migrationBuilder.DropTable(
                name: "M_Masters");

            migrationBuilder.DropTable(
                name: "M_MasterSampah");

            migrationBuilder.DropTable(
                name: "M_Nasabah");

            migrationBuilder.DropTable(
                name: "M_Role");

            migrationBuilder.DropTable(
                name: "T_Items");

            migrationBuilder.DropTable(
                name: "T_Odf");

            migrationBuilder.DropTable(
                name: "T_TransaksiTimbangan");

            migrationBuilder.DropTable(
                name: "M_Users");

            migrationBuilder.DropTable(
                name: "T_Panen");

            migrationBuilder.DropTable(
                name: "T_Penjualan");

            migrationBuilder.DropTable(
                name: "T_BankSampah");

            migrationBuilder.DropTable(
                name: "T_BuruanSaes");

            migrationBuilder.DropTable(
                name: "T_Mutasi");

            migrationBuilder.DropTable(
                name: "T_Saldo");
        }
    }
}
