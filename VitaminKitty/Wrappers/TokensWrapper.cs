using CoreTweet;
using System.Collections.Generic;
using System.IO;
using VitaminKitty.Models;

namespace VitaminKitty.Wrappers
{
    public class TokensWrapper : ITokensWrapper
    {
        private readonly Tokens _tokens;

        public TokensWrapper(TwitterConsumer consumer)
        {
            _tokens = new Tokens();
            _tokens.ConsumerKey = consumer.ApiKey;
            _tokens.ConsumerSecret = consumer.ApiSecret;
            _tokens.AccessToken = consumer.AccessToken;
            _tokens.AccessTokenSecret = consumer.AccessSecret;
        }

        public TokensWrapper(Tokens tokens)
        {
            _tokens = tokens;
        }


        public StatusResponse Update(string message)
        {
            return _tokens.Statuses.Update(status: message);
        }

        public StatusResponse Update(string status, IEnumerable<long> media_ids)
        {
            return _tokens.Statuses.Update(status: status, media_ids: media_ids);
        }

        public MediaUploadResult UpdateMedia(FileInfo fileInfo)
        {
            return _tokens.Media.Upload(fileInfo);
        }
    }
}
