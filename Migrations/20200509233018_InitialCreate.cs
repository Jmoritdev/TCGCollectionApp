using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollectionApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MTGImageUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Small = table.Column<string>(nullable: true),
                    Normal = table.Column<string>(nullable: true),
                    Large = table.Column<string>(nullable: true),
                    Png = table.Column<string>(nullable: true),
                    ArtCrop = table.Column<string>(nullable: true),
                    BorderCrop = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGImageUris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MTGLegalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Standard = table.Column<string>(nullable: true),
                    Future = table.Column<string>(nullable: true),
                    Historic = table.Column<string>(nullable: true),
                    Pioneer = table.Column<string>(nullable: true),
                    Modern = table.Column<string>(nullable: true),
                    Legacy = table.Column<string>(nullable: true),
                    Pauper = table.Column<string>(nullable: true),
                    Vintage = table.Column<string>(nullable: true),
                    Penny = table.Column<string>(nullable: true),
                    Commander = table.Column<string>(nullable: true),
                    Brawl = table.Column<string>(nullable: true),
                    Duel = table.Column<string>(nullable: true),
                    Oldschool = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGLegalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MTGPrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usd = table.Column<string>(nullable: true),
                    UsdFoil = table.Column<string>(nullable: true),
                    Eur = table.Column<string>(nullable: true),
                    Tix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MTGPurchaseUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tcgplayer = table.Column<string>(nullable: true),
                    Cardmarket = table.Column<string>(nullable: true),
                    Cardhoarder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGPurchaseUris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MTGRelatedUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gatherer = table.Column<string>(nullable: true),
                    TcgplayerDecks = table.Column<string>(nullable: true),
                    Edhrec = table.Column<string>(nullable: true),
                    Mtgtop8 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGRelatedUris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MTGSet",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Object = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    MtgoCode = table.Column<string>(nullable: true),
                    ArenaCode = table.Column<string>(nullable: true),
                    TcgplayerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    ScryfallUri = table.Column<string>(nullable: true),
                    SearchUri = table.Column<string>(nullable: true),
                    ReleasedAt = table.Column<DateTimeOffset>(nullable: false),
                    SetType = table.Column<string>(nullable: true),
                    CardCount = table.Column<int>(nullable: false),
                    Digital = table.Column<bool>(nullable: false),
                    FoilOnly = table.Column<bool>(nullable: false),
                    BlockCode = table.Column<string>(nullable: true),
                    Block = table.Column<string>(nullable: true),
                    IconSvgUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGSet", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "MTGCard",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Object = table.Column<string>(nullable: true),
                    OracleId = table.Column<string>(nullable: true),
                    MultiverseIdsJson = table.Column<string>(nullable: true),
                    MtgoId = table.Column<int>(nullable: false),
                    ArenaId = table.Column<int>(nullable: false),
                    TcgplayerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Lang = table.Column<string>(nullable: true),
                    ReleasedAt = table.Column<DateTimeOffset>(nullable: false),
                    Uri = table.Column<string>(nullable: true),
                    ScryfallUri = table.Column<string>(nullable: true),
                    Layout = table.Column<string>(nullable: true),
                    HighresImage = table.Column<bool>(nullable: false),
                    ImageUrisId = table.Column<int>(nullable: true),
                    ManaCost = table.Column<string>(nullable: true),
                    Cmc = table.Column<double>(nullable: false),
                    TypeLine = table.Column<string>(nullable: true),
                    ColorsJson = table.Column<string>(nullable: true),
                    ColorIdentityJson = table.Column<string>(nullable: true),
                    LegalitiesId = table.Column<int>(nullable: true),
                    GamesJson = table.Column<string>(nullable: true),
                    Reserved = table.Column<bool>(nullable: false),
                    Foil = table.Column<bool>(nullable: false),
                    Nonfoil = table.Column<bool>(nullable: false),
                    Oversized = table.Column<bool>(nullable: false),
                    Promo = table.Column<bool>(nullable: false),
                    Reprint = table.Column<bool>(nullable: false),
                    Variation = table.Column<bool>(nullable: false),
                    Set = table.Column<string>(nullable: true),
                    SetName = table.Column<string>(nullable: true),
                    SetType = table.Column<string>(nullable: true),
                    SetUri = table.Column<string>(nullable: true),
                    SetSearchUri = table.Column<string>(nullable: true),
                    ScryfallSetUri = table.Column<string>(nullable: true),
                    RulingsUri = table.Column<string>(nullable: true),
                    PrintsSearchUri = table.Column<string>(nullable: true),
                    CollectorNumber = table.Column<string>(nullable: true),
                    Digital = table.Column<bool>(nullable: false),
                    Rarity = table.Column<string>(nullable: true),
                    CardBackId = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    ArtistIdsJson = table.Column<string>(nullable: true),
                    IllustrationId = table.Column<string>(nullable: true),
                    BorderColor = table.Column<string>(nullable: true),
                    Frame = table.Column<string>(nullable: true),
                    FullArt = table.Column<bool>(nullable: false),
                    Textless = table.Column<bool>(nullable: false),
                    Booster = table.Column<bool>(nullable: false),
                    StorySpotlight = table.Column<bool>(nullable: false),
                    EdhrecRank = table.Column<int>(nullable: false),
                    PricesId = table.Column<int>(nullable: true),
                    RelatedUrisId = table.Column<int>(nullable: true),
                    PurchaseUrisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MTGCard_MTGImageUris_ImageUrisId",
                        column: x => x.ImageUrisId,
                        principalTable: "MTGImageUris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MTGCard_MTGLegalities_LegalitiesId",
                        column: x => x.LegalitiesId,
                        principalTable: "MTGLegalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MTGCard_MTGPrices_PricesId",
                        column: x => x.PricesId,
                        principalTable: "MTGPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MTGCard_MTGPurchaseUris_PurchaseUrisId",
                        column: x => x.PurchaseUrisId,
                        principalTable: "MTGPurchaseUris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MTGCard_MTGRelatedUris_RelatedUrisId",
                        column: x => x.RelatedUrisId,
                        principalTable: "MTGRelatedUris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MTGCard_MTGSet_Set",
                        column: x => x.Set,
                        principalTable: "MTGSet",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MTGCardFace",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Object = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ManaCost = table.Column<string>(nullable: true),
                    TypeLine = table.Column<string>(nullable: true),
                    OracleText = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    ArtistId = table.Column<Guid>(nullable: false),
                    IllustrationId = table.Column<Guid>(nullable: false),
                    MTGCardId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGCardFace", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MTGCardFace_MTGCard_MTGCardId",
                        column: x => x.MTGCardId,
                        principalTable: "MTGCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MTGCard_ImageUrisId",
                table: "MTGCard",
                column: "ImageUrisId");

            migrationBuilder.CreateIndex(
                name: "IX_MTGCard_LegalitiesId",
                table: "MTGCard",
                column: "LegalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_MTGCard_PricesId",
                table: "MTGCard",
                column: "PricesId");

            migrationBuilder.CreateIndex(
                name: "IX_MTGCard_PurchaseUrisId",
                table: "MTGCard",
                column: "PurchaseUrisId");

            migrationBuilder.CreateIndex(
                name: "IX_MTGCard_RelatedUrisId",
                table: "MTGCard",
                column: "RelatedUrisId");

            migrationBuilder.CreateIndex(
                name: "IX_MTGCard_Set",
                table: "MTGCard",
                column: "Set");

            migrationBuilder.CreateIndex(
                name: "IX_MTGCardFace_MTGCardId",
                table: "MTGCardFace",
                column: "MTGCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MTGCardFace");

            migrationBuilder.DropTable(
                name: "MTGCard");

            migrationBuilder.DropTable(
                name: "MTGImageUris");

            migrationBuilder.DropTable(
                name: "MTGLegalities");

            migrationBuilder.DropTable(
                name: "MTGPrices");

            migrationBuilder.DropTable(
                name: "MTGPurchaseUris");

            migrationBuilder.DropTable(
                name: "MTGRelatedUris");

            migrationBuilder.DropTable(
                name: "MTGSet");
        }
    }
}
