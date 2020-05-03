using System;
using Microsoft.AspNetCore.Mvc;
using MiniMe.Chunithm.Protocols;
using MiniMe.Chunithm.Protocols.Response;

namespace MiniMe.Chunithm.Controllers
{
    [ApiController]
    [Route("/ChuniServlet")]
    public class ServletController
    {
        [HttpPost("GameLoginApi")]
        public GameLoginResponse GameLogin(GameLoginRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GameLogoutApi")]
        public GameLogoutResponse GameLogout(GameLogoutRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetGameChargeApi")]
        public GetGameChargeResponse GetGameCharge(GetGameChargeRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetGameEventApi")]
        public GetGameEventResponse GetGameEvent(GetGameEventRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetGameIdlistApi")]
        public GetGameIdlistResponse GetGameIdlist(GetGameIdlistRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetGameMessageApi")]
        public GetGameMessageResponse GetGameMessage(GetGameMessageRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetGameRankingApi")]
        public GetGameRankingResponse GetGameRanking(GetGameRankingRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetGameSaleApi")]
        public GetGameSaleResponse GetGameSale(GetGameSaleRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetGameSettingApi")]
        public GetGameSettingResponse GetGameSetting(GetGameSettingRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserActivityApi")]
        public GetUserActivityResponse GetUserActivity(GetUserActivityRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserCharacterApi")]
        public GetUserCharacterResponse GetUserCharacter(GetUserCharacterRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserChargeApi")]
        public GetUserChargeResponse GetUserCharge(GetUserChargeRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserCourseApi")]
        public GetUserCourseResponse GetUserCourse(GetUserCourseRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserDataApi")]
        public GetUserDataResponse GetUserData(GetUserDataRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserDataExApi")]
        public GetUserDataExResponse GetUserDataEx(GetUserDataExRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserDuelApi")]
        public GetUserDuelResponse GetUserDuel(GetUserDuelRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserItemApi")]
        public GetUserItemResponse GetUserItem(GetUserItemRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserMapApi")]
        public GetUserMapResponse GetUserMap(GetUserMapRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserMusicApi")]
        public GetUserMusicResponse GetUserMusic(GetUserMusicRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserOptionApi")]
        public GetUserOptionResponse GetUserOption(GetUserOptionRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserOptionExApi")]
        public GetUserOptionExResponse GetUserOptionEx(GetUserOptionExRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserPreviewApi")]
        public GetUserPreviewResponse GetUserPreview(GetUserPreviewRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserRecentPlayerApi")]
        public GetUserRecentRatingResponse GetUserRecentPlayer(GetUserRecentRatingRequest request)
        {
            return GetUserRecentRating(request);
        }

        [HttpPost("GetUserRecentRatingApi")]
        public GetUserRecentRatingResponse GetUserRecentRating(GetUserRecentRatingRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("GetUserRegionApi")]
        public GetUserRegionResponse GetUserRegion(GetUserRegionRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("UpsertClientBookkeepingApi")]
        public UpsertClientBookkeepingResponse UpsertClientBookkeeping(UpsertClientBookkeepingRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("UpsertClientDevelopApi")]
        public UpsertClientDevelopResponse UpsertClientDevelop(UpsertClientDevelopRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("UpsertClientErrorApi")]
        public UpsertClientErrorResponse UpsertClientError(UpsertClientErrorRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("UpsertClientSettingApi")]
        public UpsertClientSettingResponse UpsertClientSetting(UpsertClientSettingRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("UpsertClientTestmodeApi")]
        public UpsertClientTestmodeResponse UpsertClientTestmode(UpsertClientTestModeRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("UpsertUserAllApi")]
        public UpsertUserAllResponse UpsertUserAll(UpsertUserAllRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
