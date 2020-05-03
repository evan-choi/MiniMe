using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniMe.Chunithm.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false),
                    SortNumber = table.Column<int>(nullable: false),
                    Param1 = table.Column<int>(nullable: false),
                    Param2 = table.Column<int>(nullable: false),
                    Param3 = table.Column<int>(nullable: false),
                    Param4 = table.Column<int>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    PlayCount = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    FriendshipExp = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    IsNewMark = table.Column<bool>(nullable: false),
                    Param1 = table.Column<int>(nullable: false),
                    Param2 = table.Column<int>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    PlayCount = table.Column<int>(nullable: false),
                    ScoreMax = table.Column<int>(nullable: false),
                    IsFullCombo = table.Column<bool>(nullable: false),
                    IsAllJustice = table.Column<bool>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false),
                    ScoreRank = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    LastPlayDate = table.Column<DateTimeOffset>(nullable: false),
                    Param1 = table.Column<int>(nullable: false),
                    Param2 = table.Column<int>(nullable: false),
                    Param3 = table.Column<int>(nullable: false),
                    Param4 = table.Column<int>(nullable: false),
                    IsClear = table.Column<bool>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataExs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompatibleCmVersion = table.Column<string>(nullable: true),
                    Medal = table.Column<int>(nullable: false),
                    MapIconId = table.Column<int>(nullable: false),
                    VoiceId = table.Column<int>(nullable: false),
                    Ext1 = table.Column<int>(nullable: false),
                    Ext2 = table.Column<int>(nullable: false),
                    Ext3 = table.Column<int>(nullable: false),
                    Ext4 = table.Column<int>(nullable: false),
                    Ext5 = table.Column<int>(nullable: false),
                    Ext6 = table.Column<int>(nullable: false),
                    Ext7 = table.Column<int>(nullable: false),
                    Ext8 = table.Column<int>(nullable: false),
                    Ext9 = table.Column<int>(nullable: false),
                    Ext10 = table.Column<int>(nullable: false),
                    Ext11 = table.Column<int>(nullable: false),
                    Ext12 = table.Column<int>(nullable: false),
                    Ext13 = table.Column<int>(nullable: false),
                    Ext14 = table.Column<int>(nullable: false),
                    Ext15 = table.Column<int>(nullable: false),
                    Ext16 = table.Column<int>(nullable: false),
                    Ext17 = table.Column<int>(nullable: false),
                    Ext18 = table.Column<int>(nullable: false),
                    Ext19 = table.Column<int>(nullable: false),
                    Ext20 = table.Column<int>(nullable: false),
                    ExtStr1 = table.Column<string>(nullable: true),
                    ExtStr2 = table.Column<string>(nullable: true),
                    ExtStr3 = table.Column<string>(nullable: true),
                    ExtStr4 = table.Column<string>(nullable: true),
                    ExtStr5 = table.Column<string>(nullable: true),
                    ExtLong1 = table.Column<long>(nullable: false),
                    ExtLong2 = table.Column<long>(nullable: false),
                    ExtLong3 = table.Column<long>(nullable: false),
                    ExtLong4 = table.Column<long>(nullable: false),
                    ExtLong5 = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataExs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessCode = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    IsWebJoin = table.Column<bool>(nullable: false),
                    WebLimitDate = table.Column<DateTimeOffset>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ReincarnationNum = table.Column<int>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    Point = table.Column<int>(nullable: false),
                    TotalPoint = table.Column<long>(nullable: false),
                    PlayCount = table.Column<int>(nullable: false),
                    MultiPlayCount = table.Column<int>(nullable: false),
                    MultiWinCount = table.Column<int>(nullable: false),
                    RequestResCount = table.Column<int>(nullable: false),
                    AcceptResCount = table.Column<int>(nullable: false),
                    SuccessResCount = table.Column<int>(nullable: false),
                    PlayerRating = table.Column<int>(nullable: false),
                    HighestRating = table.Column<int>(nullable: false),
                    NameplateId = table.Column<int>(nullable: false),
                    FrameId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    TrophyId = table.Column<int>(nullable: false),
                    PlayedTutorialBit = table.Column<int>(nullable: false),
                    FirstTutorialCancelNum = table.Column<int>(nullable: false),
                    MasterTutorialCancelNum = table.Column<int>(nullable: false),
                    TotalRepertoireCount = table.Column<int>(nullable: false),
                    TotalMapNum = table.Column<int>(nullable: false),
                    TotalHiScore = table.Column<long>(nullable: false),
                    TotalBasicHighScore = table.Column<long>(nullable: false),
                    TotalAdvancedHighScore = table.Column<long>(nullable: false),
                    TotalExpertHighScore = table.Column<long>(nullable: false),
                    TotalMasterHighScore = table.Column<long>(nullable: false),
                    EventWatchedDate = table.Column<DateTimeOffset>(nullable: false),
                    FriendCount = table.Column<int>(nullable: false),
                    IsMaimai = table.Column<bool>(nullable: false),
                    FirstGameId = table.Column<string>(nullable: true),
                    FirstRomVersion = table.Column<string>(nullable: true),
                    FirstDataVersion = table.Column<string>(nullable: true),
                    FirstPlayDate = table.Column<DateTimeOffset>(nullable: false),
                    LastGameId = table.Column<string>(nullable: true),
                    LastRomVersion = table.Column<string>(nullable: true),
                    LastDataVersion = table.Column<string>(nullable: true),
                    LastPlayDate = table.Column<DateTimeOffset>(nullable: false),
                    LastPlaceId = table.Column<int>(nullable: false),
                    LastPlaceName = table.Column<string>(nullable: true),
                    LastRegionId = table.Column<string>(nullable: true),
                    LastRegionName = table.Column<string>(nullable: true),
                    LastAllNetId = table.Column<string>(nullable: true),
                    LastClientId = table.Column<string>(nullable: true),
                    PlayerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuelLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DuelId = table.Column<int>(nullable: false),
                    Progress = table.Column<int>(nullable: false),
                    Point = table.Column<int>(nullable: false),
                    IsClear = table.Column<bool>(nullable: false),
                    LastPlayDate = table.Column<DateTimeOffset>(nullable: false),
                    Param1 = table.Column<int>(nullable: false),
                    Param2 = table.Column<int>(nullable: false),
                    Param3 = table.Column<int>(nullable: false),
                    Param4 = table.Column<int>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuelLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameOptionExs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ext1 = table.Column<int>(nullable: false),
                    Ext2 = table.Column<int>(nullable: false),
                    Ext3 = table.Column<int>(nullable: false),
                    Ext4 = table.Column<int>(nullable: false),
                    Ext5 = table.Column<int>(nullable: false),
                    Ext6 = table.Column<int>(nullable: false),
                    Ext7 = table.Column<int>(nullable: false),
                    Ext8 = table.Column<int>(nullable: false),
                    Ext9 = table.Column<int>(nullable: false),
                    Ext10 = table.Column<int>(nullable: false),
                    Ext11 = table.Column<int>(nullable: false),
                    Ext12 = table.Column<int>(nullable: false),
                    Ext13 = table.Column<int>(nullable: false),
                    Ext14 = table.Column<int>(nullable: false),
                    Ext15 = table.Column<int>(nullable: false),
                    Ext16 = table.Column<int>(nullable: false),
                    Ext17 = table.Column<int>(nullable: false),
                    Ext18 = table.Column<int>(nullable: false),
                    Ext19 = table.Column<int>(nullable: false),
                    Ext20 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOptionExs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BgInfo = table.Column<int>(nullable: false),
                    FieldColor = table.Column<int>(nullable: false),
                    GuideSound = table.Column<int>(nullable: false),
                    SoundEffect = table.Column<int>(nullable: false),
                    GuideLine = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    OptionSet = table.Column<int>(nullable: false),
                    Matching = table.Column<int>(nullable: false),
                    JudgePos = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    JudgeJustice = table.Column<int>(nullable: false),
                    JudgeAttack = table.Column<int>(nullable: false),
                    Headphone = table.Column<int>(nullable: false),
                    PlayerLevel = table.Column<int>(nullable: false),
                    SuccessTap = table.Column<int>(nullable: false),
                    SuccessExTap = table.Column<int>(nullable: false),
                    SuccessSlideHold = table.Column<int>(nullable: false),
                    SuccessAir = table.Column<int>(nullable: false),
                    SuccessFlick = table.Column<int>(nullable: false),
                    SuccessSkill = table.Column<int>(nullable: false),
                    SuccessTapTimbre = table.Column<int>(nullable: false),
                    Privacy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemKind = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MapId = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    IsClear = table.Column<bool>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    Routeint = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    StatusCount = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MusicId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    PlayCount = table.Column<int>(nullable: false),
                    ScoreMax = table.Column<int>(nullable: false),
                    ResRequestCount = table.Column<int>(nullable: false),
                    ResAcceptCount = table.Column<int>(nullable: false),
                    ResSuccessCount = table.Column<int>(nullable: false),
                    MissCount = table.Column<int>(nullable: false),
                    MaxComboCount = table.Column<int>(nullable: false),
                    IsFullCombo = table.Column<bool>(nullable: false),
                    IsAllJustice = table.Column<bool>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false),
                    FullChain = table.Column<int>(nullable: false),
                    MaxChain = table.Column<int>(nullable: false),
                    ScoreRank = table.Column<int>(nullable: false),
                    IsLock = table.Column<bool>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paylogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Sortint = table.Column<int>(nullable: false),
                    PlaceId = table.Column<int>(nullable: false),
                    PlayDate = table.Column<DateTimeOffset>(nullable: false),
                    UserPlayDate = table.Column<DateTimeOffset>(nullable: false),
                    MusicId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    CustomId = table.Column<int>(nullable: false),
                    PlayedUserId1 = table.Column<int>(nullable: false),
                    PlayedUserId2 = table.Column<int>(nullable: false),
                    PlayedUserId3 = table.Column<int>(nullable: false),
                    PlayedUserName1 = table.Column<string>(nullable: true),
                    PlayedUserName2 = table.Column<string>(nullable: true),
                    PlayedUserName3 = table.Column<string>(nullable: true),
                    PlayedMusicLevel1 = table.Column<int>(nullable: false),
                    PlayedMusicLevel2 = table.Column<int>(nullable: false),
                    PlayedMusicLevel3 = table.Column<int>(nullable: false),
                    PlayedCustom1 = table.Column<int>(nullable: false),
                    PlayedCustom2 = table.Column<int>(nullable: false),
                    PlayedCustom3 = table.Column<int>(nullable: false),
                    Track = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    MaxCombo = table.Column<int>(nullable: false),
                    MaxChain = table.Column<int>(nullable: false),
                    RateTap = table.Column<int>(nullable: false),
                    RateHold = table.Column<int>(nullable: false),
                    RateSlide = table.Column<int>(nullable: false),
                    RateAir = table.Column<int>(nullable: false),
                    RateFlick = table.Column<int>(nullable: false),
                    JudgeGuilty = table.Column<int>(nullable: false),
                    JudgeAttack = table.Column<int>(nullable: false),
                    JudgeJustice = table.Column<int>(nullable: false),
                    JudgeCritical = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    PlayerRating = table.Column<int>(nullable: false),
                    IsNewRecord = table.Column<bool>(nullable: false),
                    IsFullCombo = table.Column<bool>(nullable: false),
                    FullChainKind = table.Column<int>(nullable: false),
                    IsAllJustice = table.Column<bool>(nullable: false),
                    IsContinue = table.Column<bool>(nullable: false),
                    IsFreeToPlay = table.Column<bool>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    PlayKind = table.Column<int>(nullable: false),
                    IsClear = table.Column<bool>(nullable: false),
                    SkillLevel = table.Column<int>(nullable: false),
                    SkillEffect = table.Column<int>(nullable: false),
                    PlaceName = table.Column<string>(nullable: true),
                    IsMaimai = table.Column<bool>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paylogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "DataExs");

            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.DropTable(
                name: "DuelLists");

            migrationBuilder.DropTable(
                name: "GameOptionExs");

            migrationBuilder.DropTable(
                name: "GameOptions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "Paylogs");
        }
    }
}
