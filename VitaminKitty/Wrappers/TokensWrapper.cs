using CoreTweet;
using System.Collections.Generic;
using System.IO;
using VitaminKitty.Models;

namespace VitaminKitty.Wrappers
{
    public class TokensWrapper
    {
        private readonly Tokens _tokens;

        public TokensWrapper(Tokens tokens = null)
        {
            if (tokens == null)
            {
                _tokens = new Tokens();
            }
            else
            {
                _tokens = tokens;
            }
        }

        virtual public void Create(TwitterConsumer consumer)
        {
            _tokens.ConsumerKey = consumer.ApiKey;
            _tokens.ConsumerSecret = consumer.ApiSecret;
            _tokens.AccessToken = consumer.AccessToken;
            _tokens.AccessTokenSecret = consumer.AccessSecret;
        }

        virtual public StatusResponse Update(string message)
        {
            return _tokens.Statuses.Update(status: message);
        }

        virtual public StatusResponse Update(string status, IEnumerable<long> media_ids)
        {
            return _tokens.Statuses.Update(status: status, media_ids: media_ids);
        }

        virtual public MediaUploadResult UpdateMedia(FileInfo fileInfo)
        {
            return _tokens.Media.Upload(fileInfo);
        }
    }
}
